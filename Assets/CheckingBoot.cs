using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CheckingBoot : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject noBootable;
    public GameObject reading;
    public GameObject enterToRestart;
    void Start()
    {
        noBootable.SetActive(false);
        enterToRestart.SetActive(false);
        Debug.Log("Namascene : " + SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > 15)
        {
            Debug.Log("selesai menunggu");
            reading.SetActive(false);
            noBootable.SetActive(true);
            enterToRestart.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                Debug.Log("Namascene : " + SceneManager.GetActiveScene().name);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                //RestartScene();
                Debug.Log("=================selesai restart======================= ");
            }
        }
    }

    public void RestartScene()
    {
        // Mendapatkan nama scene yang sedang aktif
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Memuat ulang scene yang sedang aktif
        SceneManager.LoadScene("Bios");
    }

}
