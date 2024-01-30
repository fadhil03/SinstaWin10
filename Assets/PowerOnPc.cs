using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PowerOnPc : MonoBehaviour
{
    public Button powerButton;
    public Camera Cam;
    public Vector3[] Target;
    public float Speed;

    public bool ZoomActive;

    void Start()
    {
        if (powerButton != null)
        {
            powerButton.onClick.AddListener(OnPowerButtonClicked);
        }
        else
        {
            Debug.LogError("Power button is not assigned!");
        }

        Cam = Camera.main;
    }

    void LateUpdate()
    {
        if (ZoomActive)
        {
            Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 1.38f, Speed);
            Cam.transform.position = Vector3.Lerp(Cam.transform.position, Target[1], Speed);
        }
        else
        {
            Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 4.472006f, Speed);
            Cam.transform.position = Vector3.Lerp(Cam.transform.position, Target[0], Speed);
        }
    }

    void OnPowerButtonClicked()
    {
        StartCoroutine(LoadSceneAfterDelay());
    }

    IEnumerator LoadSceneAfterDelay()
    {
        ZoomActive = true;
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("Bios");
    }
}