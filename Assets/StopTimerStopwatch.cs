using UnityEngine;
using TMPro;

public class StopTimerStopwatch : MonoBehaviour
{
    //public GameObject gameObjectToActivate;
    public Stopwatch stopwatch;
    public TextMeshProUGUI textMeshPro;

    public void OnEnable()
    {
        // Activate the game object
        //gameObjectToActivate.SetActive(true);

        // Stop the stopwatch if the object is not null
            stopwatch.StopTimer();

        // Read the value from textMeshPro
        string elapsedTime = textMeshPro.text;
        Debug.Log("elapsedTime = " + elapsedTime);

        // Save the value to PlayerPrefs
        PlayerPrefs.SetString("ElapsedSimulationTime", elapsedTime);
        PlayerPrefs.Save();
    }
}
