using UnityEngine;
using UnityEngine.UI;

public class ListenerChoseBootable : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public GameObject usb;
    public GameObject disc;

    void Start()
    {
        if (button1 != null)
        {
            button1.onClick.AddListener(OnClickButton1);
        }
        else
        {
            Debug.LogError("Button 1 belum ditetapkan!");
        }

        if (button2 != null)
        {
            button2.onClick.AddListener(OnClickButton2);
        }
        else
        {
            Debug.LogError("Button 2 belum ditetapkan!");
        }
    }

    void OnClickButton1()
    {
        PlayerPrefs.SetString("MediaBootable", "RemovableDevices");
        usb.SetActive(true);
        disc.SetActive(false);
        Debug.Log("PlayerPrefs key 'MediaBootable' diatur ke nilai 'RemovableDevices'");
    }

    void OnClickButton2()
    {
        PlayerPrefs.SetString("MediaBootable", "CDRomDrive");
        usb.SetActive(false);
        disc.SetActive(true);
        Debug.Log("PlayerPrefs key 'MediaBootable' diatur ke nilai 'CDRomDrive'");
    }
}
