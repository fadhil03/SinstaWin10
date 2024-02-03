using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartitionManager : MonoBehaviour
{
    public GameObject scrollViewContent;
    public GameObject buttonTemplate;
    public GameObject objUnallocatedSpace;
    public GameObject sizePartition;
    public Button btnDelete;
    public Button btnFormat;
    public Button btnNew;
    public Button btnRefresh;

    private int[] possibleSizes = { 128, 256, 512, 1024 };
    private int unallocatedSpaceInGB;
    private int newPartitionCount = 0; // Melacak berapa kali button "ButtonNew" ditekan.
    private bool isUnallocatedSpaceSelected = false;
    

    // Start is called before the first frame update
    void Start()
    {
        btnDelete.interactable = false;
        btnFormat.interactable = false;

        int randomIndex = Random.Range(0, possibleSizes.Length);
        unallocatedSpaceInGB = possibleSizes[randomIndex];
        Debug.Log("Unallocated Space: " + unallocatedSpaceInGB + " GB");
        Text unallocatedSpaceText = GameObject.Find("UnallocatedSpaceText").GetComponent<Text>();
        Text freeSpaceText = GameObject.Find("freeSpaceText").GetComponent<Text>();
        unallocatedSpaceText.text = unallocatedSpaceInGB + " GB";
        freeSpaceText.text = unallocatedSpaceInGB + " GB";


        Button applyButton = GameObject.Find("ButtonNew").GetComponent<Button>();
        applyButton.onClick.AddListener(CreatePartition);

        btnNew.onClick.AddListener(ShowInputSize);
        btnRefresh.onClick.AddListener(LoadPartitionData);

        sizePartition.SetActive(false);

        Button selectUnallocatedSpaceButton = objUnallocatedSpace.GetComponent<Button>();
        selectUnallocatedSpaceButton.onClick.AddListener(OnUnallocatedSpaceSelected);
    }

    // Update is called once per frame
    void Update()
    {
        //Button newButton = GameObject.Find("ButtonNew").GetComponent<Button>();
        //newButton.onClick.AddListener(OnNewButtonClicked);
        //btnNew.onClick.AddListener(OnBtnNewClicked);
        //btnRefresh.onClick.AddListener(LoadPartitionData);
    }

    public void OnUnallocatedSpaceSelected()
    {
        isUnallocatedSpaceSelected = true;
    }

    void ShowInputSize()
    {
        // Setelah tombol "btnNew" ditekan, aktifkan kembali objek "SizePartition"
        sizePartition.SetActive(true);
    }

    public void CreatePartition()
    {

        if (!isUnallocatedSpaceSelected)
        {
            Debug.Log("Please select unallocated space first.");
            return;
        }

        InputField sizeInputField = GameObject.Find("SizeInputField").GetComponent<InputField>();
        if (int.TryParse(sizeInputField.text, out int partitionSizeInMB))
        {
            // Konversi dari MB ke GB
            int partitionSizeInGB = partitionSizeInMB / 1000;

            // Cek apakah ukuran partisi yang dimasukkan tidak melebihi Unallocated Space yang tersedia
            if (partitionSizeInGB <= unallocatedSpaceInGB)
            {
                CreateNewPartition(partitionSizeInGB);
                unallocatedSpaceInGB -= partitionSizeInGB; // Kurangi Unallocated Space berdasarkan ukuran partisi yang baru dibuat
                Text unallocatedSpaceText = GameObject.Find("UnallocatedSpaceText").GetComponent<Text>();
                Text freeSpaceText = GameObject.Find("freeSpaceText").GetComponent<Text>();
                unallocatedSpaceText.text = unallocatedSpaceInGB + " GB";
                freeSpaceText.text = unallocatedSpaceInGB + " GB";
                if (unallocatedSpaceInGB == 0)
                {
                    // Hide, disable, or remove the objUnallocatedSpace GameObject
                    // objUnallocatedSpace.SetActive(false);
                    // OR: objUnallocatedSpace.GetComponent<Renderer>().enabled = false;
                    // OR:
                    Destroy(objUnallocatedSpace);
                    btnNew.interactable = false;
                }

            }
            else
            {
                Debug.Log("Insufficient Unallocated Space!");
            }
        }
        else
        {
            Debug.Log("Invalid input for partition size!");
        }
    }

    void CreateNewPartition(int partitionSizeInGB)
    {
        GameObject newButton = Instantiate(buttonTemplate, scrollViewContent.transform);

        // Akses komponen-komponen text pada button baru dan atur teksnya sesuai dengan data yang diinginkan
        Text tvNamePartition = newButton.transform.Find("tvNamePartition").GetComponent<Text>();
        Text tvTotalSize = newButton.transform.Find("tvTotalSize").GetComponent<Text>();
        Text tvFreeSpace = newButton.transform.Find("tvFreeSpace").GetComponent<Text>();
        Text tvTypePartition = newButton.transform.Find("tvTypePartition").GetComponent<Text>();

        tvNamePartition.text = "Drive 0 Partition " + newPartitionCount;
        tvTotalSize.text = partitionSizeInGB + " GB";
        tvFreeSpace.text = partitionSizeInGB + " GB";
        tvTypePartition.text = "Type: NTFS";

        btnDelete.interactable = true;
        btnFormat.interactable = true;
        sizePartition.SetActive(false);

        // Menyimpan informasi partisi ke dalam PlayerPrefs
        string partitionKey = "Partition_" + newPartitionCount;
        PlayerPrefs.SetString(partitionKey + "_Name", "Drive 0 Partition " + newPartitionCount);
        PlayerPrefs.SetInt(partitionKey + "_TotalSize", partitionSizeInGB);
        PlayerPrefs.SetInt(partitionKey + "_FreeSpace", partitionSizeInGB);
        PlayerPrefs.SetString(partitionKey + "_Type", "Type: NTFS");

        // Menyimpan jumlah partisi yang telah dibuat
        PlayerPrefs.SetInt("PartitionCount", newPartitionCount);

        PlayerPrefs.Save(); // Simpan perubahan ke PlayerPrefs

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
