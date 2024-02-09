using UnityEngine;
using TMPro;

public class Stopwatch : MonoBehaviour
{
    private float elapsedTime = 0f;
    private bool isTiming = true;

    public TextMeshProUGUI textMeshPro; // Referensi ke komponen TextMeshProUGUI

    void Awake()
    {
        // Memuat waktu yang disimpan dari PlayerPrefs saat pertama kali skrip dijalankan
        elapsedTime = PlayerPrefs.GetFloat("Elapsed Time", 0f);
        UpdateText(); // Memperbarui teks pada TextMeshProUGUI dengan waktu yang sudah disimpan
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (isTiming)
        {
            elapsedTime += Time.deltaTime;
            UpdateText(); // Panggil fungsi untuk memperbarui teks pada setiap pembaruan waktu
        }
    }

    void UpdateText()
    {
        int hours = Mathf.FloorToInt(elapsedTime / 3600f);
        int minutes = Mathf.FloorToInt((elapsedTime % 3600f) / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);

        // Format waktu menjadi teks
        string timeText = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);

        // Atur teks pada komponen TextMeshProUGUI
        if (textMeshPro != null)
        {
            textMeshPro.text = timeText;
        }
    }

    // Fungsi-fungsi lain seperti Reset, Pause, Resume bisa disesuaikan sesuai kebutuhan

    void OnDestroy()
    {
        // Menyimpan waktu terakhir ke PlayerPrefs saat objek dihancurkan (misalnya saat berpindah scene)
        PlayerPrefs.SetFloat("Elapsed Time", elapsedTime);
        PlayerPrefs.Save(); // Simpan perubahan PlayerPrefs
    }
}
