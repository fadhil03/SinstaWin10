using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonSceneChanger : MonoBehaviour
{
    public Button button; // Tombol untuk memicu pergantian scene
    public string sceneName; // Nama scene yang akan dituju, bisa diatur melalui Inspector

    private void Start()
    {
        // Mengecek apakah tombol sudah ditetapkan
        if (button != null)
        {
            // Menambahkan listener ke event onClick tombol
            button.onClick.AddListener(ChangeScene);
        }
        else
        {
            Debug.LogError("Button reference is not set!");
        }
    }

    public void ChangeScene()
    {
        // Memastikan ada nama scene yang dituju
        if (!string.IsNullOrEmpty(sceneName))
        {
            // Memuat scene yang ditentukan
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("Scene name is not set!");
        }
    }
}
