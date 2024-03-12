using UnityEngine;

public class BiosGuideManager : MonoBehaviour
{
    public GameObject[] Task1;
    public GameObject[] copycomplete;
    public GameObject[] setupcomplete;

    void Start()
    {
        int isCopyingComplete = PlayerPrefs.GetInt("isCopyingComplete");
        int isSetupComplete = PlayerPrefs.GetInt("isSetupComplete");

        if (isSetupComplete == 1)
        {
            foreach (GameObject obj in copycomplete)
            {
                obj.SetActive(false);
            }

            foreach (GameObject obj in Task1)
            {
                obj.SetActive(false);
            }

            foreach (GameObject obj in setupcomplete)
            {
                obj.SetActive(true);
            }
        }
        else if (isCopyingComplete == 1)
        {
            foreach (GameObject obj in copycomplete)
            {
                obj.SetActive(true);
            }

            foreach (GameObject obj in Task1)
            {
                obj.SetActive(false);
            }

            foreach (GameObject obj in setupcomplete)
            {
                obj.SetActive(false);
            }
        }
        else
        {
            foreach (GameObject obj in copycomplete)
            {
                obj.SetActive(false);
            }

            foreach (GameObject obj in Task1)
            {
                obj.SetActive(true);
            }

            foreach (GameObject obj in setupcomplete)
            {
                obj.SetActive(false);
            }
        }
    }
}
