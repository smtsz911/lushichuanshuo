
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class gamemanage : MonoBehaviour
{
    public static int zhubishangxian = 3;
    public static int zhubi = 100;


   

    public Image[] shopCardImages;

    public MinionData[] minionMy;

    public SpellData[] spellAll;

    public SpellData[] spellShop;

    public SpellData[] spellMy;

    public  int shopdengji=1;

    public int shengbenfei = 3;

    public int maiCardCost = 3;
    public int sxcost = 1;

    public List<CardData> shouPai = new List<CardData>();
    List<MinionData> houxuan = new List<MinionData>();

    public List<SpellData> houxuanspell = new List<SpellData>();

    public List<CardData> minionAll = new List<CardData>();
    public List<CardData> minionShop = new List<CardData>();

    public List<CardData> mycard = new List<CardData>();
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
        商店刷新随从();
    }
    void spendZhubi(int cost)
    {
        zhubi -= cost;
        GengXinZhuBiUI();
    }

    public void shuxinjiuguan() 
    {
        if (zhubi < shengbenfei)
        {
            Debug.Log("金币不足");
            return;
        }
        else
        {
            spendZhubi(shengbenfei);
            商店刷新随从();
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

    public void shengben() 
    {
        if (zhubi < shengbenfei)
            return;
        else 
        {
            spendZhubi(shengbenfei);
            shengJiJiuGuan();
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
            tuo.quyu = Quyu.Shou;
            tuo.shouPaiQu = (RectTransform)handArea;     // 新增：给区域赋值
            tuo.shangDianQu = (RectTransform)ShopArea;   // 新增
            tuo.zhanChangQu = (RectTransform)MyArea;
        }

    }
    void ShuaxinshopUi() 
    {
        foreach (Transform t in ShopArea)
        {
            Destroy(t.gameObject);
        }
        for (int i = 0; i < minionShop.Count; i++)
        {
            CardData ka = minionShop[i];
            GameObject go = Instantiate(handCardPrefab, ShopArea);
            go.GetComponent<Image>().sprite = ka.显示图;

            TuoKa tuo = go.GetComponent<TuoKa>();
            tuo.kaSuoYin = i;                            // 告诉卡：你是第 i 张
            tuo.quyu = Quyu.Shop;
            tuo.shouPaiQu = (RectTransform)handArea;     // 新增：给区域赋值
            tuo.shangDianQu = (RectTransform)ShopArea;   // 新增
            tuo.zhanChangQu = (RectTransform)MyArea;
        }
    }
    void ShuaxinMyUi() 
    {
        foreach (Transform t in MyArea)
        {
            Destroy(t.gameObject);
        }
        for (int i = 0; i < mycard.Count; i++)
        {
            CardData ka = mycard[i];
            GameObject go = Instantiate(handCardPrefab, MyArea);
            go.GetComponent<Image>().sprite = ka.显示图;

            TuoKa tuo = go.GetComponent<TuoKa>();
            tuo.kaSuoYin = i;                            // 告诉卡：你是第 i 张
            tuo.quyu = Quyu.My;
            tuo.shouPaiQu = (RectTransform)handArea;     // 新增：给区域赋值
            tuo.shangDianQu = (RectTransform)ShopArea;   // 新增
            tuo.zhanChangQu = (RectTransform)MyArea;
        }
    }

    public void HuanWei(Quyu yu, int jiuWei, int xinWei)
    {
       
        if (yu == Quyu.Shou)
        {
            CardData ka = shouPai[jiuWei];     // 1. 取出这张卡
            shouPai.RemoveAt(jiuWei);          // 2. 从旧位置删掉
            shouPai.Insert(xinWei, ka);
            ShuaxinshoupaiUi();
        }            // 4. 重建 UI（新顺序自动排好）
        else if (yu == Quyu.Shop)
        {
            CardData ka = minionShop[jiuWei];     // 1. 取出这张卡
            minionShop.RemoveAt(jiuWei);          // 2. 从旧位置删掉
            minionShop.Insert(xinWei, ka);
            ShuaxinshopUi();
        }
        else if (yu == Quyu.My)
        {
            CardData ka = mycard[jiuWei];     // 1. 取出这张卡
            mycard.RemoveAt(jiuWei);          // 2. 从旧位置删掉
            mycard.Insert(xinWei, ka);
            ShuaxinMyUi();
        }
    }


    public void BuyCard(int kasuoyin)
    {
        if (zhubi < maiCardCost)
        {
            Debug.Log("金币不足");
            return;
        }
        else
        {
            Debug.Log("购买成功");
            CardData ka = minionShop[kasuoyin];     // 1. 取出这张卡
            minionShop.RemoveAt(kasuoyin);
            shouPai.Add(ka);
            spendZhubi(maiCardCost);
            ShuaxinshopUi();
            ShuaxinshoupaiUi();
        }
    }

    public void shangchang(int kasuoyin) 
    {
        CardData ka = shouPai[kasuoyin];     // 1. 取出这张卡
        shouPai.RemoveAt(kasuoyin);
        mycard.Add(ka);
        ShuaxinshoupaiUi();
        ShuaxinMyUi();
    }
    public void maisuicong(int kasuoyin) 
    {
        CardData ka = mycard[kasuoyin];     // 1. 取出这张卡
        shouPai.RemoveAt(kasuoyin);
        minionAll.Add(ka);
        ShuaxinMyUi();
    }
}