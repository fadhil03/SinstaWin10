using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoverPanel : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        PlayerPrefs.SetInt("isSetupComplete", 1); 
    }
}
