# Art 资源目录说明

> 下载日期：2026-10-29（中文版卡图）｜ 用途：个人学习项目（不商用）

## 目录内容与来源

| 目录 | 内容 | 来源 | 许可 |
|---|---|---|---|
| `Cards/` | **231 张 1~7 星随从中文卡图**（zhCN，256x PNG，当前活跃卡池全量：1星20/2星33/3星45/4星43/5星46/6星32/7星12）+ `随从清单.csv`（中英文名/星级/攻血/词条/卡图URL） | [art.hearthstonejson.com](https://hearthstonejson.com) 中文端点（数据来自 [bgknowhow.com](https://bgknowhow.com/bgjson/)） | **暴雪版权所有，仅限个人学习使用**：不可公开分享、发布、商用 |
| `MinionArt/` | **231 张随从立绘原画**（无卡框无文字，完整原画 PNG，文件名 = 卡牌ID，与 Cards/ 一一对应） | [art.hearthstonejson.com](https://hearthstonejson.com) `/v1/orig/` 端点 | **暴雪版权所有，仅限个人学习使用**：不可公开分享、发布、商用 |
| `Spells/酒馆法术/` | 206 张酒馆法术中文卡图（含 54 张当前活跃池 + 历史轮换） | [art.hearthstonejson.com](https://hearthstonejson.com) 中文端点 | **暴雪版权所有，仅限个人学习使用**：不可公开分享、发布、商用 |
| `Spells/塑造法术/` | 69 张法术技艺（Spellcraft）生成的塑造法术卡图 | 同上 | 同上 |
| `Spells/其他法术/` | 239 张其余法术（鲜血宝石/香蕉/任务/宝藏/奥秘/畸变/伙伴等衍生卡） | 同上 | 同上 |
| `Spells/法术清单.csv` | 529 行：中文名/费用/星级/卡牌ID/类别/是否池内(活跃54)/描述/卡图状态/文件夹 | 数据来源同卡图 | — |
| `Heroes/Cards/` | **106 张英雄中文卡**（zhCN 渲染，含技能文字，当前活跃英雄全量） | [art.hearthstonejson.com](https://hearthstonejson.com) 中文端点 | **暴雪版权所有，仅限个人学习使用**：不可公开分享、发布、商用 |
| `Heroes/Portraits/` | **106 张英雄头像**（正方形立绘，用于选人界面和游戏内头像） | [bgknowhow.com](https://bgknowhow.com/bgjson/) | **暴雪版权所有，仅限个人学习使用**：不可公开分享、发布、商用 |
| `Heroes/Powers/` | **106 张英雄技能图标**（1 张为 webp） | [art.hearthstonejson.com](https://hearthstonejson.com) + [bgknowhow.com](https://bgknowhow.com/bgjson/) | **暴雪版权所有，仅限个人学习使用**：不可公开分享、发布、商用 |
| `Heroes/英雄清单.csv` | 106 英雄数据：中英文名/护甲/生命/技能中英文名/技能费用/技能中文描述/英雄ID | 数据同上 | — |
| `UI/官方战棋UI/` | 14 张官方酒馆战棋 UI 素材：全屏游戏截图（含棋盘，可作背景）、刷新/冻结/升级按钮、Logo、页头、任务视图、伙伴槽等 | [hearthstone.wiki.gg](https://hearthstone.wiki.gg) 托管的官方素材 | **暴雪版权所有，仅限个人学习使用**：不可公开分享、发布、商用 |
| `Fonts/NotoSansSC-Variable.ttf` | 思源黑体（简体中文可变字重） | [Google Fonts](https://fonts.google.com/noto/specimen/Noto+Sans+SC) | SIL OFL 1.1 开源字体，可自由使用（含商用） |

## 使用提示

- **卡牌图（商店/手牌）**：用 `Cards/` 里对应 `{卡牌ID}.png`（带卡框和中文描述）。
- **战场立绘（场上随从棋子）**：用 `MinionArt/` 里同名 ID 的原画（不带文字），攻击/生命数值由 UI 单独叠加上去。原画是完整方形画作，可整张放入圆角遮罩，或在 Unity 里用 Sprite Editor 裁掉多余背景。
- 两目录文件名均为卡牌 ID，一一对应，随从数据资产里两个字段各填一张即可。
- **随从数值**：打开 `Cards/随从清单.csv`，把星级/攻血/词条抄进 Inspector（或以后做批量导入）。
- **中文字体**：选中 `NotoSansSC-Variable.ttf` → 右键 → `Create > TextMeshPro > Font Asset` 生成 TMP 字体资产，替换 UI 文本的默认字体（默认字体不支持中文）。
- **UI 素材**：Kenney 包内 `PNG/` 文件夹按颜色分类（如 `PNG/Blue/Default/`），原型期随便挑一套颜色统一使用。

## 版权提醒

`Cards/` 目录内的卡图为暴雪娱乐知识产权，**只在本机个人学习使用**。若将来分享或发布本游戏，请删除该目录并替换为原创/AI 生成/CC0 卡图，随从名称也需更换。
