using UnityEngine;
using UnityEngine.UI;

public class PasswordConfirmation : MonoBehaviour
{
    public InputField passwordInput;
    public InputField confirmPasswordInput;
    public Text passwordMatchIndicator;
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
            passwordMatchIndicator.text = "Password confirmed";
            passwordMatchIndicator.color = Color.white;
            Debug.Log("Password confirmed.");
        }
        else
        {
            passwordMatchIndicator.text = "Passwords do not match. Please try again.";
            passwordMatchIndicator.color = Color.red;
            Debug.Log("Passwords do not match. Please try again.");
        }
    }
}
