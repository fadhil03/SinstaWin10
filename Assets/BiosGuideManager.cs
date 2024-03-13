using UnityEngine;

public class BiosGuideManager : MonoBehaviour
{
    public GameObject[] Task1;
    public GameObject[] setBootable;
    public GameObject[] copycomplete;
    public GameObject[] setupcomplete;

    void Start()
    {
        int isCopyingComplete = PlayerPrefs.GetInt("isCopyingComplete");
        int isSetupComplete = PlayerPrefs.GetInt("isSetupComplete");
        string bootableValue = PlayerPrefs.GetString("ItemBootableBios", "");
        string mediaBootable = PlayerPrefs.GetString("MediaBootable", "");

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

            foreach (GameObject obj in setBootable)
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

            foreach (GameObject obj in setBootable)
            {
                obj.SetActive(false);
            }

            foreach (GameObject obj in setupcomplete)
            {
                obj.SetActive(false);
            }
        }
        else if (bootableValue == mediaBootable)
        {
            foreach (GameObject obj in copycomplete)
            {
                obj.SetActive(false);
            }

            foreach (GameObject obj in Task1)
            {
                obj.SetActive(false);
            }

            foreach (GameObject obj in setBootable)
            {
                obj.SetActive(true);
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

            foreach (GameObject obj in setBootable)
            {
                obj.SetActive(false);
            }

            foreach (GameObject obj in setupcomplete)
            {
                obj.SetActive(false);
            }
        }
    }
}
