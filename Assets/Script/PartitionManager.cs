using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartitionManager : MonoBehaviour
{
    public GameObject scrollViewContent;
    public GameObject buttonTemplate;
    private int buttonCount = 5; // Jumlah button awal, bisa Anda ubah sesuai kebutuhan.
    private int newButtonCount = 0; // Melacak berapa kali button "New" ditekan.

    // Start is called before the first frame update
    void Start()
    {
        CreateInitialButtons();

        // Tambahkan event listener untuk tombol "New"
        Button newButton = GameObject.Find("ButtonNew").GetComponent<Button>();
        newButton.onClick.AddListener(OnNewButtonClicked);
    }

    // Update is called once per frame
    void Update()
    {
    }

    // Method untuk membuat button-button awal
    void CreateInitialButtons()
    {
        for (int i = 0; i < buttonCount; i++)
        {
            CreateNewButton();
        }
    }

    // Method untuk membuat satu button baru
    void CreateNewButton()
    {
        GameObject newButton = Instantiate(buttonTemplate, scrollViewContent.transform);
        newButton.GetComponentInChildren<Text>().text = "Button " + (newButtonCount + 1);
        newButtonCount++;
    }

    // Method untuk menangani aksi saat button "New" ditekan
    public void OnNewButtonClicked()
    {
        CreateNewButton();
    }
}
