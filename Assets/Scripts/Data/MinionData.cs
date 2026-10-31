using UnityEngine;

/// <summary>
/// 随从数据：一张卡 = 一个资产文件，在检查器（Inspector）里像表格一样填写。
/// 创建方式：项目窗口右键 → 创建 → 随从数据。
/// </summary>
[CreateAssetMenu(menuName = "LSCS/随从数据", fileName = "NewMinion", order = 0)]
public class MinionData : CardData
{
    [Tooltip("随从星级（1~6），决定招募概率、伤害和出售价值")]
    [Range(1, 7)]
    public int 星级 = 1;

    [Tooltip("随从种族")]
    public MinionRace 种族;

    [Header("基础数值")]
    [Tooltip("攻击力")]
    [Min(0)]
    public int 攻击 = 1;

    [Tooltip("生命值")]
    [Min(1)]
    public int 生命 = 1;

    [Header("关键词（点开下拉可多选）")]
    [Tooltip("嘲讽、圣盾等，可同时勾选多个")]
    public Keyword 关键词;

    [Header("词条（点开下拉可多选）")]
    [Tooltip("战吼、亡语等，可同时勾选多个")]
    public MinionKeyword 词条;

    [Header("金色形态")]
    [Tooltip("金色版攻击力（一般为普通版的两倍）")]
    [Min(0)]
    public int 金色攻击 = 2;

    [Tooltip("金色版生命值（一般为普通版的两倍）")]
    [Min(1)]
    public int 金色生命 = 2;

    [Header("图片")]
    [Tooltip("卡牌图：Assets/Art/Cards 里同名卡牌ID的中文卡图（带卡框文字）")]
    public Sprite 卡图;

    [Tooltip("立绘：Assets/Art/MinionArt 里同名卡牌ID的原画（站场用）")]
    public Sprite 立绘;

     /// <summary>商店/手牌显示立绘（原版观感、缩放清晰）。想显示完整卡面就改成 => 卡图</summary>
    public override Sprite 显示图 => 卡图;
}

/// <summary>随从种族</summary>
public enum MinionRace
{
    中立,
    野兽,
    恶魔,
    龙,
    元素,
    机械,
    纳迦,
    海盗,
    野猪人,
    亡灵,
    融合,
}

/// <summary>
/// 随从词条（可多选）。勾选后只是记录数据，
/// 实际战斗效果由后面的战斗逻辑代码读取这些标记来实现。
/// </summary>
[System.Flags]
public enum MinionKeyword
{
    无 = 0,
    亡语 = 1 << 0,
    战吼 = 1 << 1,
    磁力 = 1 << 2,
    复仇 = 1 << 3,
    法术技艺 = 1 << 4,

    剧毒=1 << 5,
}

[System.Flags]
public enum Keyword
{
    无 = 0,
    嘲讽 = 1 << 0,
    圣盾 = 1 << 1,
    风怒 = 1 << 2,
    烈毒 = 1 << 3,
    复生 = 1 << 4,

    潜行=1 << 5,
}
