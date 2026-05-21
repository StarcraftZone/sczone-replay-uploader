namespace sczone_replay_uploader
{
    public partial class MainForm : Form
    {
        private static readonly HttpClient _http = new();
        private const string UploadUrl = "https://haoest.com/api/replay/upload";

        private FileSystemWatcher? _watcher;
        private bool _watching = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void BtnToggle_Click(object sender, EventArgs e)
        {
            if (_watching)
                StopWatching();
            else
                StartWatching();
        }

        private async void BtnUpload_Click(object sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog
            {
                Title = "选择录像文件",
                Filter = "SC2 Replay文件 (*.SC2Replay)|*.SC2Replay",
                Multiselect = true,
            };
            if (dlg.ShowDialog() != DialogResult.OK || dlg.FileNames.Length == 0)
                return;

            btnUpload.Enabled = false;
            var files = dlg.FileNames;
            progressBar.Minimum = 0;
            progressBar.Maximum = files.Length;
            progressBar.Value = 0;
            lblProgress.Text = $"0 / {files.Length}";

            int done = 0;
            await Task.WhenAll(files.Select(async f =>
            {
                await UploadFileAsync(f);
                Interlocked.Increment(ref done);
                Invoke(() =>
                {
                    progressBar.Value = done;
                    lblProgress.Text = $"{done} / {files.Length}";
                });
            }));

            btnUpload.Enabled = true;
        }

        private void StartWatching()
        {
            string docsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string watchPath = Path.Combine(docsPath, "StarCraft II", "Accounts");

            if (!Directory.Exists(watchPath))
            {
                Log($"[错误] 目录不存在：{watchPath}");
                return;
            }

            _watcher = new FileSystemWatcher(watchPath, "*.SC2Replay")
            {
                IncludeSubdirectories = true,
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.CreationTime,
                EnableRaisingEvents = true
            };
            _watcher.Created += OnReplayCreated;

            _watching = true;
            btnToggle.Text = "停止监听";
            lblStatus.Text = $"状态：监听中 - {watchPath}";
            Log($"[启动] 开始监听：{watchPath}");
        }

        private void StopWatching()
        {
            if (_watcher != null)
            {
                _watcher.EnableRaisingEvents = false;
                _watcher.Dispose();
                _watcher = null;
            }
            _watching = false;
            btnToggle.Text = "开始监听";
            lblStatus.Text = "状态：已停止";
            Log("[停止] 已停止监听");
        }

        private void OnReplayCreated(object sender, FileSystemEventArgs e)
        {
            Log($"[检测] 发现新录像：{e.Name}");
            _ = UploadWithRetryAsync(e.FullPath);
        }

        private async Task UploadWithRetryAsync(string filePath)
        {
            // 等待文件写入完成（最多 30 秒）
            for (int i = 0; i < 30; i++)
            {
                try
                {
                    using var fs = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.None);
                    break;
                }
                catch (IOException)
                {
                    await Task.Delay(1000);
                }
            }
            await UploadFileAsync(filePath);
        }

        private async Task UploadFileAsync(string filePath)
        {
            try
            {
                await using var stream = File.OpenRead(filePath);
                var boundary = Guid.NewGuid().ToString("N");
                using var content = new MultipartFormDataContent(boundary);
                // 手动覆盖 Content-Type，去掉 .NET 自动添加的引号（boundary="xxx" → boundary=xxx）
                content.Headers.Remove("Content-Type");
                content.Headers.TryAddWithoutValidation("Content-Type", $"multipart/form-data; boundary={boundary}");

                using var fileContent = new StreamContent(stream);
                fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
                content.Add(fileContent, "file", Path.GetFileName(filePath));

                Log($"[上传] 正在上传：{Path.GetFileName(filePath)}");
                var response = await _http.PostAsync(UploadUrl, content);
                string body = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                    Log($"[成功] 上传成功：{Path.GetFileName(filePath)}");
                else
                    Log($"[失败] {Path.GetFileName(filePath)} → {(int)response.StatusCode} {body}");
            }
            catch (Exception ex)
            {
                Log($"[异常] {Path.GetFileName(filePath)}：{ex.Message}");
            }
        }

        private void Log(string message)
        {
            string entry = $"{DateTime.Now:HH:mm:ss}  {message}";
            if (lstLog.InvokeRequired)
                lstLog.BeginInvoke(() => AppendLog(entry));
            else
                AppendLog(entry);
        }

        private void AppendLog(string entry)
        {
            lstLog.AppendText(entry + Environment.NewLine);
            lstLog.ScrollToCaret();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            StopWatching();
            base.OnFormClosing(e);
        }
    }
}
