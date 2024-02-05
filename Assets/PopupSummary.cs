using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupSummary : MonoBehaviour
{
    // Start is called before the first frame update
    public Text tvMedia, tvProductKey, tvTypeOs, tvTypeOsArch, tvTypeOsDate, tvUsername, tvPassword,
                tvSecQ1, tvSecA1, tvSecQ2, tvSecA2, tvSecQ3, tvSecA3, tvLocation, tvFindDevice,
                tvDiagnostic, tvInking, tvTailored, tvAdvertising;

    void Start()
    {
        // Mengisi teks dari PlayerPrefs
        tvMedia.text = ": " + PlayerPrefs.GetString("MediaBootable");
        tvProductKey.text = ": " + PlayerPrefs.GetString("Product_Key");
        tvTypeOs.text = ": " + PlayerPrefs.GetString("SelectedOS");
        tvTypeOsArch.text = PlayerPrefs.GetString("SelectedArchitectures");
        tvTypeOsDate.text = PlayerPrefs.GetString("SelectedDateModified");
        tvUsername.text = ": " + PlayerPrefs.GetString("Username");
        tvPassword.text = ": " + PlayerPrefs.GetString("Password");
        tvSecQ1.text = ": " + PlayerPrefs.GetString("SelectedSecurityQuestions0");
        tvSecA1.text = ": " + PlayerPrefs.GetString("SecurityQuestionAnswers0");
        tvSecQ2.text = ": " + PlayerPrefs.GetString("SelectedSecurityQuestions1");
        tvSecA2.text = ": " + PlayerPrefs.GetString("SecurityQuestionAnswers1");
        tvSecQ3.text = ": " + PlayerPrefs.GetString("SelectedSecurityQuestions2");
        tvSecA3.text = ": " + PlayerPrefs.GetString("SecurityQuestionAnswers2");
        tvLocation.text = ": " + PlayerPrefs.GetString("PrivacySettingLocation");
        tvFindDevice.text = ": " + PlayerPrefs.GetString("PrivacySettingFindMyDevice");
        tvDiagnostic.text = ": " + PlayerPrefs.GetString("PrivacySettingDiagnosticData");
        tvInking.text = ": " + PlayerPrefs.GetString("PrivacySettingInkingTyping");
        tvTailored.text = ": " + PlayerPrefs.GetString("PrivacySettingTailoredExperiences");
        tvAdvertising.text = ": " + PlayerPrefs.GetString("PrivacySettingAdvertisingID");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LoadPartitionData()
    {
        int partitionCount = PlayerPrefs.GetInt("PartitionCount", 0);

        for (int i = 0; i < partitionCount; i++)
        {
            string partitionKey = "Partition_" + i;
            string partitionName = PlayerPrefs.GetString(partitionKey + "_Name", "");
            int totalSize = PlayerPrefs.GetInt(partitionKey + "_TotalSize", 0);
            int freeSpace = PlayerPrefs.GetInt(partitionKey + "_FreeSpace", 0);
            string partitionType = PlayerPrefs.GetString(partitionKey + "_Type", "");

            // Lakukan sesuatu dengan data partisi yang telah dibaca
            Debug.Log("===========================================");
            Debug.Log("Partition Name: " + partitionName);
            Debug.Log("Total Size: " + totalSize + " GB");
            Debug.Log("Free Space: " + freeSpace + " GB");
            Debug.Log("Type: " + partitionType);
            Debug.Log("===========================================");
        }


    }
}
