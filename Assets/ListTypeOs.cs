using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListTypeOs : MonoBehaviour
{
    public GameObject scrollViewContent;
    public GameObject objTypeOs;

    void Start()
    {
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

        for (int i = 0; i < operatingSystems.Length; i++)
        {
            // Membuat GameObject baru dari prefab objTypeOs
            GameObject listOs = Instantiate(objTypeOs);

            // Mengatur parent GameObject ke scrollViewContent
            listOs.transform.SetParent(scrollViewContent.transform);

            // Menggunakan GetChild untuk menemukan komponen Text
            Text osText = listOs.transform.GetChild(0).GetComponent<Text>();
            Text architecturesText = listOs.transform.GetChild(1).GetComponent<Text>();
            Text dateModifiedText = listOs.transform.GetChild(2).GetComponent<Text>();

            // Mengatur nilai teks pada komponen Text sesuai dengan index
            osText.text = operatingSystems[i];
            architecturesText.text = architectures[i];
            dateModifiedText.text = dateModified[i];

            listOs.transform.localScale = new Vector3(1f, 1f, 1f);

            // Menambahkan event listener untuk menanggapi klik pada objek
            listOs.GetComponent<Button>().onClick.AddListener(() => OnListOsClick(osText.text, architecturesText.text, dateModifiedText.text));
        }
    }

    void OnListOsClick(string os, string architectures, string dateModified)
    {
        // Menyimpan data terkait objek yang terklik ke dalam PlayerPrefs
        PlayerPrefs.SetString("SelectedOS", os);
        PlayerPrefs.SetString("SelectedArchitectures", architectures);
        PlayerPrefs.SetString("SelectedDateModified", dateModified);

        // Contoh: Menampilkan data yang disimpan pada PlayerPrefs
        Debug.Log("Selected OS: " + PlayerPrefs.GetString("SelectedOS"));
        Debug.Log("Selected Architectures: " + PlayerPrefs.GetString("SelectedArchitectures"));
        Debug.Log("Selected Date Modified: " + PlayerPrefs.GetString("SelectedDateModified"));
    }

    // Update is called once per frame
    void Update()
    {
        // Update logic (jika diperlukan)
    }
}
