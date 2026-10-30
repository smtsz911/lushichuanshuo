using UnityEngine;

public class gamemanage : MonoBehaviour
{
    public static int zhubishangxian = 3;
    public static int zhubi = 3;

    public MinionData[] minionAll;

    public MinionData[] minionShop;

    public MinionData[] minionMy;

    public SpellData[] spellAll;

    public SpellData[] spellShop;

    public SpellData[] spellMy;

    public static int shopdengji;



    public void shuaXinJiuGuan(int cast) 
    {
        if(zhubi<cast)
        {
        }
        else
        {
            zhubi -= cast;
        }
    }
}
