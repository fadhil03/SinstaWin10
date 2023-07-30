using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartitionManager : MonoBehaviour
{
    public GameObject scrollViewContent;
    public GameObject buttonTemplate;
    private int unallocatedSpaceInGB = 500;
    private int newButtonCount = 0; // Melacak berapa kali button "ButtonNew" ditekan.

    // Start is called before the first frame update
    void Start()
    {
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
                Debug.Log("Sisa Unlocaled: " + unallocatedSpaceInGB);
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
        newButton.GetComponentInChildren<Text>().text = "Partition Size: " + partitionSizeInGB + " GB";
        newButtonCount++;
    }
}
