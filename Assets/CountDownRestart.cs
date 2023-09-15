using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDownRestart : MonoBehaviour
{
    public Image timerLinearImage;
    float timeRemaining;
    public float maxTime = 5.0f;
    public string Bios;
    private float startTime;


    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        timeRemaining = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeRemaining > 0)
        {
            float elapsedTime = Time.time - startTime;
            timeRemaining -= elapsedTime;
            timerLinearImage.fillAmount = timeRemaining / maxTime;
        }
        else
        {
            //SceneManager.LoadScene(Bios);
        }
    }

    private void OnEnable()
    {
        
    }
}
