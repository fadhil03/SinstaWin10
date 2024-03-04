using UnityEngine;
using UnityEngine.UI;

public class PasswordCheck : MonoBehaviour
{
    public Button btnNext; // Tombol next
    public InputField passwordInputField;
    public Text passwordMatchIndicator;

    void Start()
    {
        // Tambahkan listener untuk event OnEndEdit
        passwordInputField.onEndEdit.AddListener(EndEditHandler);
        btnNext.interactable = false;
    }

    // Metode yang akan dipanggil saat pengguna selesai mengedit InputField
    public void EndEditHandler(string text)
    {
        string enteredPassword = text;

        // Mendapatkan password yang disimpan di PlayerPrefs
        string storedPassword = PlayerPrefs.GetString("Password");

        // Memeriksa apakah password yang dimasukkan sama dengan yang disimpan
        if (enteredPassword != storedPassword)
        {
            // Jika tidak sama, mengubah teks dan warna teks pada indicator
            passwordMatchIndicator.text = "Passwords do not match. Please try again.";
            passwordMatchIndicator.color = Color.red;
        }
        else
        {
            // Jika sama, mengubah teks dan warna teks pada indicator
            passwordMatchIndicator.text = "Passwords match!";
            passwordMatchIndicator.color = Color.white;
            btnNext.interactable = true;
        }
    }

    // Pastikan untuk membersihkan listener saat objek dihancurkan (jika diperlukan)
    private void OnDestroy()
    {
        passwordInputField.onEndEdit.RemoveListener(EndEditHandler);
    }
}
