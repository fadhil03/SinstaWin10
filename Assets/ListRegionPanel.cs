using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListRegionPanel : MonoBehaviour
{
    public GameObject scrollViewContent;
    public GameObject objRegion;
    public Button nextButton;
    //public Text tvChild;

    //public int listRegionCount = 70;

    string[] regionList = {
            "Afghanistan", "Albania", "Algeria",
                "Bahamas", "Bahrain", "Bangladesh",
                "Cambodia", "Cameroon", "Canada",
                "Denmark", "Djibouti", "Dominica",
                "Egypt", "El Salvador", "Equatorial Guinea",
                "Fiji", "Finland", "France",
                "Gabon", "Gambia", "Georgia",
                "Haiti", "Honduras", "Hungary",
                "Iceland", "India", "Indonesia",
                "Jamaica", "Japan", "Jordan",
                "Kazakhstan", "Kenya", "Kiribati",
                "Laos", "Latvia", "Lebanon",
                "Macedonia", "Madagascar", "Malawi",
                "Namibia", "Nauru", "Nepal",
                "Oman",
                "Pakistan", "Palau", "Panama",
                "Qatar",
                "Romania", "Russia", "Rwanda",
                "Samoa", "San Marino", "Saudi Arabia",
                "Tajikistan", "Tanzania", "Thailand",
                "Uganda", "Ukraine", "United Arab Emirates",
                "Vanuatu", "Vatican City", "Venezuela",
                "Yemen",
                "Zambia", "Zimbabwe"
        };


    void Start()
    {
        Color normalColor = new Color32(0, 66, 117, 255); // #004275
        Color pressedAndSelectedColor = new Color32(0, 98, 176, 255); // #0062b0

        for (int i = 0; i < regionList.Length; i++)
        {
            GameObject listRegion = Instantiate(objRegion, scrollViewContent.transform);
            listRegion.transform.localPosition = Vector3.zero;

            Text childText = listRegion.GetComponentInChildren<Text>();
            if (childText != null)
            {
                childText.text = regionList[i];
            }

            Button button = listRegion.GetComponent<Button>();
            if (button != null)
            {
                ColorBlock colors = button.colors;
                colors.normalColor = normalColor;
                colors.pressedColor = pressedAndSelectedColor;
                colors.selectedColor = pressedAndSelectedColor;
                button.colors = colors;

                // Menambahkan event listener untuk tombol
                int index = i; // Simpan indeks agar bisa diakses dalam event listener
                button.onClick.AddListener(() => OnRegionButtonClick(regionList[index]));
            }

            Debug.Log("Index: " + i + ", Country: " + regionList[i]);
            listRegion.transform.localScale = Vector3.one;
        }
    }

    // Fungsi untuk menangani klik tombol region
    void OnRegionButtonClick(string region)
    {
        // Simpan nilai region ke dalam PlayerPrefs
        PlayerPrefs.SetString("Region", region);
        Debug.Log("Selected Region: " + region);

        // Panggil metode untuk memeriksa apakah tombol next harus diaktifkan
        CheckNextButtonInteractable();
    }

    // Metode untuk memeriksa apakah tombol next harus diaktifkan
    void CheckNextButtonInteractable()
    {
        // Cek apakah nilai Region telah diset di PlayerPrefs
        if (PlayerPrefs.HasKey("Region"))
        {
            // Jika telah diset, aktifkan tombol next
            nextButton.interactable = true;
        }
        else
        {
            // Jika belum diset, jadikan tombol next tidak interaktif
            nextButton.interactable = false;
        }
    }
}
