using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootingBios : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject BIOSLogo; // Drag your BIOS logo GameObject here
    public GameObject F2text;
    public GameObject BootCanvas;
    public GameObject BiosCanvas;
    public GameObject CheckingCanvas;

    private IEnumerator Start()
    {
        BIOSLogo.SetActive(false);
        F2text.SetActive(false);
        BiosCanvas.SetActive(false); 
        CheckingCanvas.SetActive(false);
        yield return new WaitForSeconds(2f);
        BIOSLogo.SetActive(true);
        F2text.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F2))
        {
            EnterBIOS();
            Debug.Log("F2 pressed!");
        }

        if (Time.time > 8)
        {
            BootCanvas.SetActive(false);
            CheckingCanvas.SetActive(true);
        }

    }

    public void EnterBIOS()
    {
        BootCanvas.SetActive(false);
        BiosCanvas.SetActive(true);
        Debug.Log("Entering BIOS...");
    }


}
