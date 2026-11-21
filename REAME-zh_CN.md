# 中国海军潜艇兼容性Mod

[English](README.md)

这是《Sea Power》的潜艇兼容与弹药整合补丁。

- **095A 垂发补弹**：开启 Console++ 的「无限弹药」后，补丁会在确认补弹成功、发射流程结束后，将玩家控制的 095A 发射筒恢复为可用。
- **潜艇弹药复用**：PLAN Submarines 的 09X、095 和 093B 共用 095A 的鹰击-18B、长剑-10潜射型，以及 PLAN Pack 的鱼-9、鱼-10。弹量沿用各艇配置。
- **长剑-10潜射型**：按目标坐标飞行，惯导漂移设为零。有有效的友方雷达航迹时，可通过数据链接收中段更新。
- **鱼雷更新**：PLAN Submarines 的 093、093A、039 和 039A 的鱼-6换为鱼-9，094A、039B 和 039C 的鱼-6换为鱼-10电动型。095A 的鱼-6A换为鱼-9，095 增配 2 枚可用于拦截的鱼-12A。鱼-10电动型最高 60 节，发射距离为 0.5–32 海里，断线设置沿用 PLAN Pack。

## 依赖

- 095A 垂发补弹需要 [Console++](https://steamcommunity.com/sharedfiles/filedetails/?id=3782661493) 和 [095A Runtime](https://steamcommunity.com/sharedfiles/filedetails/?id=3815454553)。
- 插件通过 [R.A.T.S. Keel](https://steamcommunity.com/sharedfiles/filedetails/?id=3835527459) 或 [Anchor Chain](https://steamcommunity.com/sharedfiles/filedetails/?id=3380210757) 加载。
- 潜艇弹药复用需要 [PLAN Submarines](https://steamcommunity.com/sharedfiles/filedetails/?id=3594891803)、[PLAN Pack](https://steamcommunity.com/sharedfiles/filedetails/?id=3775128499) 和 095A。长剑-10潜射型的基础弹药定义来自 PLAN Pack。
- [协同中段制导](https://steamcommunity.com/sharedfiles/filedetails/?id=3838908720)为可选项，用于接收友方雷达航迹更新。

## 安装与使用

1. 在 [Sea Power 的 Steam 创意工坊](https://steamcommunity.com/app/1286220/workshop/)直接订阅本模组和所需前置模组。Steam 会自动下载。
2. 在模组管理器中启用所需前置模组和本补丁，把本补丁排在 Console++ 和 095A 之后，重启游戏。
3. 使用 095A 时，进战斗按 F8 打开 Console++，开启「无限弹药」。验证弹药复用时，在新场景中查看对应潜艇的默认弹库。

停用时，在模组管理器关闭本补丁并重启游戏。

## 从源码构建

构建需要 .NET SDK、游戏程序集、`BepInEx/core/0Harmony.dll`，以及创意工坊 Anchor Chain 目录内的 `AnchorChain.dll`。

```powershell
dotnet build sppc.csproj -c Release
```

项目默认使用 `D:\Steam`。Steam 库在其他位置时，可以传入游戏目录和工坊内容目录。

```powershell
dotnet build sppc.csproj -c Release `
  '-p:SeaPowerDir=E:\SteamLibrary\steamapps\common\Sea Power' `
  '-p:WorkshopDir=E:\SteamLibrary\steamapps\workshop\content\1286220'
```

工坊源文件在 `WorkshopSource/`。Release 构建会把源文件和 `sppc.dll` 一起打包到 `Workshop/sppc/`。上传时选择生成的目录作为内容目录，并选择 `preview.jpg` 作为预览图。

如果要安装自己构建的包，把生成的 `Workshop/sppc/` 整个复制到游戏的 `Sea Power_Data/StreamingAssets/`，保留其中的 `overrides/` 子目录。然后在模组管理器中启用并重启游戏。

## 游戏内验证

- **095A**：加载成功后，`BepInEx/LogOutput.log` 或 `BepInEx/Keel-log.txt` 会出现 `[Console++ / 095A] Installed`。已在游戏日志中确认鹰击-20潜射型可从同一发射筒重复发射。复测时对照 `Rearmed` 和 095A VLS 日志中的 `unit`、`system`、`cell`，确认同一发射筒再次出现 `outcome=Launched`。
- **弹药复用**：第一阶段已确认 09X 能使用长剑-10潜射型。第二阶段的新场景中，09X 默认应有 8 枚，095 和 093B 各有 6 枚。新增弹药配置的实射和友方数据链更新仍待进游戏验证。

## 许可证

[MIT](LICENSE)
