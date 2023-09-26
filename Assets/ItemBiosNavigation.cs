using UnityEngine;
using UnityEngine.UI;

public class ItemBiosNavigation : MonoBehaviour
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
            Debug.Log("Tombol bawah ditekan");
            NavigateToNextItem();
        }
        // Navigasi ke atas
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("Tombol atas ditekan");
            NavigateToPreviousItem();
        }
    }

    void NavigateToNextItem()
    {
        // Mengatur warna item sebelumnya menjadi tidak terpilih
        SetItemColor(selectedItemIndex, deselectedColor);

        // Menentukan indeks item selanjutnya
        selectedItemIndex = (selectedItemIndex + 1) % items.Length;

        // Mengatur warna item yang sedang terpilih
        SetItemColor(selectedItemIndex, selectedColor);
    }

    void NavigateToPreviousItem()
    {
        // Mengatur warna item sebelumnya menjadi tidak terpilih
        SetItemColor(selectedItemIndex, deselectedColor);

        // Menentukan indeks item sebelumnya
        selectedItemIndex = (selectedItemIndex - 1 + items.Length) % items.Length;

        // Mengatur warna item yang sedang terpilih
        SetItemColor(selectedItemIndex, selectedColor);
    }

    void SetItemColor(int itemIndex, Color color)
    {
        // Mengatur warna tvChildTitle pada Item yang diberikan
        Text tvChildTitle = items[itemIndex].transform.Find("tvChildTitle").GetComponent<Text>();
        if (tvChildTitle)
        {
            tvChildTitle.color = color;
        }
    }

    void SetItemColors()
    {
        // Mengatur warna awal untuk semua Item
        for (int i = 0; i < items.Length; i++)
        {
            SetItemColor(i, deselectedColor);
        }

        // Mengatur warna Item yang sedang terpilih
        SetItemColor(selectedItemIndex, selectedColor);
    }
}
