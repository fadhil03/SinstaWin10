using UnityEngine;
using UnityEngine.UI;
using System;

public class DateGetter : MonoBehaviour
{
    public Text dateText; // Tarik dan lepaskan komponen Text ke sini melalui inspector

    private void Update()
    {
        // Mengambil tanggal saat ini
        DateTime currentDate = DateTime.Now;

        // Mendapatkan komponen tanggal, bulan, dan tahun
        int day = currentDate.Day;
        int month = currentDate.Month;
        int year = currentDate.Year;

        // Menggabungkan tanggal, bulan, dan tahun ke dalam satu teks dengan format [dd/MM/yyyy]
        string dateString = string.Format("[{0:D2}/{1:D2}/{2:D4}]", day, month, year);

        // Menampilkan tanggal dalam komponen Text
        dateText.text = dateString;
    }
}
