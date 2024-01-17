using UnityEngine;
using UnityEngine.UI;

public class ChangePanel : MonoBehaviour
{
    public GameObject[] panels;
    public GameObject currentPanel;
    public GameObject changePanel;
    private Button Button;

    private void Start()
    {
        Button = GetComponent<Button>();
        Button.onClick.AddListener(NextButtonClicked);

        // Menonaktifkan semua panel yang ada dalam array panels
        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }
    }

    private void NextButtonClicked()
    {
        currentPanel.SetActive(false);
        changePanel.SetActive(true);
    }
}
