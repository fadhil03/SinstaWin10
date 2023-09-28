using UnityEngine;
using UnityEngine.UI;

public class ChangeItemOrder : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject[] items; // Array untuk menyimpan semua Item
    public Color selectedColor = new Color(1f, 1f, 1f); // Warna saat item terpilih
    public Color deselectedColor = new Color(0f, 0f, 0.6667f); // Warna saat item tidak terpilih

    private int selectedItemIndex = 0;

    void Start()
    {
        // Menetapkan warna awal untuk semua Item
        SetItemColors();
    }

    void Update()
    {
        // Navigasi ke bawah
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            NavigateToNextItem();
        }
        // Navigasi ke atas
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            NavigateToPreviousItem();
        }
        // Jika tombol F5 ditekan
        else if (Input.GetKeyDown(KeyCode.F5))
        {
            MoveUp();
        }
        // Jika tombol F6 ditekan
        else if (Input.GetKeyDown(KeyCode.F6))
        {
            MoveDown();
        }
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
}