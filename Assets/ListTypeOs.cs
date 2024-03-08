using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ListTypeOs : MonoBehaviour
{
    public GameObject scrollViewContent;
    public GameObject objTypeOs;
    public Button btnNext;
    public TextMeshProUGUI DescriptionText;

    void Start()
    {
        string[] operatingSystems = {
            "Windows 10 Home",
            "Windows 10 Home N",
            "Windows 10 Home Single Language",
            "Windows 10 Education",
            "Windows 10 Education N",
            "Windows 10 Pro",
            "Windows 10 Pro N",
            "Windows 10 Pro Education",
            "Windows 10 Pro Education N",
            "Windows 10 Pro for Workstations",
            "Windows 10 Pro N for Workstations"
        };

        string[] architectures = {
            "x64",
            "x64",
            "x64",
            "x64",
            "x64",
            "x64",
            "x64",
            "x64",
            "x64",
            "x64",
            "x64"
        };

        string[] dateModified = {
            "10/6/2021",
            "10/6/2021",
            "10/6/2021",
            "10/6/2021",
            "10/6/2021",
            "10/6/2021",
            "10/6/2021",
            "10/6/2021",
            "10/6/2021",
            "10/6/2021",
            "10/6/2021"
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

        btnNext.interactable = true;
        DescriptionText.text = os;

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
