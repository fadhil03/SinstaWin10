using UnityEngine;
using UnityEngine.UI;

public class PasswordCheck : MonoBehaviour
{
    public Button btnNext; // Tombol next
    public InputField passwordInputField; // InputField untuk memasukkan password
    public Text passwordMatchIndicator; // Indikator kesesuaian password

    void Start()
    {
        // Menambahkan listener untuk event klik pada tombol
        btnNext.onClick.AddListener(CheckPassword);
    }

    void CheckPassword()
    {
        // Mendapatkan password yang dimasukkan oleh pengguna
        string enteredPassword = passwordInputField.text;

        // Mendapatkan password yang disimpan di PlayerPrefs
        string storedPassword = PlayerPrefs.GetString("Password");

        // Memeriksa apakah password yang dimasukkan sama dengan yang disimpan
        if (enteredPassword != storedPassword)
        {
            // Jika tidak sama, mengubah teks dan warna teks pada indicator
            passwordMatchIndicator.text = "Passwords do not match. Please try again.";
            passwordMatchIndicator.color = Color.red;
        }
    }
}
