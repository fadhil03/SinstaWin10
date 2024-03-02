using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ChangeItemOrder : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject[] items; // Array untuk menyimpan semua Item
    public Color selectedColor = new Color(1f, 1f, 1f); // Warna saat item terpilih
    public Color deselectedColor = new Color(0f, 0f, 0.6667f); // Warna saat item tidak terpilih

    private int selectedItemIndex = 0;
    private InputAction moveUpAction;
    private InputAction moveDownAction;
    private InputAction moveItemUpAction;
    private InputAction moveItemDownAction;

    void Start()
    {
        // Menetapkan warna awal untuk semua Item
        SetItemColors();

        // Mengecek dan memuat nama item dari PlayerPrefs
        LoadItemName();

        moveUpAction = new InputAction("Navigate Up", InputActionType.Button, "<Keyboard>/upArrow");
        moveUpAction.Enable();
        moveUpAction.performed += _ => NavigateToPreviousItem();
        moveDownAction = new InputAction("Navigate Down", InputActionType.Button, "<Keyboard>/downArrow");
        moveDownAction.Enable();
        moveDownAction.performed += _ => NavigateToNextItem();

        moveItemUpAction = new InputAction("Navigate Item Up", InputActionType.Button, "<Keyboard>/f5");
        moveItemUpAction.Enable();
        moveItemUpAction.performed += _ =>
        {
            MoveUp();
            SaveItemName();
        };
        moveItemDownAction = new InputAction("Navigate Item Down", InputActionType.Button, "<Keyboard>/f6");
        moveItemDownAction.Enable();
        moveItemDownAction.performed += _ =>
        {
            MoveDown(); 
            SaveItemName();
        };
     }   

    void Update()
    {
        // Navigasi ke bawah
/*        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            NavigateToNextItem();
        }
        // Navigasi ke atas
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            NavigateToPreviousItem();
        }*/
        // Jika tombol F5 ditekan
/*        if (Input.GetKeyDown(KeyCode.F5))
        {
            MoveUp();
            SaveItemName(); // Menyimpan nama item setelah perubahan urutan
        }
        // Jika tombol F6 ditekan
        else if (Input.GetKeyDown(KeyCode.F6))
        {
            MoveDown();
            SaveItemName(); // Menyimpan nama item setelah perubahan urutan
        }*/
    }

    void NavigateToNextItem()
    {
        SetItemColor(selectedItemIndex, deselectedColor);
        selectedItemIndex = (selectedItemIndex + 1) % items.Length;
        SetItemColor(selectedItemIndex, selectedColor);
    }

    void NavigateToPreviousItem()
    {
        SetItemColor(selectedItemIndex, deselectedColor);
        selectedItemIndex = (selectedItemIndex - 1 + items.Length) % items.Length;
        SetItemColor(selectedItemIndex, selectedColor);
    }

    void MoveUp()
    {
        if (selectedItemIndex == 0)
            return;

        Transform currentItem = items[selectedItemIndex].transform;
        currentItem.SetSiblingIndex(currentItem.GetSiblingIndex() - 1);

        // Menyesuaikan array items untuk menggambarkan perubahan urutan
        GameObject temp = items[selectedItemIndex];
        items[selectedItemIndex] = items[selectedItemIndex - 1];
        items[selectedItemIndex - 1] = temp;

        selectedItemIndex--;
    }

    void MoveDown()
    {
        if (selectedItemIndex == items.Length - 1)
            return;

        Transform currentItem = items[selectedItemIndex].transform;
        currentItem.SetSiblingIndex(currentItem.GetSiblingIndex() + 1);

        // Menyesuaikan array items untuk menggambarkan perubahan urutan
        GameObject temp = items[selectedItemIndex];
        items[selectedItemIndex] = items[selectedItemIndex + 1];
        items[selectedItemIndex + 1] = temp;

        selectedItemIndex++;
    }

    void SetItemColor(int itemIndex, Color color)
    {
        Text tvChildTitle = items[itemIndex].transform.Find("tvChildTitle").GetComponent<Text>();
        if (tvChildTitle)
        {
            tvChildTitle.color = color;
        }
    }

    void SetItemColors()
    {
        for (int i = 0; i < items.Length; i++)
        {
            SetItemColor(i, deselectedColor);
        }
        SetItemColor(selectedItemIndex, selectedColor);
    }

    void SaveItemName()
    {
        // Menyimpan nama item pada index ke-0 ke dalam PlayerPrefs
        string itemName = items[0].name;
        PlayerPrefs.SetString("ItemBootableBios", itemName);
        PlayerPrefs.Save();
    }

    void LoadItemName()
    {
        // Memuat nama item dari PlayerPrefs dan mengubah nama item pada index ke-0
        if (PlayerPrefs.HasKey("ItemBootableBios"))
        {
            string itemName = PlayerPrefs.GetString("ItemBootableBios");
            items[0].name = itemName;
        }
    }
}
