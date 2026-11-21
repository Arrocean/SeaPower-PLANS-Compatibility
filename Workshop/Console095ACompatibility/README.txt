Console++ 与 095A 垂发兼容补丁 0.1.0

依赖
  Console++ 0.42.0，创意工坊 3782661493
  095A Runtime 1.9.10，创意工坊 3815454553
  Anchor Chain 或 R.A.T.S. Keel。静态构建使用 Sea Power 0.9.3-261116、Anchor Chain 1.2.0 和 Harmony 2.9.0。

使用
  在模组列表启用两个前置模组和本补丁，把本补丁排在两个前置模组之后，重启游戏。
  进入战斗，用 F8 打开 Console++，开启无限弹药，然后操作玩家方 095A 发射垂发导弹。
  Console++ 成功补进一枚弹后，本补丁将该发射筒重新标记为可用。发射进行中会等 095A 完成收尾再复位。
  停用时在模组列表关闭本补丁并重启游戏。

验证
  当前为静态构建版，尚未在游戏进程中验证。建议从新战斗开始复测。
  在 BepInEx/LogOutput.log 或 BepInEx/Keel-log.txt 查找 [Console++ / 095A] Installed。
  对鹰击-20 潜射型和鹰击-18B 分别检查可重复发射。将 Rearmed 行与 095A VLS 日志中的 unit、system 和 cell 对照，确认同一个筒再次出现 outcome=Launched。
  关闭无限弹药后再发射，确认后续射出的弹按正常规则消耗。

工坊内容
  选择本目录作为内容目录，preview.jpg 作为预览图。发布时将两个前置模组列为必需物品。

----- English -----

Console++ / Type 095A Compatibility 0.1.0

Requires Console++ 0.42.0 (Workshop 3782661493), Type 095A Runtime 1.9.10
(Workshop 3815454553), and Anchor Chain or R.A.T.S. Keel. Built against
Sea Power 0.9.3-261116, Anchor Chain 1.2.0, and Harmony 2.9.0.

Enable this patch below both dependencies and restart Sea Power. In a mission,
open Console++ with F8 and turn on Unlimited Ammo. The patch makes a player-owned
095A VLS cell available after Console++ restores a round and 095A finishes the launch.
Disable this patch in the mod list and restart to remove it.

This build has yet to be tested in-game. Look for [Console++ / 095A] Installed in
the Keel or BepInEx log. In a new mission, test both submarine-launched YJ-20 and
YJ-18B. Match the unit, system, and cell in Rearmed and 095A VLS logs and confirm
a second outcome=Launched in the same cell. Turn Unlimited Ammo off and verify
that subsequent launches use the remaining rounds normally.

Use this directory as Workshop content and preview.jpg as its preview image.
List Console++ and Type 095A as required Workshop items when publishing.
