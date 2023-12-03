using UnityEngine;
using UnityEngine.UI;

public class PasswordConfirmation : MonoBehaviour
{
    public InputField passwordInput;
    public InputField confirmPasswordInput;
    public Button nextButton;

    private const string passwordKey = "Password";

    private void Start()
    {
        // Secara default, nonaktifkan tombol next
        nextButton.interactable = false;
    }

    public void CheckPasswordConfirmation()
    {
        string enteredPassword = passwordInput.text;
        string confirmPassword = confirmPasswordInput.text;

        // Periksa apakah password yang dimasukkan dan konfirmasi password sama
        bool passwordsMatch = enteredPassword.Equals(confirmPassword);

        // Aktifkan atau nonaktifkan tombol next berdasarkan hasil pengecekan
        nextButton.interactable = passwordsMatch;

        // Tampilkan pesan di Debug.Log
        if (passwordsMatch)
        {
            Debug.Log("Password confirmed.");
        }
        else
        {
            Debug.Log("Passwords do not match. Please try again.");
        }
    }
}
