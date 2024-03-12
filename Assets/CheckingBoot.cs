using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class CheckingBoot : MonoBehaviour
{
    public GameObject noBootable;
    public GameObject reading;
    public GameObject enterToRestart;
    public Button btnRestart;

    public float startTime = 0;

    private InputAction enterAction;

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
        string mediaBootable = PlayerPrefs.GetString("MediaBootable", "");
        int isCopyingComplete = PlayerPrefs.GetInt("isCopyingComplete", 0);
        int isSetupComplete = PlayerPrefs.GetInt("isSetupComplete", 0);
        startTime += Time.deltaTime;

        Debug.Log("bootableValue = " + bootableValue);
        Debug.Log("mediaBootable = " + mediaBootable);

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
        else if (startTime > 3 && bootableValue == mediaBootable)
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

                // Membuat InputAction untuk tombol Enter
                if (enterAction == null)
                {
                    enterAction = new InputAction("Press Enter", InputActionType.Button, "<Keyboard>/enter");
                    enterAction.Enable();
                    enterAction.performed += _ => RestartScene(); // Menambahkan listener untuk menjalankan RestartScene saat tombol Enter ditekan
                }
            }
        }
    }

    private void OnDisable()
    {
        // Menonaktifkan InputAction saat script dinonaktifkan
        if (enterAction != null)
        {
            enterAction.Disable();
            enterAction.performed -= _ => RestartScene(); // Menghapus listener saat skrip dinonaktifkan
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene("Bios");
    }
}
