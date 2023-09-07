using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class KeepButtonFocused : MonoBehaviour
{
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }
    }

    private void OnButtonClick()
    {
        // Setelah tombol diklik, kembalikan fokus ke tombol
        EventSystem.current.SetSelectedGameObject(gameObject);
    }
}
