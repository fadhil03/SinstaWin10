using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InstallationProcess : MonoBehaviour
{
    public Text copyingFiles;
    public Text gettingFiles;
    public Text installingFeatures;
    public Text finishingUp;
    public GameObject imageComplete1;
    public GameObject imageComplete2;
    public GameObject imageComplete3;
    public GameObject imageComplete4;
    public GameObject nextPanel;
    public GameObject currentPanel;

    private int copyingFilesStartTime = 1; // 5 menit dalam detik
    private int gettingFilesStartTime = 15; // 10 menit dalam detik
    private int installingFeaturesStartTime = 20; // 6 menit dalam detik
    private int finisihingaUpStartTime = 25;
    private int endStartTime = 30;

    private void Start()
    {
        // Set teks awal yang tidak bold
        SetTextBold(copyingFiles, false);
        SetTextBold(gettingFiles, false);
        SetTextBold(installingFeatures, false);
        SetTextBold(finishingUp, false);
        imageComplete1.SetActive(false);
        imageComplete2.SetActive(false);
        imageComplete3.SetActive(false);
        imageComplete4.SetActive(false);
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
            imageComplete1.SetActive(true);
            // ...
        }

        // Cek apakah installingFeatures perlu dibuat bold dan menghilang
        if (currentTime >= installingFeaturesStartTime)
        {
            SetTextBold(copyingFiles, false);
            SetTextBold(gettingFiles, false);
            SetTextBold(installingFeatures, true);
            SetTextBold(finishingUp, false);
            imageComplete2.SetActive(true);
            // ...
        }

        // Cek apakah installingFeatures perlu dibuat bold dan menghilang
        if (currentTime >= finisihingaUpStartTime)
        {
            SetTextBold(copyingFiles, false);
            SetTextBold(gettingFiles, false);
            SetTextBold(installingFeatures, false);
            SetTextBold(finishingUp, true);
            imageComplete3.SetActive(true);
            // ...
        }

        if (currentTime >= endStartTime)
        {
            SetTextBold(copyingFiles, false);
            SetTextBold(gettingFiles, false);
            SetTextBold(installingFeatures, false);
            SetTextBold(finishingUp, false);
            imageComplete4.SetActive(true);
            StartCoroutine(DelayedExecution());
            // ...
        }
    }

    private void SetTextBold(Text text, bool isBold)
    {
        FontStyle style = isBold ? FontStyle.Bold : FontStyle.Normal;
        text.fontStyle = style;
    }

    private IEnumerator DelayedExecution()
    {
        Debug.Log("Menggunakan coroutine: Menunda eksekusi selama 2 detik");

        // Menunggu selama 2 detik
        yield return new WaitForSeconds(5f);
        currentPanel.SetActive(false);
        nextPanel.SetActive(true);
        // Kode yang akan dieksekusi setelah penundaan
        Debug.Log("Kode setelah penundaan 2 detik");

    }
}
