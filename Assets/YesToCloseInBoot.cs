using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YesToCloseInBoot : MonoBehaviour
{
    public GameObject[] panels;
    public GameObject quitWarning;
    public GameObject changePanel;
    public Button Button;

    private void Start()
    {
        Button = GetComponent<Button>();
        Button.onClick.AddListener(NextButtonClicked);

        // Menonaktifkan semua panel yang ada dalam array panels

    }

    private void NextButtonClicked()
    {
        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }
        changePanel.SetActive(true);
        quitWarning.SetActive(false);
    }
}
