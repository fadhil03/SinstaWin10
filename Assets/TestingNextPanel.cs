using UnityEngine;
using UnityEngine.UI;

public class TestingNextPanel : MonoBehaviour
{
    public GameObject currentPanel;
    public GameObject previousPanel;
    public GameObject nextPanel;

    public Button nextButton;
    public Button backButton;

    private void Start()
    {
        //nextButton = GameObject.Find("btnNext").GetComponent<Button>();
        //backButton = GameObject.Find("btnBack").GetComponent<Button>();

        nextButton.onClick.AddListener(NextButtonClicked);
        backButton.onClick.AddListener(BackButtonClicked);
    }

    private void NextButtonClicked()
    {
/*        if (nextPanel)
        {*/
            currentPanel.SetActive(false);
            nextPanel.SetActive(true);
            previousPanel.SetActive(false);
        /*}*/
    }

    private void BackButtonClicked()
    {
/*        if (previousPanel)
        {*/
            currentPanel.SetActive(false);
            nextPanel.SetActive(false);
            previousPanel.SetActive(true);
            //currentPanel = previousPanel;
       /* }*/
    }
}
