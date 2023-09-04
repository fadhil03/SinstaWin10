using UnityEngine;
using UnityEngine.UI;

public class ButtonEnablerDisabler : MonoBehaviour
{
    public Button myButton; // Tarik tombol ke sini dari Inspector
    public Text buttonText; // Tarik komponen Text dari tombol ke sini
    public Color activeColor = Color.blue; // Warna teks saat tombol aktif
    public Color inactiveColor = Color.gray; // Warna teks saat tombol tidak aktif

    private void Start()
    {
        // Menonaktifkan tombol saat permainan dimulai
        EnableButton();
    }

    public void EnableButton()
    {
        myButton.interactable = true; // Mengaktifkan tombol
        buttonText.color = activeColor; // Mengubah warna teks saat tombol aktif
    }

    public void DisableButton()
    {
        myButton.interactable = false; // Menonaktifkan tombol
        buttonText.color = inactiveColor; // Mengubah warna teks saat tombol tidak aktif
    }
}
