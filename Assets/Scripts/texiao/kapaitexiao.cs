using UnityEngine;
using UnityEngine.EventSystems;  // 鼠标事件的接口在这
using DG.Tweening;

public class kapaitexiao : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler

{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnPointerEnter(PointerEventData e)
    {
        transform.DOScale(1.3f, 0.15f);    // 鼠标进来 → 放大到 130%
    }

    public void OnPointerExit(PointerEventData e)
    {
        transform.DOScale(1f, 0.15f);      // 鼠标离开 → 恢复原大小
    }
}
