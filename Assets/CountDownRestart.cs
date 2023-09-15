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
    public bool run = false;
    public GameObject previousPanel;
    public Text tvCountdown;
    private float startTime;


    // Start is called before the first frame update
   private IEnumerator Start()
{
        Debug.Log("Status run" + run);
        if (previousPanel.activeSelf)
    {
        Debug.Log(previousPanel.name + " aktif.");
    }
    else
    {
        Debug.Log(previousPanel.name + " tidak aktif.");
            run = true;
        }
    
    yield return new WaitUntil(() => run == true);
    
    timeRemaining = maxTime;
        Debug.Log("Status run" + run);
    }

    // Update is called once per frame
    void Update()
    {
        if(timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            timerLinearImage.fillAmount = timeRemaining / maxTime;
            Debug.Log("Restarting in " + timeRemaining + " floar");
            int timeInSec = Mathf.RoundToInt(timeRemaining);
            tvCountdown.text = "Restarting in " + timeInSec + " seconds";
            Debug.Log("Restarting in " + timeInSec + " seconds");
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
