using UnityEngine;



[CreateAssetMenu(menuName = "LSCS/英雄数据", fileName = "NewHeroData", order = 0)]
public class HeroData : ScriptableObject
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("基本信息")]
    [Tooltip("英雄中文名")]
    public string 名称;

    [Tooltip("英雄护甲")]
    public int 护甲;

    [Tooltip("英雄血量")]
    public int 血量=30;

    [Tooltip("英雄技能名")]
    public string 技能名称;

    [Tooltip("卡面描述文本，照抄卡图上的中文描述")]
    [TextArea]
    public string 技能描述;

    [Tooltip("技能费用")]
    [Range(0,3)]
    public int 技能费用 = 0;

    [Tooltip("技能发动形式")]
    public jinengcishu 技能发动形式;

    [Tooltip("主动技能是否发动")]

    public bool 主动技能已经主动发动;

    [Header("图片")]
    [Tooltip("英雄头像图：Assets/Art/Cards 里同名卡牌ID的中文卡图（带卡框文字）")]
    public Sprite 头像图;

    [Tooltip("英雄立绘图：Assets/Art/Cards 里同名卡牌ID的中文卡图（带卡框文字）")]
    public Sprite 立绘图;

    [Tooltip("英雄技能图：Assets/Art/Cards 里同名卡牌ID的中文卡图（带卡框文字）")]
    public Sprite 技能图;

}

public enum jinengcishu
{
    被动 = 0,
    每回合主动 = 1,
    一次性主动 = 2,
}


