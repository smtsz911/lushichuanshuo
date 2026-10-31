using UnityEngine;

[CreateAssetMenu(menuName = "LSCS/法术数据", fileName = "NewSpellData", order = 0)]
public class SpellData : CardData
{
    [Tooltip("法术ID")]
    public string ID;

    [Tooltip("法术等级")]
    [Range(1,7)]
    public int 等级;

    [Tooltip("是否出现在酒馆")]
    public bool 是否出现在酒馆;

    [Header("图片")]
    [Tooltip("法术卡牌图：")]
    public Sprite 卡牌图;

    /// <summary>法术只有卡牌图，直接用它显示</summary>
    public override Sprite 显示图 => 卡牌图;

}
