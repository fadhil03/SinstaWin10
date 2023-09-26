using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BiosButtonController : MonoBehaviour
{
    public Button[] buttons; // Drag and drop all 5 buttons here in the inspector

    private Color selectedButtonColor = new Color32(0xBB, 0xBB, 0xBB, 0xFF);
    private Color unselectedButtonColor = new Color32(0x00, 0x00, 0xAA, 0xFF);
    private Color highlightedButtonColor = new Color32(0xBB, 0xBB, 0xBB, 0xFF);
    private Color selectedTextColor = new Color32(0x00, 0x00, 0xAA, 0xFF); // This is the color for selected text
    private Color unselectedTextColor = new Color32(0xBB, 0xBB, 0xBB, 0xFF);
    private Color highlightedTextColor = new Color32(0x00, 0x00, 0xAA, 0xFF);

    private bool isMobile;

    private void Start()
    {
        // Cek jika perangkat saat ini adalah mobile
        isMobile = SystemInfo.deviceType == DeviceType.Handheld;

        foreach (Button button in buttons)
        {
            if (isMobile)
            {
                // Hanya tambahkan event click pada perangkat mobile
                button.onClick.AddListener(() => OnButtonClicked(button));
            }
            else
            {
                // Hapus semua event click pada perangkat selain mobile
                button.onClick.RemoveAllListeners();
            }
        }
    }

    private void OnButtonClicked(Button clickedButton)
    {
        foreach (Button button in buttons)
        {
            if (button == clickedButton)
            {
                SetButtonColor(button, selectedButtonColor, selectedTextColor); // The text color is set to 0000AA when selected
            }
            else
            {
                SetButtonColor(button, unselectedButtonColor, unselectedTextColor);
            }
        }
    }

    private void SetButtonColor(Button button, Color buttonColor, Color textColor)
    {
        ColorBlock colorBlock = button.colors;
        colorBlock.normalColor = buttonColor;
        colorBlock.highlightedColor = highlightedButtonColor;
        button.colors = colorBlock;

        Text buttonText = button.GetComponentInChildren<Text>();
        if (buttonText)
        {
            buttonText.color = textColor;
        }

        if (isMobile)
        {
            // Change text color when button is highlighted only on mobile
            EventTrigger eventTrigger = button.gameObject.GetComponent<EventTrigger>();
            if (eventTrigger == null)
            {
                eventTrigger = button.gameObject.AddComponent<EventTrigger>();
            }

            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerEnter;
            entry.callback.AddListener((eventData) => { buttonText.color = highlightedTextColor; });
            eventTrigger.triggers.Add(entry);

            entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerExit;
            entry.callback.AddListener((eventData) => { buttonText.color = textColor; });
            eventTrigger.triggers.Add(entry);
        }
    }
}
