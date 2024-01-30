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
    private bool pluggedMedia;

    public bool ZoomActive;
    private bool listenerAdded = false; 

    void Start()
    {
        Cam = Camera.main;
    }

    private void Update()
    {
        pluggedMedia = PlayerPrefs.GetInt("MediaIsPlugged") == 1 ? true : false;

        if (!pluggedMedia)
        {
            powerButton.enabled = false;
            // Jika listener sudah ditambahkan sebelumnya, hapus listener
            if (listenerAdded)
            {
                powerButton.onClick.RemoveListener(OnPowerButtonClicked);
                listenerAdded = false;
            }
        }
        else
        {
            powerButton.enabled = true;
            // Jika listener belum ditambahkan sebelumnya, tambahkan listener
            if (!listenerAdded)
            {
                powerButton.onClick.AddListener(OnPowerButtonClicked);
                listenerAdded = true;
            }
        }
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