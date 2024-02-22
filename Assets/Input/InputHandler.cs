using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private Camera _mainCamera;
    private GameObject _selectedPartition; // Menyimpan objek partisi yang sedang diklik
    private PartitionManager _partitionManager; // Referensi ke PartitionManager

    // Start is called before the first frame update
    void Awake()
    {
        _mainCamera = Camera.main;
        _partitionManager = FindObjectOfType<PartitionManager>(); // Cari PartitionManager di scene
        if (_partitionManager == null)
        {
            Debug.LogError("PartitionManager not found.");
        }
    }

    // Update is called once per frame
    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (!rayHit.collider) return;

        Debug.Log("Object yang sedang di click = " + rayHit.collider.gameObject.name);

        // Jika objek yang diklik adalah partisi
        if (rayHit.collider.CompareTag("Partition"))
        {
            _selectedPartition = rayHit.collider.gameObject;
        }
    }

    public void OnDeleteButtonClick()
    {
        if (_selectedPartition != null)
        {
            // Panggil method DeletePartition di PartitionManager
            _partitionManager.DeletePartition(_selectedPartition);
            _selectedPartition = null; // Reset objek partisi yang dipilih setelah dihapus
        }
        else
        {
            Debug.Log("No partition selected for deletion.");
        }
    }
}
