using UnityEngine;
using UnityEngine.UI;

public class toPanel3 : MonoBehaviour
{
    public GameObject panel2;
    public GameObject panel3;

    private Button nextButton;

    private void Start()
    {
        nextButton = GetComponent<Button>();
        nextButton.onClick.AddListener(NextButtonClicked);
    }

    private void NextButtonClicked()
    {
        panel2.SetActive(false);
        panel3.SetActive(true);
    }
}
