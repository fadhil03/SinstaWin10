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
    public GameObject WarningPartitionCountFull;
    public GameObject WarningPartitionSize;
    public GameObject WarningPartitionNewSize;
    public Button btnDelete;
    public Button btnFormat;
    public Button btnNew;
    public Button btnRefresh;

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

        Button applyButton = GameObject.Find("ButtonNew").GetComponent<Button>();
        applyButton.onClick.AddListener(CreatePartition);
        Button cancelButton = GameObject.Find("btnCancel").GetComponent<Button>();
        cancelButton.onClick.AddListener(() => sizePartition.SetActive(false));

        btnNew.onClick.AddListener(ShowInputSize);
        btnRefresh.onClick.AddListener(LoadPartitionData);

        sizePartition.SetActive(false);

        Button selectUnallocatedSpaceButton = objUnallocatedSpace.GetComponent<Button>();
        selectUnallocatedSpaceButton.onClick.AddListener(OnUnallocatedSpaceSelected);
    }

    void Update()
    {
        Text unallocatedSpaceText = GameObject.Find("TotalSizeUnallocated").GetComponent<Text>();
        Text freeSpaceText = GameObject.Find("freeSpaceText").GetComponent<Text>();
        unallocatedSpaceText.text = unallocatedSpaceInGB + " GB";
        freeSpaceText.text = unallocatedSpaceInGB + " GB";

        childCount = scrollViewContent.transform.childCount;
        siblingIndex = childCount;

        if (WarningPartitionCountFull.activeSelf || WarningPartitionSize.activeSelf)
        {
            WarningPartitionNewSize.SetActive(false);
            sizePartition.SetActive(false);
        }
    }

    public void OnUnallocatedSpaceSelected()
    {
        isUnallocatedSpaceSelected = true;
    }

    void ShowInputSize()
    {
        sizePartition.SetActive(true);
        TMP_InputField sizeInputField = GameObject.Find("SizeInputField").GetComponent<TMP_InputField>();
        sizeInputField.text = "";
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
                Button cancelButton = GameObject.Find("btnCancel").GetComponent<Button>();
                cancelButton.onClick.AddListener(() => WarningPartitionNewSize.SetActive(false));
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

        string partitionKey = "Partition_" + (newPartitionCount + 1);
        PlayerPrefs.SetString(partitionKey + "_Name", "Drive 0 " + partitionObjectName);
        PlayerPrefs.SetInt(partitionKey + "_TotalSize", sizeInGB);
        PlayerPrefs.SetInt(partitionKey + "_FreeSpace", sizeInGB);
        PlayerPrefs.SetString(partitionKey + "_Type", newPartitionCount == 0 ? "Type: System" : "Type: NTFS");

        PlayerPrefs.SetInt("PartitionCount", newPartitionCount);
        PlayerPrefs.Save();
        childCount = scrollViewContent.transform.childCount;
        siblingIndex = childCount;
        objUnallocatedSpace.transform.SetSiblingIndex(siblingIndex);
        newPartitionCount++;
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

}
