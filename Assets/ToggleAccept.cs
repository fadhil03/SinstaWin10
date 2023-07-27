using UnityEngine;
using UnityEngine.UI;

public class ToggleAccept : MonoBehaviour
{
    public Toggle checkbox;
    public Button nextButton;

    private void Start()
    {
        // Pastikan checkbox tidak tercentang pada awal permainan
        checkbox.isOn = false;

        // Pastikan tombol "Next" dinonaktifkan pada awal permainan
        nextButton.interactable = false;

        // Tambahkan listener ke perubahan state checkbox
        checkbox.onValueChanged.AddListener(OnCheckboxValueChanged);
    }

    private void OnCheckboxValueChanged(bool isChecked)
    {
        // Jika checkbox dicentang, aktifkan tombol "Next"
        if (isChecked)
        {
            nextButton.interactable = true;
        }
        else
        {
            nextButton.interactable = false;
        }
    }
}