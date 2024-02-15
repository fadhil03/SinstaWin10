using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScrollViewLinker : MonoBehaviour
{
    public ScrollRect scrollRect;
    public Button BtnTextP;
    public Button BtnText1;
    public Button BtnText2;
    public Button BtnText3;
    public Button BtnText4;
    public Button BtnText5;

    void Start()
    {
        BtnTextP.onClick.AddListener(() => {
            scrollRect.verticalNormalizedPosition = 0.7711341f;
        });
        BtnText1.onClick.AddListener(() => {
            scrollRect.verticalNormalizedPosition = 0.6610773f;
        });
        BtnText2.onClick.AddListener(() => {
            scrollRect.verticalNormalizedPosition = 0.5748576f;
        });
        BtnText3.onClick.AddListener(() => {
            scrollRect.verticalNormalizedPosition = 0.4984854f;
        });
        BtnText4.onClick.AddListener(() => {
            scrollRect.verticalNormalizedPosition = 0.1252235f;
        });
        BtnText5.onClick.AddListener(() => {
            scrollRect.verticalNormalizedPosition = 0.0683595f;
        });
    }

    private void Update()
    {
        Debug.Log("scrollRect.verticalNormalizedPosition = " + scrollRect.verticalNormalizedPosition);
    }

    public void ScrollToTugas1()
    {
        //ScrollTo(TextIsiTugas1);
        Debug.Log("TextIsiTugas1");
        scrollRect.verticalNormalizedPosition = 0.7572725f;
    }

    public void ScrollToTugas2()
    {
        // ScrollTo(TextIsiTugas2);
        Debug.Log("TextIsiTugas2");
        scrollRect.verticalNormalizedPosition = 0.6499775f;
    }

    public void ScrollToTugas3()
    {
        // ScrollTo(TextIsiTugas3);
        Debug.Log("TextIsiTugas3");
        scrollRect.verticalNormalizedPosition = 0.5660478f;
    }


  
}