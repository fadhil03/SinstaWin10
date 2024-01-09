using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BootingBios : MonoBehaviour
{
    public GameObject BIOSLogo;
    public GameObject F2text;
    public GameObject BootCanvas;
    public GameObject CheckingCanvas;

    public float startTime = 0;

    void Awake()
    {
        BIOSLogo.SetActive(false);
        F2text.SetActive(false);
        CheckingCanvas.SetActive(false);
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(2f);
        BIOSLogo.SetActive(true);
        F2text.SetActive(true);
    }

    void Update()
    {
        startTime += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.F2))
        {
            EnterBIOS();
            Debug.Log("F2 pressed!");
        }

        if (startTime > 8)
        {
            BIOSLogo.SetActive(false);
            F2text.SetActive(false);
            CheckingCanvas.SetActive(true);
        }
    }

    public void EnterBIOS()
    {
        SceneManager.LoadScene("InBios");
        Debug.Log("Entering BIOS...");
    }

}
