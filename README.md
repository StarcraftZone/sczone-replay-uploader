# 星际2录像自动上传器

监听本地《星际争霸 II》录像目录，自动把新生成的 `.SC2Replay` 文件上传到 [haoest.com](https://haoest.com/replay) 供在线分析。

## 功能

- 自动监听 `Documents/StarCraft II/Accounts` 下所有子目录的新录像，写入完成后自动上传
- 手动批量上传任意 `.SC2Replay` 文件
- 开机自启动（写入 `HKCU\...\Run`）
- 最小化到系统托盘，左键点击恢复窗口，右键菜单可显示窗口或退出
- 启动时检查 GitHub Release，发现新版本时弹窗提示

## 下载

最新版从 [Releases 页](https://github.com/StarcraftZone/sczone-replay-uploader/releases/latest) 下载即用，单文件 self-contained，无需安装 .NET 运行时。

## 从源码构建

需要 .NET 10 SDK。

```sh
dotnet build -c Release
```

发布单文件 exe（与 CI 产物一致）：

```sh
dotnet publish -c Release -r win-x64 --self-contained true \
  -p:PublishSingleFile=true \
  -p:IncludeNativeLibrariesForSelfExtract=true \
  -p:EnableCompressionInSingleFile=true
```

在 macOS / Linux 上构建也支持，已在 csproj 中开启 `EnableWindowsTargeting`。

## 发布流程

推送到 `main` 分支后，GitHub Actions 自动：

1. 用 `csproj` 中 `<Version>` 的前三段拼上 `github.run_number` 作为第四段，得到形如 `1.0.0.42` 的唯一版本号
2. 构建并发布 self-contained 单文件 exe
3. 上传 Artifact 并自动创建 GitHub Release，tag 为 `v<版本号>`

要发大版本时改 `csproj` 中 `<Version>` 的前三段（如 `1.1.0`），下次构建版本就是 `1.1.0.<run_number>`。
