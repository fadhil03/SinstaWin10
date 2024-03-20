using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardLayoutPanel : MonoBehaviour
{
    public enum KeyboardLayoutGroup
    {
        Primary,
        Secondary
    }

    [SerializeField]
    private KeyboardLayoutGroup selectedLayoutGroup = KeyboardLayoutGroup.Primary;


    public GameObject scrollViewContent;
    public GameObject objKeyboard;
    public Button nextButton;

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

    string[] listSecondKeyboardLayouts = {
    "ADLaM",
    "Albanian",
    "Arabic (101)",
    "Arabic (102)",
    "Arabic (102) AZERTY",
    "Armenian Eastern (Legacy)",
    "Armenian Phonetic",
    "Armenian Typewriter",
    "Armenian Western (Legacy)",
    "Assamese - INSCRIPT",
    "Azerbaijani (Standard)",
    "Azerbaijani Cyrillic",
    "Azerbaijani Latin",
    "Bangla",
    "Bangla - INSCRIPT",
    "Bangla - INSCRIPT (Legacy)",
    "Bashkir",
    "Belarusian",
    "Belgian (Comma)",
    "Belgian (Period)",
    "Belgian French",
    "Bosnian (Cyrillic)",
    "Buginese",
    "Bulgarian",
    "Bulgarian (Latin)",
    "Bulgarian (Phonetic Traditional)",
    "Bulgarian (Phonetic)",
    "Bulgarian (Typewriter)",
    "Canadian French",
    "Canadian French (Legacy)",
    "Canadian Multilingual Standard",
    "Central Atlas Tamazight",
    "Central Kurdish",
    "Cherokee Nation",
    "Cherokee Phonetic",
    "Chinese (Simplified) - US",
    "Chinese (Simplified, Singapore) - US",
    "Chinese (Traditional) - US",
    "Chinese (Traditional, Hong Kong S.A.R.) - US",
    "Chinese (Traditional, Macao S.A.R.) - US",
    "Czech",
    "Czech (QWERTY)",
    "Czech Programmers",
    "Danish",
    "Devanagari - INSCRIPT",
    "Divehi Phonetic",
    "Divehi Typewriter",
    "Dutch",
    "Dzongkha",
    "English (India)",
    "Estonian",
    "Faeroese",
    "Finnish",
    "Finnish with Sami",
    "French",
    "Futhark",
    "Georgian (Ergonomic)",
    "Georgian (Legacy)",
    "Georgian (MES)",
    "Georgian (Old Alphabets)",
    "Georgian (QWERTY)",
    "German",
    "German (IBM)",
    "Gothic",
    "Greek",
    "Greek (220)",
    "Greek (220) Latin",
    "Greek (319)",
    "Greek (319) Latin",
    "Greek Latin",
    "Greek Polytonic",
    "Greenlandic",
    "Guarani",
    "Gujarati",
    "Hausa",
    "Hawaiian",
    "Hebrew",
    "Hebrew (Standard)",
    "Hindi Traditional",
    "Hungarian",
    "Hungarian 101-key",
    "Icelandic",
    "Igbo",
    "Inuktitut - Latin",
    "Inuktitut - Naqittaut",
    "Irish",
    "Italian",
    "Italian (142)",
    "Japanese",
    "Javanese",
    "Kannada",
    "Kazakh",
    "Khmer",
    "Khmer (NIDA)",
    "Korean",
    "Kyrgyz Cyrillic",
    "Lao",
    "Latin American",
    "Latvian",
    "Latvian (QWERTY)",
    "Latvian (Standard)",
    "Lisu (Basic)",
    "Lisu (Standard)",
    "Lithuanian",
    "Lithuanian IBM",
    "Lithuanian Standard",
    "Luxembourgish",
    "Macedonian (North Macedonia)",
    "Macedonian (North Macedonia) - Standard",
    "Malayalam",
    "Maltese 47-Key",
    "Maltese 48-Key",
    "Maori",
    "Marathi",
    "Mongolian (Mongolian Script)",
    "Mongolian Cyrillic",
    "Myanmar (Phonetic order)",
    "Myanmar (Visual order)",
    "Nepali",
    "New Tai Lue",
    "N’Ko",
    "Norwegian",
    "Norwegian with Sami",
    "NZ Aotearoa",
    "Odia",
    "Ogham",
    "Ol Chiki",
    "Old Italic",
    "Osage",
    "Osmanya",
    "Pashto (Afghanistan)",
    "Persian",
    "Persian (Standard)",
    "Phags-pa",
    "Polish (214)",
    "Polish (Programmers)",
    "Portuguese",
    "Portuguese (Brazil ABNT)",
    "Portuguese (Brazil ABNT2)",
    "Punjabi",
    "Romanian (Legacy)",
    "Romanian (Programmers)",
    "Romanian (Standard)",
    "Russian",
    "Russian - Mnemonic",
    "Russian (Typewriter)",
    "Sakha",
    "Sami Extended Finland-Sweden",
    "Sami Extended Norway",
    "Scottish Gaelic",
    "Serbian (Cyrillic)",
    "Serbian (Latin)",
    "Sesotho sa Leboa",
    "Setswana",
    "Sinhala",
    "Sinhala - Wij 9",
    "Slovak",
    "Slovak (QWERTY)",
    "Slovenian",
    "Sora",
    "Sorbian Extended",
    "Sorbian Standard",
    "Sorbian Standard (Legacy)",
    "Spanish",
    "Spanish Variation",
    "Standard",
    "Swedish",
    "Swedish with Sami",
    "Swiss French",
    "Swiss German",
    "Syriac",
    "Syriac Phonetic",
    "Tai Le",
    "Tajik",
    "Tamil",
    "Tamil 99",
    "Tamil Anjal",
    "Tatar",
    "Tatar (Legacy)",
    "Telugu",
    "Thai Kedmanee",
    "Thai Kedmanee (non-ShiftLock)",
    "Thai Pattachote",
    "Thai Pattachote (non-ShiftLock)",
    "Tibetan (PRC)",
    "Tibetan (PRC) - Updated",
    "Tifinagh (Basic)",
    "Tifinagh (Extended)",
    "Traditional Mongolian (Standard)",
    "Turkish F",
    "Turkish Q",
    "Turkmen",
    "Ukrainian",
    "Ukrainian (Enhanced)",
    "United Kingdom",
    "United Kingdom Extended",
    "United States-Dvorak",
    "United States-Dvorak for left hand",
    "United States-Dvorak for right hand",
    "United States-International",
    "Urdu",
    "US",
    "US English Table for IBM Arabic 238_L",
    "Uyghur",
    "Uyghur (Legacy)",
    "Uzbek Cyrillic",
    "Vietnamese",
    "Wolof",
    "Yoruba"
};

    void Start()
    {
        string[] activeLayoutArray = selectedLayoutGroup == KeyboardLayoutGroup.Primary ? listKeyboardLayouts : listSecondKeyboardLayouts;

        Color normalColor = new Color32(0, 66, 117, 255);  // #004275
        Color pressedAndSelectedColor = new Color32(0, 98, 176, 255);  // #0062b0

        for (int i = 0; i < activeLayoutArray.Length; i++)
        {
            GameObject listKeyboard = (GameObject)Instantiate(objKeyboard);
            listKeyboard.transform.SetParent(scrollViewContent.transform);
            listKeyboard.transform.localPosition = new Vector3(0f, 0f, 0f);

            Text childText = listKeyboard.GetComponentInChildren<Text>();
            if (childText != null)
            {
                childText.text = activeLayoutArray[i];
            }

            Button button = listKeyboard.GetComponent<Button>();
            if (button != null)
            {
                ColorBlock colors = button.colors;
                colors.normalColor = normalColor;
                colors.pressedColor = pressedAndSelectedColor;
                colors.selectedColor = pressedAndSelectedColor;
                button.colors = colors;
                button.onClick.AddListener(() => OnKeyboardLayoutButtonClick(childText.text));
            }
            listKeyboard.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    void OnKeyboardLayoutButtonClick(string layout)
    {
        // Simpan nilai teks tombol keyboard yang diklik ke dalam PlayerPrefs
        PlayerPrefs.SetString("KeyboardLayout", layout);
        Debug.Log("Selected Keyboard Layout: " + layout);
        CheckNextButtonInteractable();
    }

    void CheckNextButtonInteractable()
    {
        // Cek apakah nilai Region telah diset di PlayerPrefs
        if (PlayerPrefs.HasKey("KeyboardLayout"))
        {
            // Jika telah diset, aktifkan tombol next
            nextButton.interactable = true;
        }
        else
        {
            // Jika belum diset, jadikan tombol next tidak interaktif
            nextButton.interactable = false;
        }
    }

    private void Update()
    {

    }

}