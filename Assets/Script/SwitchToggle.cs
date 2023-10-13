using UnityEngine;
using UnityEngine.UI;

public class SwitchToggle : MonoBehaviour
{
    [SerializeField] RectTransform uiHandleRectTransform;
    [SerializeField]  Color backgroundActiveColor;

    Image backgroundImage;
    Outline backgroundOutline;
    Text textDesc;
    Color backgroundDefaultColor;

    Toggle toggle;

    Vector2 handlePosition;
    // Start is called before the first frame update
    void Awake()
    {
        toggle = GetComponent<Toggle>();

        handlePosition = uiHandleRectTransform.anchoredPosition;

        backgroundImage = uiHandleRectTransform.parent.GetComponent<Image>();
        backgroundOutline = uiHandleRectTransform.parent.GetComponent<Outline>();

        backgroundDefaultColor = backgroundImage.color;
        textDesc = GetComponentInChildren<Text>();

        toggle.isOn = true;

        toggle.onValueChanged.AddListener(OnSwitch);
        if (toggle.isOn)
            OnSwitch(true);
    }

    void OnSwitch (bool on)
    {
        if (on)
        {
            uiHandleRectTransform.anchoredPosition = handlePosition * -1;
            backgroundImage.color = backgroundActiveColor;
            backgroundOutline.effectColor = backgroundActiveColor;
            textDesc.text = "Yes";
        }
        else
        {
            uiHandleRectTransform.anchoredPosition = handlePosition;
            backgroundImage.color = backgroundDefaultColor;
            backgroundOutline.effectColor = Color.white;
            textDesc.text = "No";
        }
            
    }

    private void OnDestroy()
    {
        toggle.onValueChanged.RemoveListener(OnSwitch);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
