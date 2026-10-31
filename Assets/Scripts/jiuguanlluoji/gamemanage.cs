
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class gamemanage : MonoBehaviour
{
    public static int zhubishangxian = 3;
    public static int zhubi = 3;

    public MinionData[] minionAll;

   

    public Image[] shopCardImages;

    public MinionData[] minionMy;

    public SpellData[] spellAll;

    public SpellData[] spellShop;

    public SpellData[] spellMy;

    public  int shopdengji=1;

    public int shengbenfei = 3;

    List<MinionData> houxuan = new List<MinionData>();

    List<SpellData> houxuanspell = new List<SpellData>();

    List<CardData> shouPai = new List<CardData>();
    List<CardData> minionShop = new List<CardData>();

    List<CardData> mycard = new List<CardData>();
    public GameObject handCardPrefab;   // 拖入 HandCard 预制体
    public Transform handArea;          // 拖入 HandArea 物体

    public GameObject ShopCardPrefab;   // 拖入 HandCard 预制体
    public Transform ShopArea;          // 拖入 HandArea 物体

    public GameObject MyCardPrefab;   // 拖入 HandCard 预制体
    public Transform MyArea;          // 拖入 HandArea 物体


    public GameObject[] shopSlots;

    public TextMeshProUGUI zhubiText;

    public TextMeshProUGUI shengbenfeiyong;

    public TextMeshProUGUI dangqiandengji;

    public void Start()
    {
        shopdengji = 1;
        GengXinZhuBiUI();
        GengxindangqiandengjiUI();
        GengxinshengbenfeiyongUI();
        if (minionAll.Length > 1)
        {
            shouPai.Add(minionAll[0]);
            shouPai.Add(minionAll[1]);
            shouPai.Add(minionAll[0]);
            shouPai.Add(minionAll[1]);
            shouPai.Add(minionAll[0]);
            shouPai.Add(minionAll[1]);
            shouPai.Add(spellAll[1]);
            shouPai.Add(minionAll[0]);
            shouPai.Add(minionAll[1]);
            shouPai.Add(spellAll[1]);
            ShuaxinshoupaiUi();
        }
        for (int i = 0; i < shopCardImages.Length; i++)
        {
            shopCardImages[i].sprite = null;
            shopSlots[i].SetActive(false);
        }

    }
    public void 商店刷新随从() 
    {
        foreach (MinionData m in minionAll)
        {
            if (m.星级 <= shopdengji)   // 只收当前酒馆等级能出的卡
            {
                houxuan.Add(m);
            }
        }

        foreach (SpellData s in spellAll)
        {
            if (s.等级 <= shopdengji)   // 只收当前酒馆等级能出的卡
            {
                houxuanspell.Add(s);
            }
        }
        if (minionShop.Count > 0) { minionShop.Clear(); Debug.Log("清空商店"); }

        if (shopdengji < 2)
        {
            for (int i = 0; i < 3; i++)
            {
                int index = UnityEngine.Random.Range(0, houxuan.Count);
                minionShop.Add (houxuan[index]);
            }
            int indexspell = UnityEngine.Random.Range(0, houxuanspell.Count);
            minionShop.Add(houxuanspell[indexspell]);
            ShuaxinshopUi();
            houxuan.Clear();
            houxuanspell.Clear();
        }
        else if (shopdengji < 4)
        {
            for (int i = 0; i < 4; i++)
            {
                int index = UnityEngine.Random.Range(0, houxuan.Count);
                minionShop.Add(houxuan[index]);
            }
            int indexspell = UnityEngine.Random.Range(0, houxuanspell.Count);
            minionShop.Add(houxuanspell[indexspell]);
            ShuaxinshopUi();
            houxuan.Clear();
            houxuanspell.Clear();
        }
        else if (shopdengji < 6)
        {
            for (int i = 0; i < 5; i++)
            {
                int index = UnityEngine.Random.Range(0, houxuan.Count);
                minionShop.Add(houxuan[index]);
            }
            int indexspell = UnityEngine.Random.Range(0, houxuanspell.Count);
            minionShop.Add(houxuanspell[indexspell]);
            ShuaxinshopUi();
            houxuan.Clear();
            houxuanspell.Clear();
        }
        else if (shopdengji == 6)
        {
            for (int i = 0; i < 6; i++)
            {
                int index = UnityEngine.Random.Range(0, houxuan.Count);
                minionShop.Add(houxuan[index]);
            }
            int indexspell = UnityEngine.Random.Range(0, houxuanspell.Count);
            minionShop.Add(houxuanspell[indexspell]);
            ShuaxinshopUi();
            houxuan.Clear();
            houxuanspell.Clear();
        }
       Debug.Log("刷新成功");
    }

    public void shuaXinJiuGuan(int cast) 
    {
        if(zhubi<cast)
        {
            return;
        }
        else
        {
            zhubi -= cast;
            商店刷新随从();
        }
    }

    public void shengJiJiuGuan()
    {
        if (shopdengji > 5)
        {
            return;
        }
        else
        {
            shopdengji++;
            GengxindangqiandengjiUI();
            if(shopdengji == 2)
            {
                shengbenfei = 4;
            }
            else if (shopdengji == 3)
            {
                shengbenfei = 5;
            }
            else if (shopdengji == 4)
            {
                shengbenfei = 6;
            }
            else if (shopdengji == 5)
            {
                shengbenfei = 7;
            }
            else if (shopdengji == 6)
            {
                shengbenfei = 8;
            }
            GengxinshengbenfeiyongUI();
        }
    }

    void GengXinZhuBiUI()
    {
        zhubiText.text = zhubi + " / " + zhubishangxian;   // 显示成 "3 / 10"
    }

    void GengxinshengbenfeiyongUI()
    {
        shengbenfeiyong.text = shengbenfei.ToString();
    }

    void GengxindangqiandengjiUI()
    {
        dangqiandengji.text = shopdengji.ToString();
    }


    void ShuaxinshoupaiUi() 
    {
        foreach (Transform t in handArea)
        {
            Destroy(t.gameObject);
        }
        for (int i = 0; i < shouPai.Count; i++)
        {
            CardData ka = shouPai[i];
            GameObject go = Instantiate(handCardPrefab, handArea);
            go.GetComponent<Image>().sprite = ka.显示图;

            TuoKa tuo = go.GetComponent<TuoKa>();
            tuo.kaSuoYin = i;                            // 告诉卡：你是第 i 张
        }

    }
    void ShuaxinshopUi() 
    {
        foreach (Transform t in ShopArea)
        {
           // t.gameObject.SetActive(false);
            Destroy(t.gameObject);
        }
        foreach (CardData ka in minionShop)
        {
            GameObject go = Instantiate(ShopCardPrefab, ShopArea);   // 父物体 = 手牌区
            go.GetComponent<Image>().sprite = ka.显示图;
        }
    }
    void ShuaxinMyUi() 
    {
        foreach (Transform t in MyArea)
        {
            Destroy(t.gameObject);
        }
        foreach (CardData ka in mycard)
        {
            GameObject go = Instantiate(ShopCardPrefab, MyArea);   // 父物体 = 手牌区
            go.GetComponent<Image>().sprite = ka.显示图;
        }
    }

    public void HuanWei(int jiuWei, int xinWei)
    {
        CardData ka = shouPai[jiuWei];     // 1. 取出这张卡
        shouPai.RemoveAt(jiuWei);          // 2. 从旧位置删掉
        shouPai.Insert(xinWei, ka);        // 3. 插到新位置
        ShuaxinshoupaiUi();                // 4. 重建 UI（新顺序自动排好）
    }

}