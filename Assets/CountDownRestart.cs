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
    public Button nextScene;
    private bool isDelayed = false;



    // Start is called before the first frame update
    private IEnumerator Start()
{
        //Debug.Log("Status run" + run);
        if (previousPanel.activeSelf)
    {
        //Debug.Log(previousPanel.name + " aktif.");
    }
    else
    {
        //Debug.Log(previousPanel.name + " tidak aktif.");
            run = true;
        }
    
    yield return new WaitUntil(() => run == true);
    
    timeRemaining = maxTime;
        //Debug.Log("Status run" + run);
        nextScene.onClick.AddListener(NextSceneButtonClicked);
    }

    // Update is called once per frame
    void Update()
    {
        if(timeRemaining >= 0)
        {
            timeRemaining -= Time.deltaTime;
            timerLinearImage.fillAmount = timeRemaining / maxTime;
            int timeInSec = Mathf.CeilToInt(timeRemaining);
            tvCountdown.text = "Restarting in " + timeInSec + " seconds";

/*            Debug.Log("timeRemaining: " + timeRemaining);
            Debug.Log("Time.deltaTime: " + Time.deltaTime);
            Debug.Log("timerLinearImage.fillAmount: " + timerLinearImage.fillAmount);
            Debug.Log("maxTime: " + maxTime);
            Debug.Log("timeInSec: " + timeInSec);
            Debug.Log("tvCountdown.text: " + tvCountdown.text);
            Debug.Log("=====================================");*/
        }
        else
        {
            StartCoroutine(DelayedAction());
        }
    }

    private void NextSceneButtonClicked()
    {
        // Memuat scene dengan nama "InBootable"
        SceneManager.LoadScene("Bios");
    }

    IEnumerator DelayedAction()
    {
        isDelayed = true;
        yield return new WaitForSeconds(1f); // delay 1 detik
        SceneManager.LoadScene("Bios");                                       // Eksekusi kode Anda di sini
        isDelayed = false;
    }
}
