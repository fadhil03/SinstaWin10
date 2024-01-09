using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitMenuController : MonoBehaviour
{
    public GameObject[] items; // Array dari semua item yang ada di panel
    private int selectedItemIndex = 0; // Index dari item yang sedang dipilih

    private void Update()
    {
        // Navigasi menggunakan tombol panah
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            // Menentukan indeks item selanjutnya
            selectedItemIndex = (selectedItemIndex + 1) % items.Length;
            UpdateSelection();
            Debug.Log("sekarang indeks selanjutnya adalah: " + selectedItemIndex);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            // Menentukan indeks item sebelumnya
            selectedItemIndex = (selectedItemIndex - 1 + items.Length) % items.Length;
            UpdateSelection();
            Debug.Log("sekarang indeks sebelumnya adalah: " + selectedItemIndex);
        }

        // Eksekusi fungsi item ketika tombol Enter ditekan
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ExecuteItemFunction();
        }
    }

    private void UpdateSelection()
    {
        // Hilangkan highlight semua item
        foreach (var item in items)
        {
            Button buttonComponent = item.GetComponent<Button>();
            ColorBlock colorBlock = buttonComponent.colors;
            colorBlock.normalColor = Color.white; // asumsi warna default adalah putih
            buttonComponent.colors = colorBlock;
        }

        // Highlight item yang sedang dipilih
        Button selectedButtonComponent = items[selectedItemIndex].GetComponent<Button>();
        ColorBlock selectedColorBlock = selectedButtonComponent.colors;
        selectedColorBlock.normalColor = Color.white; // asumsi warna highlight adalah putih
        selectedButtonComponent.colors = selectedColorBlock;
    }




    private void ExecuteItemFunction()
    {
        switch (selectedItemIndex)
        {
            case 0:
                ExitSavingChanges();
                break;
            case 1:
                ExitDiscardingChanges();
                break;
            case 2:
                LoadSetupDefaults();
                break;
            case 3:
                DiscardChanges();
                break;
            case 4:
                SaveChanges();
                break;
        }
    }

    public void HandleButtonClick(int itemIndex)
    {
        selectedItemIndex = itemIndex;

        Color defaultColor = new Color(0, 0, 0.666f); // RGB untuk 0000AA

        // Set warna semua teks kembali ke default (0000AA)
        foreach (var item in items)
        {
            Text textComponent = item.transform.Find("tvChildTitle").GetComponent<Text>();
            if (textComponent != null)
            {
                textComponent.color = defaultColor;
            }
        }

        // Set warna teks dari tombol yang diklik menjadi putih
        Text clickedTextComponent = items[selectedItemIndex].transform.Find("tvChildTitle").GetComponent<Text>();
        if (clickedTextComponent != null)
        {
            clickedTextComponent.color = Color.white;
        }

        ExecuteItemFunction();
    }

    private void ExitSavingChanges()
    {
        // Fungsi untuk "Exit Saving Changes" dimana akan PlayerPrefs.Save(); kemudian berpindah scene ke "InBios"
        SaveChanges(); // Menyimpan perubahan sebelum keluar
        SceneManager.LoadScene("Bios");
        Debug.Log("Exit Saving Changes");
    }

    private void ExitDiscardingChanges()
    {
        // Fungsi untuk "Exit Discarding Changes" dimana akan menghapus value yang ada dalam PlayerPrefs ItemBootableBios kemudian berpindah scene ke "InBios" 
        DiscardChanges(); // Membuang perubahan sebelum keluar
        SceneManager.LoadScene("Bios");
        Debug.Log("Exit Discarding Changes");
    }

    private void LoadSetupDefaults()
    {
        // Fungsi untuk "Load Setup Defaults" dimana akan mengisi PlayerPrefs ItemBootableBios dengan value "ItemHardDrive"
        PlayerPrefs.SetString("ItemBootableBios", "ItemHardDrive");
        PlayerPrefs.Save();
        Debug.Log("Load Setup Defaults");
    }

    private void DiscardChanges()
    {
        // Fungsi untuk "Discard Changes" dimana akan menghapus value yang ada dalam PlayerPrefs ItemBootableBios
        PlayerPrefs.DeleteKey("ItemBootableBios");
        PlayerPrefs.Save();
        Debug.Log("Discard Changes");
    }

    private void SaveChanges()
    {
        // Fungsi untuk "Save Changes" dimana akan PlayerPrefs.Save();
        PlayerPrefs.Save();
        Debug.Log("Save Changes");
    }
}
