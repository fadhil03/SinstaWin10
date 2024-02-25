using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupNotifPartition : MonoBehaviour
{
    public GameObject ParentContainer;
    public GameObject PartitionSystemConfirm;
    public GameObject PartitionSystemSizeWarning;
    public GameObject PartitionDiskFullWarning;

    public Button WarningPartitionCountFull;
    public Button WarningPartitionSize;

    // Start is called before the first frame update
    void Start()
    {
        WarningPartitionCountFull.onClick.AddListener(() =>
        {
            PartitionDiskFullWarning.SetActive(true);
            ParentContainer.SetActive(true);
        });

        WarningPartitionSize.onClick.AddListener(() =>
        {
            PartitionSystemSizeWarning.SetActive(true);
            ParentContainer.SetActive(true);
        });
    }

    public void ClosePanel()
    {
        ParentContainer.SetActive(false);
        PartitionDiskFullWarning.SetActive(false);
        PartitionSystemSizeWarning.SetActive(false);
        PartitionSystemConfirm.SetActive(false);
    }
}
