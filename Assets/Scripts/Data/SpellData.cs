using UnityEngine;

[CreateAssetMenu(menuName = "LSCS/法术数据", fileName = "NewSpellData", order = 0)]
public class SpellData : ScriptableObject
{
    [Header("基本信息")]
    [Tooltip("法术中文名")]
    public string 名称;

    [Tooltip("法术ID")]
    public string ID;

    [Tooltip("卡面描述文本，照抄卡图上的中文描述")]
    [TextArea]
    public string 描述;

    [Tooltip("法术等级")]
    [Range(1,7)]
    public int 等级;

    [Tooltip("是否出现在酒馆")]
    public bool 是否出现在酒馆;

    [Header("图片")]
    [Tooltip("法术卡牌图：")]
    public Sprite 卡牌图;

}
