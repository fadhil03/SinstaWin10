using UnityEngine;
using UnityEngine.UI;

public class ButtonColorChange : MonoBehaviour
{
    private Button button;
    private Text buttonText;

    // Start is called before the first frame update
    void Start()
    {
        // Mendapatkan referensi ke Button dan Text pada GameObject ini
        button = GetComponent<Button>();
        buttonText = GetComponentInChildren<Text>();

        // Memanggil fungsi untuk mengatur warna awal
        UpdateTextColor();
    }

    // Update is called once per frame
    void Update()
    {
        // Memanggil fungsi untuk memperbarui warna teks berdasarkan interactivity status button
        UpdateTextColor();
    }

    void UpdateTextColor()
    {
        // Jika button tidak interactable, atur warna teks ke abu-abu
        // Jika button interactable, atur warna teks ke hitam
        if (button.interactable)
        {
            buttonText.color = Color.black;
        }
        else
        {
            buttonText.color = Color.gray;
        }
    }
}
