using UnityEngine;

public class DisableAfterTime : MonoBehaviour
{
    public float activateTime = 3f;
    public float disableCompenent = 13f;
    public float disableAllTime = 15f;
    public GameObject objectToActivate;
    public GameObject objectToDisable;
    public GameObject objectToDisableAll;

    void Awake()
    {
        objectToActivate.SetActive(false);
        Invoke("ActivateGameObject", activateTime);
        Invoke("DisableComponentGameObject", disableCompenent);
        Invoke("DisableAllGameObject", disableAllTime);
    }

    void ActivateGameObject()
    {
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Object to activate is not assigned!");
        }
    }

    void DisableComponentGameObject()
    {
        if (objectToDisable != null)
        {
            objectToDisable.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Object to disable is not assigned!");
        }
    }

    void DisableAllGameObject()
    {
        if (objectToDisableAll != null)
        {
            objectToDisableAll.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Object to disable is not assigned!");
        }
    }
}
