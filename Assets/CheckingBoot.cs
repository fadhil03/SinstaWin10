using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CheckingBoot : MonoBehaviour
{
    public GameObject noBootable;
    public GameObject reading;
    public GameObject enterToRestart;

    public float startTime = 0;

    void Awake()
    {
        noBootable.SetActive(false);
        enterToRestart.SetActive(false);
        Debug.Log("Namascene : " + SceneManager.GetActiveScene().name);
    }

    void Update()
    {
        startTime += Time.deltaTime;
        if (startTime > 15)
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
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("InBootable");
    }
}