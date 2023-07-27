using UnityEngine;
using UnityEngine.UI;

public class NextPanel : MonoBehaviour
{
    public GameObject[] panels; // Array untuk menyimpan semua panel yang ingin dinonaktifkan

    public GameObject currentPanel;
    public GameObject nextPanel;

    private Button nextButton;

    private void Start()
    {
        nextButton = GetComponent<Button>();
        nextButton.onClick.AddListener(NextButtonClicked);

        // Menonaktifkan semua panel yang ada dalam array panels
        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }
    }

    private void NextButtonClicked()
    {
        currentPanel.SetActive(false);
        nextPanel.SetActive(true);
    }
}
