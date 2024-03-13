using UnityEngine;
using UnityEngine.UI;

public class ShowOnMobile : MonoBehaviour
{
    public Button openCloseButton;
    private bool isOpen = true; // Inisialisasi isOpen ke true
    private Text buttonText;
    private RectTransform rectTransform;

    void Start()
    {
        gameObject.SetActive(Application.isMobilePlatform);

        // Mendapatkan nilai bootableValue dan mediaBootable
        string bootableValue = PlayerPrefs.GetString("ItemBootableBios", "");
        string mediaBootable = PlayerPrefs.GetString("MediaBootable", "");

        // Mengubah nilai isOpen menjadi false jika bootableValue sama dengan mediaBootable
        if (bootableValue == mediaBootable)
        {
            isOpen = false;
        }

        // Mendapatkan komponen Text dari button
        buttonText = openCloseButton.GetComponentInChildren<Text>();

        // Menentukan teks awal sesuai dengan nilai isOpen
        buttonText.text = isOpen ? ">" : "<";

        // Menambahkan listener untuk openCloseButton
        openCloseButton.onClick.AddListener(() =>
        {
            // Mengubah nilai isOpen berdasarkan nilai sebelumnya
            isOpen = !isOpen;

            // Mengubah teks button sesuai dengan nilai isOpen
            buttonText.text = isOpen ? ">" : "<";
        });

        // Mendapatkan komponen RectTransform
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        // Mengubah posisi RectTransform berdasarkan nilai isOpen
        if (isOpen)
        {
            rectTransform.anchoredPosition = new Vector2(-180f, rectTransform.anchoredPosition.y);
        }
        else
        {
            rectTransform.anchoredPosition = new Vector2(150f, rectTransform.anchoredPosition.y);
        }
    }
}
