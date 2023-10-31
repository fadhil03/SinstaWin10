using System.Collections;
using UnityEngine;

public class DelayedNextPanel : MonoBehaviour
{
    public GameObject currentPanel;
    public GameObject nextPanel;
    private float delayTime = 8.0f;
    private float startTime;
    private float currentTime;

    private IEnumerator Start()
    {
        startTime = Time.time; // Mengatur waktu awal ketika Start dipanggil
        currentTime = startTime; // Inisialisasi currentTime dengan startTime

        while (currentTime - startTime < delayTime)
        {
            currentTime = Time.time; // Update currentTime selama penundaan
            yield return null; // Tunggu frame berikutnya
        }

        // Nonaktifkan panel saat ini dan aktifkan panel berikutnya
        yield return new WaitForSeconds(delayTime);
        currentPanel.SetActive(false);
        nextPanel.SetActive(true);
    }
}
