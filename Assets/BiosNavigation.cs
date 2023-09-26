using UnityEngine;
using UnityEngine.UI;

public class BiosNavigation : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject advancedPanel;
    public GameObject securityPanel;
    public GameObject bootPanel;
    public GameObject exitPanel;

    public Button mainButton;
    public Button advancedButton;
    public Button securityButton;
    public Button bootButton;
    public Button exitButton;

    private GameObject currentPanel;

    private void Start()
    {
        // Panel awal yang aktif adalah MainPanel
        currentPanel = mainPanel;
        currentPanel.SetActive(true);

        // Mengatur warna tombol dan teks untuk panel awal (MainPanel)
        SetButtonColors(mainButton, true);
        SetButtonColors(advancedButton, false);
        SetButtonColors(securityButton, false);
        SetButtonColors(bootButton, false);
        SetButtonColors(exitButton, false);
    }

    private void Update()
    {
        // Navigasi ke kiri (Previous)
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("Tombol kiri ditekan");
            NavigateToPreviousPanel();
        }
        // Navigasi ke kanan (Next)
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("Tombol kanan ditekan");
            NavigateToNextPanel();
        }
    }

    private void NavigateToNextPanel()
    {
        currentPanel.SetActive(false);

        if (currentPanel == mainPanel)
        {
            currentPanel = advancedPanel;
            SetButtonColors(mainButton, false);
            SetButtonColors(advancedButton, true);
        }
        else if (currentPanel == advancedPanel)
        {
            currentPanel = securityPanel;
            SetButtonColors(advancedButton, false);
            SetButtonColors(securityButton, true);
        }
        else if (currentPanel == securityPanel)
        {
            currentPanel = bootPanel;
            SetButtonColors(securityButton, false);
            SetButtonColors(bootButton, true);
        }
        else if (currentPanel == bootPanel)
        {
            currentPanel = exitPanel;
            SetButtonColors(bootButton, false);
            SetButtonColors(exitButton, true);
        }
        else if (currentPanel == exitPanel)
        {
            currentPanel = exitPanel;
        }

        currentPanel.SetActive(true);
    }

    private void NavigateToPreviousPanel()
    {
        currentPanel.SetActive(false);

        if (currentPanel == mainPanel)
        {
            currentPanel = mainPanel;
        }
        else if (currentPanel == advancedPanel)
        {
            currentPanel = mainPanel;
            SetButtonColors(advancedButton, false);
            SetButtonColors(mainButton, true);
        }
        else if (currentPanel == securityPanel)
        {
            currentPanel = advancedPanel;
            SetButtonColors(securityButton, false);
            SetButtonColors(advancedButton, true);
        }
        else if (currentPanel == bootPanel)
        {
            currentPanel = securityPanel;
            SetButtonColors(bootButton, false);
            SetButtonColors(securityButton, true);
        }
        else if (currentPanel == exitPanel)
        {
            currentPanel = bootPanel;
            SetButtonColors(exitButton, false);
            SetButtonColors(bootButton, true);
        }

        currentPanel.SetActive(true);
    }

    private void SetButtonColors(Button button, bool isActive)
    {
        ColorBlock colorBlock = button.colors;
        Color normalColor, textColor;

        if (isActive)
        {
            normalColor = new Color32(0xBB, 0xBB, 0xBB, 0xFF);
            textColor = new Color32(0x00, 0x00, 0xAA, 0xFF);
        }
        else
        {
            normalColor = new Color32(0x00, 0x00, 0xAA, 0xFF);
            textColor = new Color32(0xBB, 0xBB, 0xBB, 0xFF);
        }

        colorBlock.normalColor = normalColor;
        button.colors = colorBlock;

        Text buttonText = button.GetComponentInChildren<Text>();
        if (buttonText)
        {
            buttonText.color = textColor;
        }
    }
}
