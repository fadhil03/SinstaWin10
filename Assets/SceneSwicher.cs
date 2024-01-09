using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwicher : MonoBehaviour
{
    public Button nextButton;
    public string nextScene;

    private void Start()
    {
        // Menambahkan fungsi callback ke tombol Next
        nextButton.onClick.AddListener(NextButtonClicked);
    }

    private void NextButtonClicked()
    {
        // Memuat scene dengan nama "InBootable"
        SceneManager.LoadScene(nextScene);
    }
}
