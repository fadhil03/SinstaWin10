using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class dpInputmetd : MonoBehaviour
{
    public TMP_Dropdown dropInputmetd;
    public List<string> options = new List<string>()
{
    "US",
    "Albanian",
    "Arabic (101)",
    "Arabic (102)",
    "Arabic (102) AZERTY",
    "US",
    "Lisu (Basic)",
    "Thai Kedmanee (non-ShiftLock)",
    "Bulgarian",
    "Canadian Multilingual Standard",
    "Croatian",
    "Czech (QWERTZ)",
    "Danish",
    "Estonian",
    "Finnish",
    "Greek",
    "Hebrew",
    "Hungarian",
    "Icelandic",
    "Italian",
    "Japanese (Romaji)",
    "Korean (Hangul)",
    "Latvian",
    "Lithuanian",
    "Norwegian",
    "Polish",
    "Portuguese (Brazil)",
    "Romanian",
    "Russian",
    "Serbian (Cyrillic)",
    "Slovak (QWERTZ)",
    "Slovenian",
    "Spanish",
    "Swedish",
    "Turkish",
    "Ukrainian",
    "Vietnamese"
};


    private void Start()
    {
        PopulateDropdown();
    }

    void PopulateDropdown()
    {
        dropInputmetd.ClearOptions();
        dropInputmetd.AddOptions(options);
    }
}
