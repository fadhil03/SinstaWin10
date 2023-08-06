using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartitionManager : MonoBehaviour
{
    public GameObject scrollViewContent;
    public GameObject buttonTemplate;
    public GameObject objUnallocatedSpace;
    private int[] possibleSizes = { 128, 256, 512, 1024 };
    private int unallocatedSpaceInGB;
    private int newButtonCount = 0; // Melacak berapa kali button "ButtonNew" ditekan.

    // Start is called before the first frame update
    void Start()
    {
        int randomIndex = Random.Range(0, possibleSizes.Length);
        unallocatedSpaceInGB = possibleSizes[randomIndex];
        Debug.Log("Unallocated Space: " + unallocatedSpaceInGB + " GB");
        Text unallocatedSpaceText = GameObject.Find("UnallocatedSpaceText").GetComponent<Text>();
        Text freeSpaceText = GameObject.Find("freeSpaceText").GetComponent<Text>();
        unallocatedSpaceText.text = unallocatedSpaceInGB + " GB";
        freeSpaceText.text = unallocatedSpaceInGB + " GB";


        Button newButton = GameObject.Find("ButtonNew").GetComponent<Button>();
        newButton.onClick.AddListener(OnNewButtonClicked);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnNewButtonClicked()
    {
        InputField sizeInputField = GameObject.Find("SizeInputField").GetComponent<InputField>();
        if (int.TryParse(sizeInputField.text, out int partitionSizeInMB))
        {
            // Konversi dari MB ke GB
            int partitionSizeInGB = partitionSizeInMB / 1000;

            // Cek apakah ukuran partisi yang dimasukkan tidak melebihi Unallocated Space yang tersedia
            if (partitionSizeInGB <= unallocatedSpaceInGB)
            {
                CreateNewButton(partitionSizeInGB);
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

    void CreateNewButton(int partitionSizeInGB)
    {
        GameObject newButton = Instantiate(buttonTemplate, scrollViewContent.transform);

        // Akses komponen-komponen text pada button baru dan atur teksnya sesuai dengan data yang diinginkan
        Text tvNamePartition = newButton.transform.Find("tvNamePartition").GetComponent<Text>();
        Text tvTotalSize = newButton.transform.Find("tvTotalSize").GetComponent<Text>();
        Text tvFreeSpace = newButton.transform.Find("tvFreeSpace").GetComponent<Text>();
        Text tvTypePartition = newButton.transform.Find("tvTypePartition").GetComponent<Text>();

        tvNamePartition.text = "Drive 0 Partition " + newButtonCount;
        tvTotalSize.text = partitionSizeInGB + " GB";
        tvFreeSpace.text = partitionSizeInGB + " GB";
        tvTypePartition.text = "Type: NTFS";

        newButtonCount++;
    }


}
