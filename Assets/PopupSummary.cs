using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupSummary : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {


        return null;
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
