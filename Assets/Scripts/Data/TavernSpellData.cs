using UnityEngine;

[CreateAssetMenu(menuName = "LSCS/酒馆法术数据", fileName = "NewTavernSpellData", order = 0)]

public class TavernSpellData : SpellData
{
    [Header("酒馆法术")]
    [Tooltip("法术费用")]
    [Range(1, 7)]
    public int 费用;
}
