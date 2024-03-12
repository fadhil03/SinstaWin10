using UnityEngine;
using UnityEngine.UI;

public class ProductKeyInpVal : MonoBehaviour
{
    public InputField ifProductKey;
    public Button nextButton;
    public Button noKeyButton;
    public GameObject panel3;
    public GameObject panel4;
    public GameObject progressBar;

    private void Start()
    {
        // Menambahkan fungsi callback ke input field
        ifProductKey.onValueChanged.AddListener(ValidateInput);

        // Menambahkan fungsi callback ke tombol next
        nextButton.onClick.AddListener(NextButtonClicked);
        noKeyButton.onClick.AddListener(NextButtonClicked);

        // Menonaktifkan tombol next secara awal
        nextButton.interactable = false;
    }

    private void OnEnable()
    {
        progressBar.SetActive(true);
        PlayerPrefs.SetString("Product_Key", "-");
        PlayerPrefs.Save();
    }

    private void ValidateInput(string value)
    {
        // Memeriksa apakah input field memiliki 25 karakter atau lebih
        if (value.Length >= 25)
        {
            // Memasukkan nilai input ke dalam PlayerPrefs jika panjangnya lebih dari atau sama dengan 25
            PlayerPrefs.SetString("Product_Key", value);
            PlayerPrefs.Save();

            // Mengaktifkan tombol next jika input field memenuhi syarat
            nextButton.interactable = true;
        }
        else
        {
            // Menyimpan "-" ke dalam PlayerPrefs jika panjang nilai input kurang dari 25
            PlayerPrefs.SetString("Product_Key", "-");
            PlayerPrefs.Save();

            // Menonaktifkan tombol next jika input field tidak memenuhi syarat
            nextButton.interactable = false;
        }
    }

    private void NextButtonClicked()
    {
        // Implementasikan logika untuk tindakan yang akan dilakukan saat tombol next ditekan
        Debug.Log("Tombol Next ditekan!");
        panel3.SetActive(false);
        panel4.SetActive(true);
    }
}
