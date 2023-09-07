using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DpTimeCurrency : MonoBehaviour
{
    public Dropdown dropTimeCurrency;
    public List<string> options = new List<string>()
{
    "Afrikaans (South Africa)",
    "Arabic (Saudi Arabia)",
    "Arabic (United Arab Emirates)",
    "Bengali (Bangladesh)",
    "Bengali (India)",
    "Chinese (China)",
    "Chinese (Hong Kong)",
    "Czech (Czech Republic)",
    "Danish (Denmark)",
    "Dutch (Netherlands)",
    "English (Australia)",
    "English (United Kingdom)",
    "Filipino (Philippines)",
    "Finnish (Finland)",
    "French (Canada)",
    "French (France)",
    "German (Germany)",
    "Greek (Greece)",
    "Hebrew (Israel)",
    "Hindi (India)",
    "Hungarian (Hungary)",
    "Indonesian (Indonesia)",
    "Irish (Ireland)",
    "Italian (Italy)",
    "Japanese (Japan)",
    "Japanese (Taiwan)",
    "Kannada (India)",
    "Korean (South Korea)",
    "Malay (Malaysia)",
    "Malayalam (India)",
    "Norwegian (Norway)",
    "Persian (Iran)",
    "Polish (Poland)",
    "Portuguese (Brazil)",
    "Portuguese (Portugal)",
    "Punjabi (Pakistan)",
    "Romanian (Romania)",
    "Russian (Russia)",
    "Slovak (Slovakia)",
    "Spanish (Argentina)",
    "Spanish (Mexico)",
    "Spanish (Spain)",
    "Swedish (Sweden)",
    "Swahili (Kenya)",
    "Tamil (India)",
    "Thai (Thailand)",
    "Turkish (Turkey)",
    "Ukrainian (Ukraine)",
    "Urdu (Pakistan)",
    "Vietnamese (Vietnam)"
};


    private void Start()
    {
        PopulateDropdown();
    }

    void PopulateDropdown()
    {
        dropTimeCurrency.ClearOptions();
        dropTimeCurrency.AddOptions(options);
    }
}