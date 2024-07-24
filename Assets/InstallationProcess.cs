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
    public GameObject progressBarPanel;
    public GameObject progressBarPanel2;
    public bool run = false;
    public Button btnNextPanel7;
    public Button btnNextPanel7Second;

    private int copyingFilesStartTime = 0; // 5 menit dalam detik
    private int gettingFilesStartTime = 180; // 10 menit dalam detik
    private int installingFeaturesStartTime = 360; // 6 menit dalam detik
    private int finishingUpStartTime = 540;
    private int endStartTime = 600;

    public Text progressTextCopyingFiles;
    public Text progressTextGettingFiles;
    public Text progressTextInstallingFeatures;
    public Text progressTextFinishingUp;

    private IEnumerator Start()
    {
        btnNextPanel7.onClick.AddListener(OnBtnNextPanel7Click);
        btnNextPanel7Second.onClick.AddListener(OnBtnNextPanel7Click);
        nextPanel.SetActive(false);
        yield return null; // Ganti dengan null agar coroutine tidak dijalankan saat game object diaktifkan
    }

    private void OnEnable()
    {
        StartCoroutine(Start());
        StartCoroutine(InstallationCoroutine());
    }

    private IEnumerator InstallationCoroutine()
    {
        yield return new WaitUntil(() => run == true);

        // Set teks awal yang tidak bold
        SetTextBold(copyingFiles, false);
        SetTextBold(gettingFiles, false);
        SetTextBold(installingFeatures, false);
        SetTextBold(finishingUp, false);
        imageComplete1.SetActive(false);
        imageComplete2.SetActive(false);
        imageComplete3.SetActive(false);
        imageComplete4.SetActive(false);

        // Memulai proses loading untuk masing-masing teks dan gambar
        StartCoroutine(StartLoading(copyingFiles, copyingFilesStartTime, imageComplete1, progressTextCopyingFiles, 180)); // Durasi loading 100 detik
        yield return new WaitForSeconds(2f);
        StartCoroutine(StartLoading(gettingFiles, gettingFilesStartTime, imageComplete2, progressTextGettingFiles, 180)); // Durasi loading 200 detik
        yield return new WaitForSeconds(2f);
        StartCoroutine(StartLoading(installingFeatures, installingFeaturesStartTime, imageComplete3, progressTextInstallingFeatures, 180)); // Durasi loading 150 detik
        yield return new WaitForSeconds(2f);
        StartCoroutine(StartLoading(finishingUp, finishingUpStartTime, imageComplete4, progressTextFinishingUp, 60)); // Durasi loading 180 detik

        StartCoroutine(DelayedPanelSwitch());
    }

    private void Update()
    {
        int currentTime = (int)Time.time;
        //Debug.Log("Nilai current time adalah: " + currentTime);
    }

    private IEnumerator StartLoading(Text text, int startTime, GameObject image, Text progressText, int loadingDuration)
    {
        //Debug.Log("Nilai start time adalah: " + startTime);
        yield return new WaitForSeconds(startTime);

        // Membuat teks menjadi tidak bold dan menyembunyikan gambar
        //SetTextBold(text, false);
        //image.SetActive(false);

        int currentTime = 0;

        while (currentTime <= loadingDuration)
        {
            // Hitung persentase progress
            //Debug.Log("Nilai start time adalah: " + startTime);
            float progress = (float)currentTime / (float)loadingDuration * 100f;
            // Tampilkan persentase progress
            progressText.text = Mathf.Round(progress) + "%";
            //Debug.Log("progres: " + progress);

            if (currentTime == 0)
            {
                // Proses loading dimulai, set teks menjadi tebal dan tampilkan gambar
                SetTextBold(text, true);
                image.SetActive(false);
            }

            yield return new WaitForSeconds(1f); // Tunggu selama 1 detik
            currentTime++;
        }
        //yield return new WaitForSeconds(1f);
        // Proses loading selesai, set teks menjadi tidak bold dan menyembunyikan gambar
        SetTextBold(text, false);
        image.SetActive(true);

        // Menghilangkan teks progress
        progressText.text = "";
    }

    private IEnumerator DelayedPanelSwitch()
    {
        // Tunggu selama 5 detik
        yield return new WaitForSeconds(600f);

        // Nonaktifkan currentPanel dan aktifkan nextPanel
        progressBarPanel.SetActive(false);
        progressBarPanel2.SetActive(false);
        currentPanel.SetActive(false);
        nextPanel.SetActive(true);
    }

    private void SetTextBold(Text text, bool isBold)
    {
        FontStyle style = isBold ? FontStyle.Bold : FontStyle.Normal;
        text.fontStyle = style;
    }

    void OnBtnNextPanel7Click()
    {
        run = true;
        progressBarPanel2.SetActive(true);
    }

    // ...
}
