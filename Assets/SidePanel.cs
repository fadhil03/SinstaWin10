using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SidePanel : MonoBehaviour
{
    public GameObject PanelBrief;
    public GameObject PanelConfirmEnd;

    public Button ButtonOpenSidePanel;
    public Button ButtonCloseSidePanel;
    public Button ButtonEnd;
    public Button ButtonYesEnd;
    public Button ButtonNoEnd;

    private bool isOpen = false; 
    void Start()
    {
        isOpen = PlayerPrefs.GetInt("IsSidePanelOpen", 0) == 1;

        if (isOpen)
        {
            OpenPanelBrief();
        }
        else
        {
            ClosePanelBrief();
        }

        ButtonOpenSidePanel.onClick.AddListener(OpenPanelBrief);
        ButtonCloseSidePanel.onClick.AddListener(ClosePanelBrief);
        ButtonEnd.onClick.AddListener(ActiveConfirmEnd);
    }

    void OpenPanelBrief()
    {
        isOpen = true; 
        PlayerPrefs.SetInt("IsSidePanelOpen", isOpen ? 1 : 0); 
        PlayerPrefs.Save();

        ButtonOpenSidePanel.interactable = false;
        ButtonOpenSidePanel.gameObject.SetActive(false);
        ButtonCloseSidePanel.interactable = true;
        ButtonCloseSidePanel.gameObject.SetActive(true);
        PanelBrief.SetActive(true);
    }

    void ClosePanelBrief()
    {
        isOpen = false;
        PlayerPrefs.SetInt("IsSidePanelOpen", isOpen ? 1 : 0);
        PlayerPrefs.Save();

        ButtonOpenSidePanel.interactable = true;
        ButtonOpenSidePanel.gameObject.SetActive(true);
        ButtonCloseSidePanel.interactable = false;
        ButtonCloseSidePanel.gameObject.SetActive(false);
        PanelBrief.SetActive(false);
    }

    void ActiveConfirmEnd()
    {
        PanelConfirmEnd.SetActive(true);
        ButtonYesEnd.onClick.AddListener(() => SceneManager.LoadScene("MainMenu"));
        ButtonNoEnd.onClick.AddListener(() => PanelConfirmEnd.SetActive(false));
    }
}
