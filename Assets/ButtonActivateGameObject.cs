using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonActivateGameObject : MonoBehaviour
{
    public GameObject gameObjectToActivate;
    private Button Button;

    private void Start()
    {
        Button = GetComponent<Button>();
        Button.onClick.AddListener(ActivateGameObject);
    }

    private void ActivateGameObject()
    {
        gameObjectToActivate.SetActive(true);
    }


}
