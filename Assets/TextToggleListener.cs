using UnityEngine;
using UnityEngine.UI;

public class TextToggleListener : MonoBehaviour
{
    [SerializeField] private Toggle toggle; // Toggle yang akan dimonitor
    [SerializeField] private Text textComponent; // Komponen Text yang akan diubah
    [SerializeField] private string textWhenToggleOn = "Is On Text"; // Teks ketika toggle aktif
    [SerializeField] private string textWhenToggleOff = "Is Off Text"; // Teks ketika toggle tidak aktif
    [SerializeField] private Color textColorWhenToggleOn = Color.white; // Warna teks ketika toggle aktif
    [SerializeField] private Color textColorWhenToggleOff = Color.yellow; // Warna teks ketika toggle tidak aktif

    private void Start()
    {
        // Mengatur teks awal sesuai dengan status toggle saat ini
        UpdateTextAndColor();

        // Menambahkan listener untuk memantau perubahan toggle
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    private void OnToggleValueChanged(bool isOn)
    {
        // Ketika nilai toggle berubah, memperbarui teks dan warna
        UpdateTextAndColor();
    }

    private void UpdateTextAndColor()
    {
        if (toggle.isOn)
        {
            textComponent.text = textWhenToggleOn;
            textComponent.color = textColorWhenToggleOn;
        }
        else
        {
            textComponent.text = textWhenToggleOff;
            textComponent.color = textColorWhenToggleOff;
        }
    }

    private void OnDestroy()
    {
        // Menghapus listener saat objek dihancurkan
        toggle.onValueChanged.RemoveListener(OnToggleValueChanged);
    }
}
