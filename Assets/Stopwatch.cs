using UnityEngine;
using TMPro;

public class Stopwatch : MonoBehaviour
{
    private float elapsedTime = 0f;
    private bool isTiming = true;

    public TextMeshProUGUI textMeshPro; // Referensi ke komponen TextMeshProUGUI

    void Awake()
    {
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
}
