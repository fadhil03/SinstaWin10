using UnityEngine;
using UnityEngine.UI;

public class next1 : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;

    private Button nextButton;

    private void Start()
    {
        nextButton = GetComponent<Button>();
        nextButton.onClick.AddListener(NextButtonClicked);
    }

    private void NextButtonClicked()
    {
        panel1.SetActive(false);
        panel2.SetActive(true);
    }
}
