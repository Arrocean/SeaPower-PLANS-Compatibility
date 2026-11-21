中国海军潜艇兼容性Mod

依赖
  Console++（创意工坊 3782661493）
  095A Runtime（创意工坊 3815454553）
  R.A.T.S. Keel 或 Anchor Chain

使用
  可在 Steam 创意工坊直接订阅本补丁和所需前置模组，Steam 会自动下载。
  在模组列表启用两个前置模组和本补丁，把本补丁排在两个前置模组之后，重启游戏。
  进入战斗，用 F8 打开 Console++，开启无限弹药，然后操作玩家方 095A 发射垂发导弹。
  Console++ 成功补进一枚弹后，本补丁将该发射筒重新标记为可用。发射进行中会等 095A 完成收尾再复位。
  停用时在模组列表关闭本补丁并重启游戏。

潜艇弹药整合
  需启用 PLAN Submarines（3594891803）、PLAN Pack（3775128499）和 095A（3815454553）。
  09X、095 和 093B 共用 095A 的鹰击-18B、长剑-10潜射型，以及 PLAN Pack 的鱼-9、鱼-10。弹量沿用各艇配置。
  长剑-10潜射型按目标坐标飞行，惯导漂移为零。启用协同中段制导（3838908720）后，可在有有效友方雷达航迹时接收中段更新。
  第一阶段已确认 09X 能使用长剑-10潜射型。第二阶段弹库的游戏内实射与数据链验证待完成。

鱼雷更新
  PLAN Submarines 的 093、093A、039 和 039A 的鱼-6换为鱼-9，094A、039B 和 039C 的鱼-6换为鱼-10电动型。
  095A 的鱼-6A换为鱼-9，095 增配 2 枚可用于拦截的鱼-12A。
  鱼-10电动型最高 60 节，发射距离 0.5–32 海里，断线设置沿用 PLAN Pack。

验证
  已在游戏日志中确认 095A 的同一发射筒能重复发射鹰击-20潜射型。
  在 BepInEx/LogOutput.log 或 BepInEx/Keel-log.txt 查找 [Console++ / 095A] Installed。
  对鹰击-20 潜射型和鹰击-18B 分别检查可重复发射。将 Rearmed 行与 095A VLS 日志中的 unit、system 和 cell 对照，确认同一个筒再次出现 outcome=Launched。
  关闭无限弹药后再发射，确认后续射出的弹按正常规则消耗。

工坊内容
  选择本目录作为内容目录，preview.jpg 作为预览图。发布时将两个前置模组列为必需物品。

----- English -----

SeaPower PLANS Compatibility

Requires Console++ (Workshop 3782661493), Type 095A Runtime (Workshop 3815454553),
and either R.A.T.S. Keel or Anchor Chain.

Subscribe to this patch and its required items in the Steam Workshop. Steam downloads them automatically.
Enable this patch below both dependencies and restart Sea Power. In a mission,
open Console++ with F8 and turn on Unlimited Ammo. The patch makes a player-owned
095A VLS cell available after Console++ restores a round and 095A finishes the launch.
Disable this patch in the mod list and restart to remove it.

Submarine loadouts
Enable PLAN Submarines (3594891803), PLAN Pack (3775128499), and Type 095A
(3815454553). Type 09X, Type 095 and Type 093B share the Type 095A YJ-18B
and submarine-launched CJ-10, plus PLAN Pack's Yu-9 and Yu-10. Quantities come
from PLAN Submarines. The CJ-10 follows target coordinates with zero simulated
inertial drift. Cooperative Midcourse Guidance (3838908720) can supply updates
from valid friendly radar tracks. Type 09X was confirmed to use the submarine-
launched CJ-10 in the initial integration. In-game testing of the expanded
loadouts and datalink updates is pending.

Torpedo changes
Yu-9 replaces Yu-6 on PLAN Submarines' Type 093, Type 093A, Type 039 and
Type 039A. The electric Yu-10 replaces Yu-6 on Type 094A, Type 039B and
Type 039C. Type 095A uses Yu-9 in place of Yu-6A, and Type 095 adds two
Yu-12A torpedoes for interception. The electric Yu-10 reaches 60 knots,
with a 0.5–32 nautical mile launch envelope and PLAN Pack's wire settings.

The same Type 095A cell has launched the submarine-launched YJ-20 repeatedly in
game. Look for [Console++ / 095A] Installed in the Keel or BepInEx log. In a new
mission, test both submarine-launched YJ-20 and
YJ-18B. Match the unit, system, and cell in Rearmed and 095A VLS logs and confirm
a second outcome=Launched in the same cell. Turn Unlimited Ammo off and verify
that subsequent launches use the remaining rounds normally.

Use this directory as Workshop content and preview.jpg as its preview image.
List Console++ and Type 095A as required Workshop items when publishing.
