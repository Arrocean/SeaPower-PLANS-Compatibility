# 中国海军潜艇兼容性Mod

[English](README.md)

这是《Sea Power》的潜艇兼容与弹药整合补丁。

- **095A 垂发补弹**。四种配载均保留原有装填量，每个配载已搭载的导弹各新增 2 枚备弹，涵盖鹰击-20潜射型、鹰击-18B 和长剑-10潜射型。发射筒连接对应弹仓，由游戏原生机制补装。Console++ 为可选项。
- **潜艇弹药复用**：PLAN Submarines 的 09X、095 和 093B 共用 095A 的鹰击-18B、长剑-10潜射型，以及 PLAN Pack 的鱼-9、鱼-10。弹量沿用各艇配置。
- **长剑-10潜射型**：按目标坐标飞行，惯导漂移设为零。有有效的友方雷达航迹时，可通过数据链接收中段更新。
- **鱼雷更新**。PLAN Submarines 的 093、093A、039 和 039A 的鱼-6 换为鱼-9，094A、096、039B 和 039C 的鱼-6 换为鱼-10电动型。095A 的鱼-6A 换为鱼-9，095 增配 2 枚可用于拦截的鱼-12A。鱼-10电动型最高 60 节，发射距离为 0.5–32 海里，断线设置沿用 PLAN Pack。

- **鱼-12A 换装**。055（2026 型）两舷鱼雷弹仓各装 8 枚鱼-12A。直-20F 的反潜配载携带 2 枚鱼-12A空投型，鱼-15投送 1 枚同款空投鱼雷。鱼-15 本体也可将已探测、符合发射条件的敌方鱼雷选为目标。

## 依赖

- 095A 垂发补弹需要启用 095A Runtime，并按其说明安装前置加载器。[095A Runtime](https://steamcommunity.com/sharedfiles/filedetails/?id=3815454553)
- 潜艇弹药复用还需要启用 PLAN Submarines 和 PLAN Pack。长剑-10潜射型的基础弹药定义来自 PLAN Pack。[PLAN Submarines](https://steamcommunity.com/sharedfiles/filedetails/?id=3594891803)、[PLAN Pack](https://steamcommunity.com/sharedfiles/filedetails/?id=3775128499)
- 协同中段制导为可选项，用于接收友方雷达航迹更新。[协同中段制导](https://steamcommunity.com/sharedfiles/filedetails/?id=3838908720)

## 安装与使用

1. 在 Steam 创意工坊直接订阅本模组和所需前置模组。Steam 会自动下载。[Sea Power 创意工坊](https://steamcommunity.com/app/1286220/workshop/)
2. 在模组管理器中启用前置模组和本补丁，把本补丁排在它修改的模组之后，重启游戏。
3. 开一个包含 095A 的新任务，使用新的弹仓配置。

停用时，在模组管理器关闭本补丁并重启游戏。

## 从源码构建

使用 `global.json` 指定的 .NET SDK 打包。

```powershell
dotnet build sppc.csproj -c Release
```

构建会把 `WorkshopSource/` 中的 INI 覆盖、工坊信息、预览图和说明打包到 `Workshop/sppc/`。上传时选择生成的目录作为内容目录，并选择 `preview.jpg` 作为预览图。

手动安装时，关闭游戏，把生成的 `Workshop/sppc/` 整个复制到游戏的 `Sea Power_Data/StreamingAssets/`，保留其中的 `overrides/` 子目录。升级手动安装的旧包时，整目录替换旧 `sppc`，清除退役的 `sppc.dll`。然后在模组管理器中启用并重启游戏。

## 游戏内验证

- **095A**。在新任务中选择默认配载，关闭 Console++ 的「无限弹药」。鹰击-20潜射型和鹰击-18B 各预装 6 枚，长剑-10潜射型预装 12 枚，三种导弹各有 2 枚备弹。打完预装弹后，确认发射筒补装并继续发射。使用 Console++ 时，可另测开启「无限弹药」后的连续发射。
- **弹药复用**：第一阶段已确认 09X 能使用长剑-10潜射型。第二阶段的新场景中，09X 默认应有 8 枚，095 和 093B 各有 6 枚。新增弹药配置的实射和友方数据链更新仍待进游戏验证。

## 许可证

[MIT](LICENSE)
