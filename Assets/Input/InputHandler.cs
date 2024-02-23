using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
    private Camera _mainCamera;
    private GameObject _selectedPartition;
    private PartitionManager _partitionManager;
    public Button btnDelete;
    public Button btnFormat;
    public Button btnNew;
    public Color activeColor = Color.blue; // Warna teks saat tombol aktif
    public Color inactiveColor = Color.gray; // Warna teks saat tombol tidak aktif

    private bool btnDeleteClicked = false;

    void Awake()
    {
        _mainCamera = Camera.main;
        _partitionManager = FindObjectOfType<PartitionManager>();
        if (_partitionManager == null)
        {
            Debug.LogError("PartitionManager not found.");
        }
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        Vector2 mousePos;

        #if UNITY_ANDROID || UNITY_IOS
            // Jika aplikasi berjalan di perangkat mobile, gunakan input sentuh
            if (Input.touchCount > 0)
            {
                mousePos = Input.GetTouch(0).position;
            }
            else
            {
                return;
            }
        #else
            // Jika aplikasi berjalan di PC, gunakan input mouse
            mousePos = Input.mousePosition;
        #endif

        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(mousePos));
        if (!rayHit.collider)
        {
            // Jika tidak ada objek yang tertabrak, lakukan pengecekan terus menerus hingga tombol Delete diklik
            StartCoroutine(WaitForDeleteButtonClick());
            return;
        }

        Debug.Log("Object yang sedang di click = " + rayHit.collider.gameObject.name);

        if (rayHit.collider.CompareTag("Partition"))
        {
            _selectedPartition = rayHit.collider.gameObject;
            btnDelete.interactable = true;
            btnFormat.interactable = true;
            btnDelete.GetComponentInChildren<Text>().color = activeColor;
            btnFormat.GetComponentInChildren<Text>().color = activeColor;

            btnNew.interactable = false;
            btnNew.GetComponentInChildren<Text>().color = inactiveColor;
        }

        if (rayHit.collider.CompareTag("UnallocatedSpace"))
        {
            _selectedPartition = rayHit.collider.gameObject;
            btnNew.interactable = true;
            btnNew.GetComponentInChildren<Text>().color = activeColor;
            // Nonaktifkan tombol Delete dan Format setelah tombol Delete diklik
            btnDelete.interactable = false;
            btnFormat.interactable = false;

            // Ubah warna teks tombol delete menjadi abu-abu
            btnDelete.GetComponentInChildren<Text>().color = inactiveColor;
            btnFormat.GetComponentInChildren<Text>().color = inactiveColor;
        }
        else
        {
            btnNew.interactable = false;
            btnNew.GetComponentInChildren<Text>().color = inactiveColor;
        }
    }

    IEnumerator WaitForDeleteButtonClick()
    {
        // Tunggu sampai tombol Delete diklik
        yield return new WaitUntil(() => btnDeleteClicked);

        // Nonaktifkan tombol Delete dan Format setelah tombol Delete diklik
        btnDelete.interactable = false;
        btnFormat.interactable = false;

        // Ubah warna teks tombol delete menjadi abu-abu
        btnDelete.GetComponentInChildren<Text>().color = inactiveColor;
        btnFormat.GetComponentInChildren<Text>().color = inactiveColor;

        // Setelah tombol Delete diklik, set btnDeleteClicked kembali ke false
        btnDeleteClicked = false;
    }

    private void Update()
    {
        //Debug.Log(" btnDeleteClicked= " + btnDeleteClicked);
    }

    public void OnDeleteButtonClick()
    {
        if (_selectedPartition != null)
        {
            _partitionManager.DeletePartition(_selectedPartition);
            _selectedPartition = null;
        }
        else
        {
            Debug.Log("No partition selected for deletion.");
        }
        btnDeleteClicked = true;

        // Mulai coroutine untuk mengatur kembali btnDeleteClicked ke false setelah jeda
        StartCoroutine(ResetBtnDeleteClicked());
    }

    IEnumerator ResetBtnDeleteClicked()
    {
        // Tunggu 1 detik sebelum mengatur kembali btnDeleteClicked ke false
        yield return new WaitForSeconds(1f);
        btnDeleteClicked = false;
    }
}