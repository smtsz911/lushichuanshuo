using UnityEngine;

/// <summary>
/// 所有卡牌数据的公共基类：随从、法术（以及未来的任务、饰品、伙伴）都继承它。
/// 商店、手牌、牌库等系统统一用 CardData 类型处理，不需要到处判断卡种。
/// 此类是 abstract（抽象）：只当底座，不能直接创建资产。
/// </summary>
public abstract class CardData : ScriptableObject
{
    [Header("基本信息")]
    [Tooltip("卡牌中文名")]
    public string 名称;

    [Tooltip("卡面描述文本")]
    [TextArea]
    public string 描述;

    /// <summary>
    /// 每种子类决定"商店/手牌里显示哪张图"。
    /// 子类用 override 返回自己的图片字段即可。
    /// </summary>
    public virtual Sprite 显示图 => null;
}
