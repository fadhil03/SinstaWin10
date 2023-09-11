using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InstallationProcess : MonoBehaviour
{
    public Text copyingFiles;
    public Text gettingFiles;
    public Text installingFeatures;
    public Text finishingUp;

    private int copyingFilesStartTime = 1; // 5 menit dalam detik
    private int gettingFilesStartTime = 15; // 10 menit dalam detik
    private int installingFeaturesStartTime = 20; // 6 menit dalam detik
    private int finisihingaUpStartTime = 25;

    private void Start()
    {
        // Set teks awal yang tidak bold
        SetTextBold(copyingFiles, false);
        SetTextBold(gettingFiles, false);
        SetTextBold(installingFeatures, false);
        SetTextBold(finishingUp, false);
    }

    private void Update()
    {
        int currentTime = (int)Time.time;
        Debug.Log("Nilai current time adalah: " + currentTime);

        // Cek apakah copyingFiles perlu dibuat bold dan menghilang
        if (currentTime >= copyingFilesStartTime)
        {
            SetTextBold(copyingFiles, true);
            SetTextBold(gettingFiles, false);
            SetTextBold(installingFeatures, false);
            SetTextBold(finishingUp, false);
            // ...
        }

        // Cek apakah gettingFiles perlu dibuat bold dan menghilang
        if (currentTime >= gettingFilesStartTime)
        {
            SetTextBold(copyingFiles, false);
            SetTextBold(gettingFiles, true);
            SetTextBold(installingFeatures, false);
            SetTextBold(finishingUp, false);
            // ...
        }

        // Cek apakah installingFeatures perlu dibuat bold dan menghilang
        if (currentTime >= installingFeaturesStartTime)
        {
            SetTextBold(copyingFiles, false);
            SetTextBold(gettingFiles, false);
            SetTextBold(installingFeatures, true);
            SetTextBold(finishingUp, false);
            // ...
        }

        // Cek apakah installingFeatures perlu dibuat bold dan menghilang
        if (currentTime >= finisihingaUpStartTime)
        {
            SetTextBold(copyingFiles, false);
            SetTextBold(gettingFiles, false);
            SetTextBold(installingFeatures, false);
            SetTextBold(finishingUp, true);
            // ...
        }
    }

    private void SetTextBold(Text text, bool isBold)
    {
        FontStyle style = isBold ? FontStyle.Bold : FontStyle.Normal;
        text.fontStyle = style;
    }
}
