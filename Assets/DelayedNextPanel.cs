using UnityEngine;
using UnityEngine.SceneManagement;

public class DelayedNextPanel : MonoBehaviour
{
    public GameObject currentPanel;
    public GameObject nextPanel;
    public float delayTime = 8.0f;
    public string nextScene; // Nama scene yang ingin dipindahkan
    
    public void Awake()
    {
        enabled = false;
    }
    public void Start()
    {
        // Cek apakah objek saat ini aktif sebelum melakukan Invoke  
        enabled = false;
        if (currentPanel.activeSelf)
        {
            Debug.Log("Posisi if urrentPanel.activeSelf");
            Invoke("DelayedAction", delayTime);
        }
    }

    public void DelayedAction()
    {
        if (!string.IsNullOrEmpty(nextScene))
        {
            // Pindah ke scene yang ditentukan jika nextScene tidak kosong
            Debug.Log("Posisi  if (!string.IsNullOrEmpty(nextScene))");
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            // Jika nextScene kosong, lakukan perubahan panel
            Debug.Log("Posisi else");
            currentPanel.SetActive(false);
            nextPanel.SetActive(true);
        }
    }
}
