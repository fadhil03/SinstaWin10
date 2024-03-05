using UnityEngine;
using TMPro;

public class ItemHistoryDisplay : MonoBehaviour
{
    public TextMeshProUGUI[] textFields; // Array of Text components

    // Method to set text for each child Text component based on field name and value
    public void SetText(string fieldName, string fieldValue)
    {
        // Loop through all child Text components
        foreach (TextMeshProUGUI textField in textFields)
        {
            // Check if the Text component's name matches the field name
            if (textField.name.Equals(fieldName))
            {
                // Set the text value
                textField.text = fieldValue;
                return; // Exit the loop if the text is set
            }
        }
    }
}
