using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListTypeOs : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject scrollViewContent;
    public GameObject objTypeOs;
    public Text tvOperatingSystemText;
    public Text tvArchitecturesText;
    public Text tvDateModifiedText;

    public int listOsCount = 10;

    string[] operatingSystems = {
            "Windows 10 Home",
            "Windows 10 Pro",
            "Windows 10 Education",
            "Windows 10 Enterprise",
            "Windows 10 S",
            "Windows 10 Team",
            "Windows 10 IoT Core",
            "Windows 10 Pro for Workstations",
            "Windows 10 IoT Enterprise",
            "Windows 10 Education N"
        };

    string[] architectures = {
            "x86",
            "x64",
            "x86",
            "x64",
            "x64",
            "x64",
            "ARM",
            "x64",
            "x86",
            "x64"
        };

    string[] dateModified = {
            "01/06/2023",
            "15/05/2023",
            "22/04/2023",
            "30/03/2023",
            "12/02/2023",
            "05/01/2023",
            "18/12/2022",
            "24/11/2022",
            "07/10/2022",
            "14/09/2022"
        };

    void Start()
    {

        for (int i = 0; i < operatingSystems.Length; i++)
            {
                // Membuat GameObject baru dari prefab objTypeOs
                GameObject listOs = (GameObject)Instantiate(objTypeOs);

                // Mengatur parent GameObject ke scrollViewContent
                listOs.transform.SetParent(scrollViewContent.transform);

            // Mencari komponen teks di dalam GameObject yang baru dibuat

           // Text osText = listOs.transform.Find("tvOperatingSystem").GetComponent<Text>();
           // Text architecturesText = listOs.transform.Find("tvArchitectures").GetComponent<Text>();
           // Text dateModifiedText = listOs.transform.Find("tvDateModified").GetComponent<Text>();

            // Mengatur teks pada komponen teks sesuai dengan data dari array
           // osText.text = operatingSystems[i];
           // architecturesText.text = architectures[i];
           // dateModifiedText.text = dateModified[i];

            tvOperatingSystemText.text = operatingSystems[i];
            tvArchitecturesText.text = architectures[i];
            tvDateModifiedText.text = dateModified[i];

            listOs.transform.localScale = new Vector3(1f, 1f, 1f);
        }




        }

    // Update is called once per frame
    void Update()
    {
        
    }
}
