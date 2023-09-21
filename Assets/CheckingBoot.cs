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
        startTime += Time.deltaTime;
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

    public void RestartScene()
    {
        SceneManager.LoadScene("Bios");
    }
}