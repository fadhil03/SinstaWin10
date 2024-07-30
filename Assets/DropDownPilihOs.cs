using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropDownPilihOs : MonoBehaviour
{
    public TextMeshProUGUI outputText;
    public GameObject ContainerInfoSoon;
    public GameObject ContainerButtonwin10;

    public void HandleInputData(int val)
    {
        if (val == 0)
        {
            ContainerButtonwin10.SetActive(true);
            ContainerInfoSoon.SetActive(false);
            outputText.text = "";
        }
        if (val == 1)
        {
            ContainerButtonwin10.SetActive(false);
            ContainerInfoSoon.SetActive(true);
            outputText.text = "Simulasi Instalasi untuk Windows 11 saat ini belum tersedia\n<i>Coming soon...</i>";

        }
        if (val == 2)
        {
            ContainerButtonwin10.SetActive(false);
            ContainerInfoSoon.SetActive(true);
            outputText.text = "Simulasi Instalasi untuk Linux Debian saat ini belum tersedia\n<i>Coming soon...</i>";
        }
        if (val == 3)
        {
            ContainerButtonwin10.SetActive(false);
            ContainerInfoSoon.SetActive(true);
            outputText.text = "Simulasi Instalasi untuk Linux Ubuntu saat ini belum tersedia\n<i>Coming soon...</i>";
        }
        if (val == 4)
        {
            ContainerButtonwin10.SetActive(false);
            ContainerInfoSoon.SetActive(true);
            outputText.text = "Nantikan Simulasi Instalasi yang akan datang\n<i>Coming soon...</i>";
        }


    }
}
