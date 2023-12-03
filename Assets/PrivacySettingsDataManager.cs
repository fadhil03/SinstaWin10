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
        // Load nilai terakhir dari PlayerPrefs pada saat memulai
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

            // Simpan nilai privacy setting ke PlayerPrefs
            PlayerPrefs.SetInt(privacySettingKey, privacySettingValue ? 1 : 0);
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

            // Ambil nilai privacy setting dari PlayerPrefs, defaultnya false
            bool privacySettingValue = PlayerPrefs.GetInt(privacySettingKey, 0) == 1;

            // Atur nilai privacy setting pada SwitchToggle
            privacyToggles[i].isOn = privacySettingValue;
        }

        Debug.Log("Privacy settings loaded.");
    }
}
