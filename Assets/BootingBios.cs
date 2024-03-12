using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class BootingBios : MonoBehaviour
{
    public GameObject BIOSLogo;
    public GameObject F2text;
    public GameObject BootCanvas;
    public GameObject CheckingCanvas;
    public GameObject BiosCanvas;

    public float startTime = 0;

    private InputAction f2Action;

    void Awake()
    {
        BIOSLogo.SetActive(false);
        F2text.SetActive(false);
        CheckingCanvas.SetActive(false);

        // Membuat InputAction untuk tombol F2
        f2Action = new InputAction("Press F2", InputActionType.Button, "<Keyboard>/f2");
        f2Action.Enable();
        f2Action.performed += _ => EnterBIOS(); 
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

        if (startTime > 8)
        {
            BIOSLogo.SetActive(false);
            F2text.SetActive(false);
            CheckingCanvas.SetActive(true);
            BiosCanvas.SetActive(false);
        }
    }

    public void EnterBIOS()
    {
        SceneManager.LoadScene("InBios");
        Debug.Log("Entering BIOS...");
    }

    private void OnDisable()
    {
        // Menonaktifkan InputAction saat script dinonaktifkan
        f2Action.Disable();
    }
}
