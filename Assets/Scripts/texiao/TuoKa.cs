using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class TuoKa : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    RectTransform kaRT;
    Transform jia;          // 原来的家（手牌区）
    Vector2 pianyi;         // 鼠标和卡中心的偏移

    public RectTransform shouPaiQu;      // 手牌区（Inspector 拖 HandArea）
    public RectTransform shangDianQu;    // 商店区（拖 ShopArea）
    public RectTransform zhanChangQu;    // 战场区（以后用，先留空）

    public int kaSuoYin;

    public Quyu quyu;

    

    void Awake()
    {
        kaRT = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData e)
    {
      
        jia = transform.parent;                 // 1. 记住家
        transform.SetParent(transform.root);    // 2. 脱离布局组，挂到 Canvas 下
        kaRT.localScale = Vector3.one * 1.15f;  // 3. 拖起放大一点（原版手感）

        Debug.Log("家的位置:( " + jia.position.x + ", " + jia.position.y+")");

        Vector2 shuBiaoPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)transform.parent, e.position, null, out shuBiaoPos);
        pianyi = (Vector2)kaRT.localPosition - shuBiaoPos;   // 4. 记偏移，卡不跳
    }

    public void OnDrag(PointerEventData e)
    {
        
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)transform.parent, e.position, null, out pos);
        kaRT.localPosition = pos + pianyi;     // 卡跟着鼠标（保持偏移）
    }

    public void OnEndDrag(PointerEventData e)
    {
        int xinWei = 0;
        foreach (RectTransform qiTa in jia)        // jia = 手牌区，遍历里面的卡
        {
            if (qiTa == kaRT) continue;            // 跳过自己
            if (kaRT.position.x > qiTa.position.x)
            {
                xinWei++;                          // 我的 x 比几张卡大，就排第几
            }
        }
        bool zaiShouPai = RectTransformUtility.RectangleContainsScreenPoint(
      (RectTransform)jia,   
      e.position,           
      null);
        bool luoShouPai = RectTransformUtility.RectangleContainsScreenPoint(
       shouPaiQu, e.position, null);
        bool luoShangDian = RectTransformUtility.RectangleContainsScreenPoint(
            shangDianQu, e.position, null);
        bool luoZhanChang = RectTransformUtility.RectangleContainsScreenPoint(
           zhanChangQu, e.position, null);
        transform.SetParent(jia);
        if (zaiShouPai)
        {
            Debug.Log("哈哈哈 "  );
            gamemanage gm = FindAnyObjectByType<gamemanage>();   // 找到管理器
            gm.HuanWei(quyu, kaSuoYin, xinWei);
        }
        else if(quyu==Quyu.Shop&& luoShouPai)
        {
            gamemanage gm = FindAnyObjectByType<gamemanage>();   // 找到管理器
            gm.BuyCard(kaSuoYin);
            Debug.Log("1111111");
        }
        else if (quyu == Quyu.My && luoShangDian)
        {
            gamemanage gm = FindAnyObjectByType<gamemanage>();   // 找到管理器
            gm.maisuicong(kaSuoYin);
            Debug.Log("区域: " + quyu + " → " + Quyu.Shou);
        }
        else if (quyu == Quyu.Shou && luoZhanChang) 
        {
            gamemanage gm = FindAnyObjectByType<gamemanage>();   // 找到管理器
            gm.shangchang(kaSuoYin);
            Debug.Log("区域: " + quyu + " → " + Quyu.Shou);
        }
        else
        {
            gamemanage gm = FindAnyObjectByType<gamemanage>();   // 找到管理器
            gm.HuanWei(quyu, kaSuoYin, kaSuoYin);
            Debug.Log("000000");// 重建 UI（新顺序自动排好）
        }
        kaRT.localScale = Vector3.one;         // 恢复大小
        // 布局组自动把卡排回原位，不用写代码
    }
}


public enum Quyu { Shou, Shop, My }