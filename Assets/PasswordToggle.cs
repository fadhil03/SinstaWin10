using UnityEngine;
using UnityEngine.UI;

public class PasswordToggle : MonoBehaviour
{
    public InputField passwordInputField;
    public Button showHideButton;
    public Image bgToggle; // Tambahkan referensi ke game object image
    public Image icoToggle;
    public Color visibleColor = new Color(0, 0.467f, 0.843f); // Warna biru (0077D7)

    private bool isPasswordVisible = false;

    private void Start()
    {
        // Inisialisasi fungsi tombol
        showHideButton.onClick.AddListener(TogglePasswordVisibility);
    }

    private void TogglePasswordVisibility()
    {
        isPasswordVisible = !isPasswordVisible;
        passwordInputField.contentType = isPasswordVisible ? InputField.ContentType.Standard : InputField.ContentType.Password;
        passwordInputField.ForceLabelUpdate(); // Perbarui tampilan InputField

        // Ubah warna game object image sesuai dengan isPasswordVisible
        bgToggle.color = isPasswordVisible ? visibleColor : Color.white;
        icoToggle.color = isPasswordVisible ? Color.white : Color.gray;
    }
}
