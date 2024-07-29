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
        MediaBootableText.text = ": " + (PlayerPrefs.HasKey("MediaBootable") ? PlayerPrefs.GetString("MediaBootable") : "-");
        ProductKeyText.text = ": " + (PlayerPrefs.HasKey("Product_Key") ? PlayerPrefs.GetString("Product_Key") : "-");
        TypeOsText.text = ": " + (PlayerPrefs.HasKey("SelectedOS") ? PlayerPrefs.GetString("SelectedOS") : "-");
        UnallocatedText.text = ": " + (PlayerPrefs.HasKey("Unallocated_TotalSize") ? PlayerPrefs.GetString("Unallocated_TotalSize") : "-");
        Partition1Text.text = ": " + (PlayerPrefs.HasKey("Partition_1_TotalSize") ? PlayerPrefs.GetString("Partition_1_TotalSize") : "-");
        Partition2Text.text = ": " + (PlayerPrefs.HasKey("Partition_2_TotalSize") ? PlayerPrefs.GetString("Partition_2_TotalSize") : "-");
        Partition3Text.text = ": " + (PlayerPrefs.HasKey("Partition_3_TotalSize") ? PlayerPrefs.GetString("Partition_3_TotalSize") : "-");
        Partition4Text.text = ": " + (PlayerPrefs.HasKey("Partition_4_TotalSize") ? PlayerPrefs.GetString("Partition_4_TotalSize") : "-");
        RegionText.text = ": " + (PlayerPrefs.HasKey("Region") ? PlayerPrefs.GetString("Region") : "-");
        KeyboardLayoutText.text = ": " + (PlayerPrefs.HasKey("KeyboardLayout") ? PlayerPrefs.GetString("KeyboardLayout") : "-");
        UsernameText.text = ": " + (PlayerPrefs.HasKey("Username") ? PlayerPrefs.GetString("Username") : "-");
        PasswordText.text = ": " + (PlayerPrefs.HasKey("Password") ? PlayerPrefs.GetString("Password") : "-");
        ElapsedSimulationTimeText.text = ": " + (PlayerPrefs.HasKey("ElapsedSimulationTime") ? PlayerPrefs.GetString("ElapsedSimulationTime") : "-");
    }
}
