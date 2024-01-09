using UnityEngine;

public class DisableAfterTime : MonoBehaviour
{
    public float disableTime = 10f;
    public float activateTime = 3f;
    public GameObject objectToDisable;
    public GameObject objectToActivate;

    void Awake()
    {
        objectToActivate.SetActive(false);
        Invoke("DisableGameObject", disableTime);
        Invoke("ActivateGameObject", activateTime);
    }

    void DisableGameObject()
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
}
