using UnityEngine;
using UnityEngine.UI;

public class DisableQuitWarning : MonoBehaviour
{
    public GameObject quitWarning; // Objek QuitWarning
    public Button button; // Tombol untuk menonaktifkan QuitWarning

    void Start()
    {
        // Menambahkan listener ke tombol untuk menonaktifkan QuitWarning saat diklik
        button.onClick.AddListener(DisableQuitWarningObject);
    }

    public void DisableQuitWarningObject()
    {
        // Menonaktifkan game object QuitWarning jika sudah didapatkan referensinya
        if (quitWarning != null)
        {
            quitWarning.SetActive(false);
        }
        else
        {
            Debug.LogError("QuitWarning game object is not found!");
        }
    }
}
