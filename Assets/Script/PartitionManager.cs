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
        btnNew.interactable = false;
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
        Button cancelButton = GameObject.Find("btnCancel").GetComponent<Button>();
        cancelButton.onClick.AddListener(() => sizePartition.SetActive(false));

        btnNew.onClick.AddListener(ShowInputSize);
        btnRefresh.onClick.AddListener(LoadPartitionData);

        sizePartition.SetActive(false);

        Button selectUnallocatedSpaceButton = objUnallocatedSpace.GetComponent<Button>();
        selectUnallocatedSpaceButton.onClick.AddListener(OnUnallocatedSpaceSelected);
    }

    // Update is called once per frame
    void Update()
    {
        Text unallocatedSpaceText = GameObject.Find("UnallocatedSpaceText").GetComponent<Text>();
        Text freeSpaceText = GameObject.Find("freeSpaceText").GetComponent<Text>();
        unallocatedSpaceText.text = unallocatedSpaceInGB + " GB";
        freeSpaceText.text = unallocatedSpaceInGB + " GB";
    }

    public void OnUnallocatedSpaceSelected()
    {
        isUnallocatedSpaceSelected = true;
    }

    void ShowInputSize()
    {
        // Setelah tombol "btnNew" ditekan, aktifkan kembali objek "SizePartition"
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
        //InputField sizeInputField = GameObject.Find("SizeInputField").GetComponent<InputField>();
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
                    Destroy(objUnallocatedSpace);
                    btnNew.interactable = false;
                    btnNew.GetComponentInChildren<Text>().color = Color.gray;
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
        // Membuat nama objek partisi baru
        string partitionObjectName = "Partition " + (newPartitionCount + 1);

        // Membuat objek partisi baru
        GameObject newButton = Instantiate(buttonTemplate, scrollViewContent.transform);
        newButton.name = partitionObjectName;
        newButton.tag = "Partition"; // Menambahkan tag "Partition" agar bisa dideteksi saat klik

        // Akses komponen-komponen text pada button baru dan atur teksnya sesuai dengan data yang diinginkan
        Text tvNamePartition = newButton.transform.Find("tvNamePartition").GetComponent<Text>();
        Text tvTotalSize = newButton.transform.Find("tvTotalSize").GetComponent<Text>();
        Text tvFreeSpace = newButton.transform.Find("tvFreeSpace").GetComponent<Text>();
        Text tvTypePartition = newButton.transform.Find("tvTypePartition").GetComponent<Text>();

        tvNamePartition.text = "Drive 0 " + partitionObjectName;
        tvTotalSize.text = partitionSizeInGB + " GB";
        tvFreeSpace.text = partitionSizeInGB + " GB";
        tvTypePartition.text = "Type: NTFS";

        //btnDelete.interactable = true;
        //btnFormat.interactable = true;
        sizePartition.SetActive(false);

        // Menyimpan informasi partisi ke dalam PlayerPrefs
        string partitionKey = "Partition_" + (newPartitionCount + 1);
        PlayerPrefs.SetString(partitionKey + "_Name", "Drive 0 " + partitionObjectName);
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

    public void DeletePartition(GameObject partitionObject)
    {
        // Mendapatkan total ukuran partisi yang dihapus
        Text tvTotalSize = partitionObject.transform.Find("tvTotalSize").GetComponent<Text>();
        int partitionSizeInGB = int.Parse(tvTotalSize.text.Replace(" GB", ""));

        // Menambahkan ukuran partisi yang dihapus ke Unallocated Space
        unallocatedSpaceInGB += partitionSizeInGB;

        // Hapus objek partisi dari hierarki game
        Destroy(partitionObject);

        // Kurangi jumlah partisi yang telah dibuat
        newPartitionCount--;

        // Jika objUnallocatedSpace null atau tidak ada dalam hierarki, buat kembali objek objUnallocatedSpace
        if (objUnallocatedSpace == null || !objUnallocatedSpace.activeInHierarchy)
        {
            objUnallocatedSpace = Instantiate(objUnallocatedSpacePrefab, scrollViewContent.transform); // Ubah dengan nilai yang sesuai
            objUnallocatedSpace.transform.SetSiblingIndex(1);
        }

        // Simpan perubahan ke PlayerPrefs
        PlayerPrefs.SetInt("PartitionCount", newPartitionCount);
        PlayerPrefs.Save();

        // Perbarui status tombol delete
        //btnDelete.interactable = newPartitionCount > 0;
    }
}
