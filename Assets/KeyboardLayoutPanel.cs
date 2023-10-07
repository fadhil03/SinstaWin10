using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardLayoutPanel : MonoBehaviour
{
    public GameObject scrollViewContent;
    public GameObject objKeyboard;

    string[] listKeyboardLayouts = {
        "US",
        "Canadian Multilingual Standard",
        "United Kingdom",
        "Irish",
        "English (India)",
        "Russian",
        "French",
        "German",
        "Spanish",
        "Italian",
        "Dutch",
        "Brazilian Portuguese",
        "Australian",
        "Maori",
        "Southern African",
        "Spanish (Latin America)",
        "Japanese",
        "Korean",
        "Simplified Chinese (Pinyin)",
        "Arabic",
        "Greek",
        "Turkish Q",
        "Swedish",
        "Norwegian",
        "Danish",
        "Polish (Programmers)",
        "Ukrainian",
        "Finnish",
        "Czech",
        "Hungarian",
        "Thai",
        "Hebrew",
        "Belgian",
        "Portuguese",
        "Slovak",
        "Romanian",
        "Serbian (Latin)",
        "Bulgarian",
        "Croatian",
        "Slovenian",
        "Latvian",
        "Lithuanian",
        "Estonian",
        "Icelandic",
        "Georgian",
        "Azerbaijani",
        "Kazakh",
        "Mongolian",
        "Bosnian",
        "Macedonian",
        "Belarusian",
        "Kyrgyz",
        "Tajik",
        "Turkmen",
        "Uzbek",
        "Pashto",
        "Sinhala",
        "Khmer",
        "Lao",
        "Burmese",
        "Maldivian Dhivehi",
        "Filipino",
        "Vietnamese",
        "Swahili"
     };



    void Start()
    {
        Color normalColor = new Color32(0, 66, 117, 255); // #004275
        Color pressedAndSelectedColor = new Color32(0, 98, 176, 255); // #0062b0

        for (int i = 0; i < listKeyboardLayouts.Length; i++)
        {
            GameObject listKeyboard = (GameObject)Instantiate(objKeyboard);
            listKeyboard.transform.SetParent(scrollViewContent.transform);

            Text childText = listKeyboard.GetComponentInChildren<Text>();
            if (childText != null)
            {
                childText.text = listKeyboardLayouts[i];
            }

            Button button = listKeyboard.GetComponent<Button>();
            if (button != null)
            {
                ColorBlock colors = button.colors;
                colors.normalColor = normalColor;
                colors.pressedColor = pressedAndSelectedColor;
                colors.selectedColor = pressedAndSelectedColor;
                button.colors = colors;
            }
            listKeyboard.transform.localScale = new Vector3(1f, 1f, 1f);
        }

    }

    private void Update()
    {

    }

}