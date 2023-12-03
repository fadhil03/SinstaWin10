using UnityEngine;
using UnityEngine.UI;

public class PrivacySettingsDataManager : MonoBehaviour
{
    public Toggle[] privacyToggles;

    private string[] privacySettingKeys = {
        "PrivacySettingLocation",
        "PrivacySettingFindMyDevice",
        "PrivacySettingDiagnosticData",
        "PrivacySettingInkingTyping",
        "PrivacySettingTailoredExperiences",
        "PrivacySettingAdvertisingID"
    };

    private void Start()
    {
        //LoadPrivacySettings();
    }

    public void Update()
    {
        SavePrivacySettings();
    }

    public void SavePrivacySettings()
    {
        for (int i = 0; i < privacyToggles.Length; i++)
        {
            bool privacySettingValue = privacyToggles[i].isOn;
            string privacySettingKey = privacySettingKeys[i];

            // Simpan nilai privacy setting ke PlayerPrefs sebagai string "Yes" atau "No"
            PlayerPrefs.SetString(privacySettingKey, privacySettingValue ? "Yes" : "No");
        }

        // Simpan perubahan
        PlayerPrefs.Save();

        Debug.Log("Privacy settings saved.");
    }

    private void LoadPrivacySettings()
    {
        for (int i = 0; i < privacyToggles.Length; i++)
        {
            string privacySettingKey = privacySettingKeys[i];

            // Ambil nilai privacy setting dari PlayerPrefs, defaultnya "No"
            string privacySettingValue = PlayerPrefs.GetString(privacySettingKey, "No");

            // Atur nilai privacy setting pada SwitchToggle berdasarkan string "Yes" atau "No"
            privacyToggles[i].isOn = (privacySettingValue == "Yes");
        }

        Debug.Log("Privacy settings loaded.");
    }
}
