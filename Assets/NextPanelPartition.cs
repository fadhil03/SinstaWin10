using UnityEngine;
using UnityEngine.UI;

public class NextPanelPartition : MonoBehaviour
{
    public GameObject currentPanel;
    public GameObject previousPanel;
    public GameObject nextPanel7;
    public GameObject nextPanel7Sec;

    public Button nextButton;
    public Button backButton;

    private void Start()
    {
        nextButton.onClick.AddListener(NextButtonClicked);
        backButton.onClick.AddListener(BackButtonClicked);
    }

    private void NextButtonClicked()
    {
        currentPanel.SetActive(false);

        // Cek nilai PlayerPrefs TypeInstallation
        string typeInstallation = PlayerPrefs.GetString("TypeInstallation", "");

        // Aktifkan nextPanel7 atau nextPanel7Sec sesuai dengan nilai PlayerPrefs TypeInstallation
        if (typeInstallation == "Instalasi Baru")
        {
            nextPanel7.SetActive(true);
        }
        else if (typeInstallation == "Instalasi Ulang")
        {
            nextPanel7Sec.SetActive(true);
        }
    }

    private void BackButtonClicked()
    {
        /*if (previousPanel)
        {*/
        currentPanel.SetActive(false);
        nextPanel7.SetActive(false);
        nextPanel7Sec.SetActive(false);
        previousPanel.SetActive(true);
        //currentPanel = previousPanel;
        /* }*/
    }
}
