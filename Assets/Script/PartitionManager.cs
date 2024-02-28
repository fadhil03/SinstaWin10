using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PartitionManager : MonoBehaviour
{
    public GameObject scrollViewContent;
    public GameObject buttonTemplate;
    public GameObject objUnallocatedSpace;
    public GameObject objUnallocatedSpacePrefab;
    public GameObject sizePartition;
    public GameObject sizePartitionToExtend;
    public GameObject WarningPartitionCountFull;
    public GameObject WarningPartitionSize;
    public GameObject WarningPartitionNewSize;
    public GameObject PartitionSystemConfirm;
    public Button btnDelete;
    public Button btnFormat;
    public Button btnNew;
    public Button btnRefresh;
    public Button btnExtend;

    private int[] possibleSizes = { 128, 256, 512, 1024 };
    private int unallocatedSpaceInGB;
    private int newPartitionCount = 0;
    int childCount;
    int siblingIndex;
    private bool isUnallocatedSpaceSelected = false;

    void Start()
    {
        btnNew.interactable = false;
        btnDelete.interactable = false;
        btnFormat.interactable = false;

        int randomIndex = Random.Range(0, possibleSizes.Length);
        unallocatedSpaceInGB = possibleSizes[randomIndex];
        Debug.Log("Unallocated Space: " + unallocatedSpaceInGB + " GB");
        Text unallocatedSpaceText = GameObject.Find("TotalSizeUnallocated").GetComponent<Text>();
        Text freeSpaceText = GameObject.Find("freeSpaceText").GetComponent<Text>();
        unallocatedSpaceText.text = unallocatedSpaceInGB + " GB";
        freeSpaceText.text = unallocatedSpaceInGB + " GB";

        Button applyNewPartitionButton = GameObject.Find("ButtonNew").GetComponent<Button>();
        applyNewPartitionButton.onClick.AddListener(CreatePartition);
        Button cancelButton = GameObject.Find("btnCancel").GetComponent<Button>();
        cancelButton.onClick.AddListener(() => sizePartition.SetActive(false));
        Button cancelButtonExtend = GameObject.Find("btnCancelExtend").GetComponent<Button>();
        cancelButtonExtend.onClick.AddListener(() => sizePartitionToExtend.SetActive(false));


        btnNew.onClick.AddListener(ShowInputSize);
        btnRefresh.onClick.AddListener(LoadPartitionData);
        btnExtend.onClick.AddListener(ShowInputSizeToExtend);

        sizePartition.SetActive(false);
        sizePartitionToExtend.SetActive(false);

        Button selectUnallocatedSpaceButton = objUnallocatedSpace.GetComponent<Button>();
        selectUnallocatedSpaceButton.onClick.AddListener(OnUnallocatedSpaceSelected);
    }

    void Update()
    {
        childCount = scrollViewContent.transform.childCount;
        siblingIndex = childCount;

        if (WarningPartitionCountFull.activeSelf || WarningPartitionSize.activeSelf)
        {
            WarningPartitionNewSize.SetActive(false);
            sizePartition.SetActive(false);
        }
        UpdateSizeUnallocated();
    }

    private void UpdateSizeUnallocated()
    {
        if (objUnallocatedSpace != null)
        {
            Text unallocatedSpaceSize = GameObject.Find("TotalSizeUnallocated").GetComponent<Text>();
            Text freeSpaceText = GameObject.Find("freeSpaceText").GetComponent<Text>();
            unallocatedSpaceSize.text = unallocatedSpaceInGB + " GB";
            freeSpaceText.text = unallocatedSpaceInGB + " GB";
        }
        else
        {
            Debug.Log("objUnallocatedSpace is null.");
        }
    }

    public void OnUnallocatedSpaceSelected()
    {
        isUnallocatedSpaceSelected = true;
    }

    public int GetUnallocatedSpace()
    {
        return unallocatedSpaceInGB;
    }

    void ShowInputSize()
    {
        sizePartition.SetActive(true);
        sizePartitionToExtend.SetActive(false);
        TMP_InputField sizeInputField = GameObject.Find("SizeInputField").GetComponent<TMP_InputField>();
        sizeInputField.text = "";
    }

    void ShowInputSizeToExtend()
    {
        sizePartitionToExtend.SetActive(true);
        sizePartition.SetActive(false);
        TMP_InputField SizeInputFieldToExtend = GameObject.Find("SizeInputFieldToExtend").GetComponent<TMP_InputField>();
        SizeInputFieldToExtend.text = "";
    }

    public void CreatePartition()
    {
        if (!isUnallocatedSpaceSelected)
        {
            Debug.Log("Please select unallocated space first.");
            return;
        }

        TMP_InputField sizeInputField = GameObject.Find("SizeInputField").GetComponent<TMP_InputField>();
        if (int.TryParse(sizeInputField.text, out int partitionSizeInMB))
        {
            int partitionSizeInGB = partitionSizeInMB / 1000;

            if (partitionSizeInGB <= unallocatedSpaceInGB)
            {
                CreateNewPartition(partitionSizeInGB);
                unallocatedSpaceInGB -= partitionSizeInGB;
                Text unallocatedSpaceText = GameObject.Find("TotalSizeUnallocated").GetComponent<Text>();
                Text freeSpaceText = GameObject.Find("freeSpaceText").GetComponent<Text>();
                unallocatedSpaceText.text = unallocatedSpaceInGB + " GB";
                freeSpaceText.text = unallocatedSpaceInGB + " GB";
                if (unallocatedSpaceInGB == 0)
                {
                    Destroy(objUnallocatedSpace);
                    btnNew.interactable = false;
                    btnNew.GetComponentInChildren<Text>().color = Color.gray;
                }
                WarningPartitionNewSize.SetActive(false);
            }
            else
            {
                WarningPartitionNewSize.SetActive(true);
                Debug.Log("Insufficient Unallocated Space!");
                // Mengisi nilai komponen teks tvMostSizeLeft pada child game object WarningPartitionNewSize
                TextMeshProUGUI tvMostSizeLeft = WarningPartitionNewSize.GetComponentInChildren<TextMeshProUGUI>();
                if (tvMostSizeLeft != null)
                {
                    Text TotalSizeUnallocatedLeft = GameObject.Find("TotalSizeUnallocated").GetComponent<Text>();
                    if (TotalSizeUnallocatedLeft != null)
                    {
                        string totalSizeUnallocatedText = TotalSizeUnallocatedLeft.text.Replace(" GB", ""); // Menghapus " GB" dari teks
                        if (int.TryParse(totalSizeUnallocatedText, out int totalSizeUnallocated)) // Mengonversi teks menjadi integer
                        {
                            totalSizeUnallocated *= 1000; // Mengalikan dengan 1000
                            tvMostSizeLeft.text = totalSizeUnallocated.ToString(); // Mengonversi kembali ke string dan mengisi nilai komponen teks
                        }
                        else
                        {
                            Debug.LogWarning("Failed to parse TotalSizeUnallocated text to integer!");
                        }
                    }
                    else
                    {
                        Debug.LogWarning("TotalSizeUnallocated Text component not found!");
                    }
                }
                else
                {
                    Debug.LogWarning("tvMostSizeLeft not found!");
                }
            }
        }
        else
        {
            Debug.Log("Invalid input for partition size!");
        }
    }

    void CreateNewPartition(int sizeInGB)
    {
        string partitionObjectName = "Partition " + (newPartitionCount + 1);

        if (newPartitionCount == 0)
        {
            PartitionSystemConfirm.SetActive(true); // Aktifkan PartitionSystemConfirmPopup
            Transform parentTransform = PartitionSystemConfirm.transform.parent;
            if (parentTransform != null)
            {
                GameObject popUpNotification = parentTransform.gameObject;
                popUpNotification.SetActive(true); // Aktifkan PopUpNotification
            }
            else
            {
                Debug.LogWarning("Parent dari PartitionSystemConfirmPopup tidak ditemukan!");
            }
            GameObject newButton1 = Instantiate(buttonTemplate, scrollViewContent.transform);
            newButton1.name = partitionObjectName;
            newButton1.tag = "Partition";

            Text tvNamePartition1 = newButton1.transform.Find("tvNamePartition").GetComponent<Text>();
            Text tvTotalSize1 = newButton1.transform.Find("tvTotalSize").GetComponent<Text>();
            Text tvFreeSpace1 = newButton1.transform.Find("tvFreeSpace").GetComponent<Text>();
            Text tvTypePartition1 = newButton1.transform.Find("tvTypePartition").GetComponent<Text>();

            tvNamePartition1.text = "Drive 0 " + partitionObjectName + " : System Reserved";
            tvTypePartition1.text = "System";

            int partitionSizeInMB = 50; // Ukuran yang ditentukan untuk partisi pertama
            int freeSpaceInMB = 38; // Ukuran bebas yang ditentukan untuk partisi pertama

            tvTotalSize1.text = partitionSizeInMB + " MB"; // Ukuran yang ditentukan
            tvFreeSpace1.text = freeSpaceInMB + " MB"; // Ukuran bebas yang ditentukan

            GameObject newButton2 = Instantiate(buttonTemplate, scrollViewContent.transform);
            partitionObjectName = "Partition " + (newPartitionCount + 2);
            newButton2.name = partitionObjectName;
            newButton2.tag = "Partition";

            Text tvNamePartition2 = newButton2.transform.Find("tvNamePartition").GetComponent<Text>();
            Text tvTotalSize2 = newButton2.transform.Find("tvTotalSize").GetComponent<Text>();
            Text tvFreeSpace2 = newButton2.transform.Find("tvFreeSpace").GetComponent<Text>();
            Text tvTypePartition2 = newButton2.transform.Find("tvTypePartition").GetComponent<Text>();

            tvNamePartition2.text = "Drive 0 " + partitionObjectName;
            tvTypePartition2.text = "Primary";
            tvTotalSize2.text = sizeInGB + " GB";
            tvFreeSpace2.text = sizeInGB + " GB";
            childCount = scrollViewContent.transform.childCount;
            siblingIndex = childCount;
            objUnallocatedSpace.transform.SetSiblingIndex(siblingIndex);
            newPartitionCount++;
        }
        else
        {
            GameObject newButton = Instantiate(buttonTemplate, scrollViewContent.transform);
            newButton.name = partitionObjectName;
            newButton.tag = "Partition";

            Text tvNamePartition = newButton.transform.Find("tvNamePartition").GetComponent<Text>();
            Text tvTotalSize = newButton.transform.Find("tvTotalSize").GetComponent<Text>();
            Text tvFreeSpace = newButton.transform.Find("tvFreeSpace").GetComponent<Text>();
            Text tvTypePartition = newButton.transform.Find("tvTypePartition").GetComponent<Text>();

            tvNamePartition.text = "Drive 0 " + partitionObjectName;
            tvTotalSize.text = sizeInGB + " GB";
            tvFreeSpace.text = sizeInGB + " GB";
            tvTypePartition.text = "Primary";
        }

        sizePartition.SetActive(false);

        childCount = scrollViewContent.transform.childCount;
        siblingIndex = childCount;
        objUnallocatedSpace.transform.SetSiblingIndex(siblingIndex);
        newPartitionCount++;
    }

    public void SavePartitionToPlayerPrefs()
    {
        // Dapatkan jumlah partisi di dalam scroll view content
        int partitionCount = scrollViewContent.transform.childCount;

        // Jika objUnallocatedSpace tidak null, simpan informasi tambahan
        if (objUnallocatedSpace != null)
        {
            Text tvTotalSizeUnallocated = objUnallocatedSpace.transform.Find("TotalSizeUnallocated").GetComponent<Text>();
            Text freeSpaceText = objUnallocatedSpace.transform.Find("freeSpaceText").GetComponent<Text>();
            Text typePartitionText = objUnallocatedSpace.transform.Find("TypePartition").GetComponent<Text>();

            // Simpan informasi unallocated space ke PlayerPrefs
            PlayerPrefs.SetString("Unallocated_Name", "Drive 0 Unallocated Space");
            PlayerPrefs.SetString("Unallocated_TotalSize", tvTotalSizeUnallocated.text);
            PlayerPrefs.SetString("Unallocated_FreeSpace", freeSpaceText.text);
            PlayerPrefs.SetString("Unallocated_Type", typePartitionText.text);
        }
        else
        {
            Debug.Log("objUnallocatedSpace is null.");
            PlayerPrefs.SetString("Unallocated_Name", "Drive 0 Unallocated Space");
            PlayerPrefs.SetString("Unallocated_TotalSize", "0 GB");
            PlayerPrefs.SetString("Unallocated_FreeSpace", "0 GB");
            PlayerPrefs.SetString("Unallocated_Type", "");
        }

        // Loop melalui setiap partisi
        for (int i = 1; i < partitionCount; i++)
        {
            GameObject partitionObject = scrollViewContent.transform.GetChild(i).gameObject;

            // Dapatkan komponen teks dari setiap partisi
            Text tvNamePartition = partitionObject.transform.Find("tvNamePartition")?.GetComponent<Text>();
            Text tvTotalSize = partitionObject.transform.Find("tvTotalSize")?.GetComponent<Text>();
            Text tvFreeSpace = partitionObject.transform.Find("tvFreeSpace")?.GetComponent<Text>();
            Text tvTypePartition = partitionObject.transform.Find("tvTypePartition")?.GetComponent<Text>();

            // Buat kunci unik untuk setiap partisi
            string partitionKey = "Partition_" + i;

            // Jika komponen teks ada, simpan data partisi ke PlayerPrefs
            if (tvNamePartition != null && tvTotalSize != null && tvFreeSpace != null && tvTypePartition != null)
            {
                PlayerPrefs.SetString(partitionKey + "_Name", tvNamePartition.text);
                PlayerPrefs.SetString(partitionKey + "_TotalSize", tvTotalSize.text);
                PlayerPrefs.SetString(partitionKey + "_FreeSpace", tvFreeSpace.text);
                PlayerPrefs.SetString(partitionKey + "_Type", tvTypePartition.text);
            }
            else
            {
                Debug.LogWarning("One or more text components not found for partition " + i);
            }
        }

        // Simpan jumlah partisi ke PlayerPrefs
        PlayerPrefs.SetInt("PartitionCount", partitionCount);
        PlayerPrefs.Save();
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

            Debug.Log("===========================================");
            Debug.Log("Partition Name: " + partitionName);
            Debug.Log("Total Size: " + totalSize + " GB");
            Debug.Log("Free Space: " + freeSpace + " GB");
            Debug.Log("Type: " + partitionType);
            Debug.Log("===========================================");
        }
    }

    public void DeletePartition(GameObject partitionObject)
    {
        Text tvTotalSize = partitionObject.transform.Find("tvTotalSize").GetComponent<Text>();
        string sizeText = tvTotalSize.text;
        int partitionSizeInGB = 0;

        if (sizeText.Contains("GB"))
        {
            partitionSizeInGB = int.Parse(sizeText.Replace(" GB", ""));
        }
        else if (sizeText.Contains("MB"))
        {
            int.TryParse(sizeText.Replace(" MB", ""), out int sizeInMB);
            partitionSizeInGB = sizeInMB / 1000;
        }

        unallocatedSpaceInGB += partitionSizeInGB;

        Destroy(partitionObject);

        newPartitionCount--;

        if (objUnallocatedSpace == null || !objUnallocatedSpace.activeInHierarchy)
        {
            objUnallocatedSpace = Instantiate(objUnallocatedSpacePrefab, scrollViewContent.transform);
            objUnallocatedSpace.transform.SetSiblingIndex(siblingIndex);
        }

        PlayerPrefs.SetInt("PartitionCount", newPartitionCount);
        PlayerPrefs.Save();
    }

    public void ExtendPartition(GameObject partitionObject, int additionalSizeInMB)
    {
        Text tvTotalSize = partitionObject.transform.Find("tvTotalSize").GetComponent<Text>();
        Text tvFreeSpace = partitionObject.transform.Find("tvFreeSpace").GetComponent<Text>();

        int currentTotalSizeGB = 0;
        int currentFreeSpaceGB = 0;

        // Mendapatkan ukuran total saat ini
        if (tvTotalSize.text.Contains("GB"))
        {
            currentTotalSizeGB = int.Parse(tvTotalSize.text.Replace(" GB", ""));
        }
        else if (tvTotalSize.text.Contains("MB"))
        {
            int.TryParse(tvTotalSize.text.Replace(" MB", ""), out int currentTotalSizeMB);
            currentTotalSizeGB = currentTotalSizeMB / 1000;
        }

        // Mendapatkan ukuran bebas saat ini
        if (tvFreeSpace.text.Contains("GB"))
        {
            currentFreeSpaceGB = int.Parse(tvFreeSpace.text.Replace(" GB", ""));
        }
        else if (tvFreeSpace.text.Contains("MB"))
        {
            int.TryParse(tvFreeSpace.text.Replace(" MB", ""), out int currentFreeSpaceMB);
            currentFreeSpaceGB = currentFreeSpaceMB / 1000;
        }

        // Menambahkan ukuran tambahan ke ukuran total
        int newTotalSizeGB = currentTotalSizeGB + (additionalSizeInMB / 1000);
        int newFreeSpaceGB = currentFreeSpaceGB + (additionalSizeInMB / 1000);

        // Pengecekan apakah ukuran tambahan tidak melebihi unallocated space
        int partitionSizeInGB = additionalSizeInMB / 1000;

        if (partitionSizeInGB <= unallocatedSpaceInGB)
        {
            // Memperbarui teks pada UI partisi
            tvTotalSize.text = newTotalSizeGB + " GB";
            tvFreeSpace.text = newFreeSpaceGB + " GB";

            sizePartitionToExtend.SetActive(false);
            WarningPartitionNewSize.SetActive(false);
            // Mengurangi unallocated space
            unallocatedSpaceInGB -= partitionSizeInGB;

            if (unallocatedSpaceInGB == 0)
            {
                Destroy(objUnallocatedSpace);
                btnNew.interactable = false;
                btnNew.GetComponentInChildren<Text>().color = Color.gray;
            }
        }
        else
        {
            // Tampilkan pesan peringatan karena ukuran tambahan melebihi unallocated space
            WarningPartitionSizeInput();
        }
    }

    void WarningPartitionSizeInput()
    {
        WarningPartitionNewSize.SetActive(true);
        Debug.Log("Insufficient Unallocated Space!");
        // Mengisi nilai komponen teks tvMostSizeLeft pada child game object WarningPartitionNewSize
        TextMeshProUGUI tvMostSizeLeft = WarningPartitionNewSize.GetComponentInChildren<TextMeshProUGUI>();
        if (tvMostSizeLeft != null)
        {
            Text TotalSizeUnallocatedLeft = GameObject.Find("TotalSizeUnallocated").GetComponent<Text>();
            if (TotalSizeUnallocatedLeft != null)
            {
                string totalSizeUnallocatedText = TotalSizeUnallocatedLeft.text.Replace(" GB", ""); // Menghapus " GB" dari teks
                if (int.TryParse(totalSizeUnallocatedText, out int totalSizeUnallocated)) // Mengonversi teks menjadi integer
                {
                    totalSizeUnallocated *= 1000; // Mengalikan dengan 1000
                    tvMostSizeLeft.text = totalSizeUnallocated.ToString(); // Mengonversi kembali ke string dan mengisi nilai komponen teks
                }
                else
                {
                    Debug.LogWarning("Failed to parse TotalSizeUnallocated text to integer!");
                }
            }
            else
            {
                Debug.LogWarning("TotalSizeUnallocated Text component not found!");
            }
        }
        else
        {
            Debug.LogWarning("tvMostSizeLeft not found!");
        }
    }

    public void FormatPartition(GameObject partitionObject)
    {
        Text tvTotalSize = partitionObject.transform.Find("tvTotalSize").GetComponent<Text>();
        Text tvFreeSpace = partitionObject.transform.Find("tvFreeSpace").GetComponent<Text>();

        int ParseSizeTextToGB(string sizeText)
        {
            int sizeInGB = 0;

            if (sizeText.Contains("GB"))
            {
                int.TryParse(sizeText.Replace(" GB", ""), out sizeInGB);
            }
            else if (sizeText.Contains("MB"))
            {
                int sizeInMB = 0;
                if (int.TryParse(sizeText.Replace(" MB", ""), out sizeInMB))
                {
                    sizeInGB = sizeInMB / 1000;
                }
            }

            return sizeInGB;
        }

        if (tvTotalSize != null && tvFreeSpace != null)
        {
            // Mengambil nilai total size
            string totalSizeText = tvTotalSize.text;
            int totalSizeGB = ParseSizeTextToGB(totalSizeText);

            // Mengubah nilai free space menjadi sama dengan total size
            tvFreeSpace.text = totalSizeGB + " GB";
        }
        else
        {
            Debug.LogWarning("tvTotalSize or tvFreeSpace not found!");
        }
    }
}
