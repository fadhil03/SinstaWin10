using UnityEngine;
using UnityEngine.UI;

public class DataHandler : MonoBehaviour
{
    public InputField usernameInput;
    public InputField passwordInput;
    public InputField securityQuestionInput;

    private const string usernameKey = "Username";
    private const string passwordKey = "Password";
    private const string securityQuestionKey = "SecurityQuestion";

    private void Start()
    {
        // Pada awal permainan, coba mengambil data dari PlayerPrefs dan mengisinya ke InputField
        //LoadData();
    }

    public void Update()
    {
        SaveData();
    }

    public void SaveData()
    {
        // Simpan data ke PlayerPrefs
        PlayerPrefs.SetString(usernameKey, usernameInput.text);
        PlayerPrefs.SetString(passwordKey, passwordInput.text);
        PlayerPrefs.SetString(securityQuestionKey, securityQuestionInput.text);

        // Simpan perubahan
        PlayerPrefs.Save();

        // Tampilkan data yang disimpan dalam Debug.Log
        Debug.Log("Data saved:");
        Debug.Log($"Username: {usernameInput.text}");
        Debug.Log($"Password: {passwordInput.text}");
        Debug.Log($"Security Question: {securityQuestionInput.text}");
    }

    public void LoadData()
    {
        // Ambil data dari PlayerPrefs dan isi ke InputField
        if (PlayerPrefs.HasKey(usernameKey))
            usernameInput.text = PlayerPrefs.GetString(usernameKey);

        if (PlayerPrefs.HasKey(passwordKey))
            passwordInput.text = PlayerPrefs.GetString(passwordKey);

        if (PlayerPrefs.HasKey(securityQuestionKey))
            securityQuestionInput.text = PlayerPrefs.GetString(securityQuestionKey);

        // Tampilkan data yang diambil dalam Debug.Log
        Debug.Log("Data loaded:");
        Debug.Log($"Username: {usernameInput.text}");
        Debug.Log($"Password: {passwordInput.text}");
        Debug.Log($"Security Question: {securityQuestionInput.text}");
    }
}
