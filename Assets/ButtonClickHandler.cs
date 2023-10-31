using UnityEngine;
using UnityEngine.UI;

public class ButtonClickHandler : MonoBehaviour
{
    public InputField inputField;
    public Button btnNext;
    public GameObject currentPanel;
    public GameObject nextPanelWithPwd;
    public GameObject nextPanelWithoutPwd;


    private void Start()
    {
        btnNext.onClick.AddListener(OnButtonClicked);
    }
    public void OnButtonClicked()
    {
        // Memeriksa apakah InputField kosong
        if (inputField.text.Trim() == "")
        {
            currentPanel.SetActive(false);
            nextPanelWithPwd.SetActive(false);
            nextPanelWithoutPwd.SetActive(true);
        }
        else
        {
            currentPanel.SetActive(false);
            nextPanelWithPwd.SetActive(true);
            nextPanelWithoutPwd.SetActive(false);
        }
    }
}
