using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupSummary : MonoBehaviour
{
    public Text MediaBootableText;
    public Text ProductKeyText;
    public Text TypeOsText;
    public Text UnallocatedText;
    public Text Partition1Text;
    public Text Partition2Text;
    public Text Partition3Text;
    public Text Partition4Text;
    public Text RegionText;
    public Text KeyboardLayoutText;
    public Text UsernameText;
    public Text PasswordText;
    public Text ElapsedSimulationTimeText;

    void Start()
    {
        MediaBootableText.text = ": " + PlayerPrefs.GetString("MediaBootable");
        ProductKeyText.text = ": " + PlayerPrefs.GetString("Product_Key");
        TypeOsText.text = ": " + PlayerPrefs.GetString("SelectedOS");
        UnallocatedText.text = ": " + PlayerPrefs.GetString("Unallocated_TotalSize");
        Partition1Text.text = ": " + PlayerPrefs.GetString("Partition_1_TotalSize");
        Partition2Text.text = ": " + PlayerPrefs.GetString("Partition_2_TotalSize");
        Partition3Text.text = ": " + (PlayerPrefs.HasKey("Partition_3_TotalSize") ? PlayerPrefs.GetString("Partition_3_TotalSize") : "-");
        Partition4Text.text = ": " + (PlayerPrefs.HasKey("Partition_4_TotalSize") ? PlayerPrefs.GetString("Partition_4_TotalSize") : "-");
        RegionText.text = ": " + PlayerPrefs.GetString("Region");
        KeyboardLayoutText.text = ": " + PlayerPrefs.GetString("KeyboardLayout");
        UsernameText.text = ": " + PlayerPrefs.GetString("Username");
        PasswordText.text = ": " + (PlayerPrefs.HasKey("Password") ? PlayerPrefs.GetString("Password") : "-");
        ElapsedSimulationTimeText.text = ": " + PlayerPrefs.GetString("ElapsedSimulationTime");
    }
}
