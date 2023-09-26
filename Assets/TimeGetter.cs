using UnityEngine;
using UnityEngine.UI;
using System;

public class TimeGetter : MonoBehaviour
{
    public Text timeText; // Tarik dan lepaskan komponen Text ke sini melalui inspector

    private void Update()
    {
        // Mengambil waktu dan tanggal saat ini
        DateTime currentDateTime = DateTime.Now;

        // Mendapatkan komponen jam, menit, dan detik
        int hour = currentDateTime.Hour;
        int minute = currentDateTime.Minute;
        int second = currentDateTime.Second;

        // Menggabungkan jam, menit, dan detik ke dalam satu teks dengan format [hh:mm:ss]
        string timeString = string.Format("[{0:D2}:{1:D2}:{2:D2}]", hour, minute, second);

        // Menampilkan waktu dalam komponen Text
        timeText.text = timeString;
    }
}
