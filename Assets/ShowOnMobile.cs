using UnityEngine;
using UnityEngine.UI;

public class ShowOnMobile : MonoBehaviour
{
    public Button openCloseButton;
    private bool isOpen = true; // Inisialisasi isOpen ke true
    private Text buttonText;

    void Start()
    {
        //gameObject.SetActive(Application.isMobilePlatform);

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

            // Mengubah posisi RectTransform berdasarkan nilai isOpen
            RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
            if (isOpen)
            {
                rectTransform.anchoredPosition = new Vector2(-180f, rectTransform.anchoredPosition.y);
            }
            else
            {
                rectTransform.anchoredPosition = new Vector2(150f, rectTransform.anchoredPosition.y);
            }
        });
    }
}
