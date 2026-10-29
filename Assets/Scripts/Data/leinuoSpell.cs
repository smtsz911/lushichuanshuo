using UnityEngine;


[CreateAssetMenu(menuName = "LSCS/巡航舰法术数据", fileName = "NewxunhangjianSpellData", order = 0)]
public class leinuoSpell : SpellData
{
    [Header("酒馆法术")]
    [Tooltip("法术费用")]
    [Range(1, 7)]
    public int 费用;
}
