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
            scrollRect.verticalNormalizedPosition = 0.8252147f;
        });
        BtnText1.onClick.AddListener(() => {
            scrollRect.verticalNormalizedPosition = 0.642906f;
        });
        BtnText2.onClick.AddListener(() => {
            scrollRect.verticalNormalizedPosition = 0.5421333f;
        });
        BtnText3.onClick.AddListener(() => {
            scrollRect.verticalNormalizedPosition = 0.4623179f;
        });
        BtnText4.onClick.AddListener(() => {
            scrollRect.verticalNormalizedPosition = 0.1479631f;
        });
        BtnText5.onClick.AddListener(() => {
            scrollRect.verticalNormalizedPosition = 0.08656542f;
        });
    }

    void Update()
    {
        Debug.Log("scrollRect.verticalNormalizedPosition = " + scrollRect.verticalNormalizedPosition);
    }

}