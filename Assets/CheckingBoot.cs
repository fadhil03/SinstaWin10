using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CheckingBoot : MonoBehaviour
{
    public GameObject noBootable;
    public GameObject reading;
    public GameObject enterToRestart;
    public Button btnRestart;

    public float startTime = 0;

    void Awake()
    {
        noBootable.SetActive(false);
        enterToRestart.SetActive(false);
        Debug.Log("Namascene : " + SceneManager.GetActiveScene().name);
        btnRestart.onClick.AddListener(RestartScene);
    }

    void Update()
    {
        // Pengecekan PlayerPrefs sebelum menunggu
        string bootableValue = PlayerPrefs.GetString("ItemBootableBios", "");
        int isCopyingComplete = PlayerPrefs.GetInt("isCopyingComplete", 0);
        int isSetupComplete = PlayerPrefs.GetInt("isSetupComplete", 0);
        startTime += Time.deltaTime;

        if (startTime > 3 && isSetupComplete == 1)
        {
            // Jika isCopyingComplete adalah 1, pindah ke scene "WindowsSetup"
            SceneManager.LoadScene("AccountSetup");
        }
        else if (startTime > 3 && isCopyingComplete == 1)
        {
            // Jika isCopyingComplete adalah 1, pindah ke scene "WindowsSetup"
            SceneManager.LoadScene("WindowsSetup");
        }
        else if (startTime > 3 && bootableValue == "ItemCdrom")
        {
            // Jika PlayerPrefs sesuai, pindah ke scene "InBootable"
            SceneManager.LoadScene("InBootable");
        }
        else
        {
            // Jika PlayerPrefs tidak sesuai, lanjutkan menunggu dan tampilkan pesan
            if (startTime > 5)
            {
                Debug.Log("selesai menunggu");
                reading.SetActive(false);
                noBootable.SetActive(true);
                enterToRestart.SetActive(true);

                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
                {
                    Debug.Log("Namascene : " + SceneManager.GetActiveScene().name);
                    RestartScene();
                    Debug.Log("=================selesai restart======================= ");
                }
            }
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene("Bios");
    }
}
