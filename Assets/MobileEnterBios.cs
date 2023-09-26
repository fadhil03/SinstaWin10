using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobileEnterBios : MonoBehaviour
{
    public Canvas biosCanvas; // Drag and drop your Bios Canvas here in the inspector
    public Canvas checkingCanvas;

    private bool isMobile;

    private void Start()
    {
        // Cek jika perangkat saat ini adalah mobile
        isMobile = SystemInfo.deviceType == DeviceType.Handheld;

        // Sembunyikan Canvas Bios saat permainan dimulai
        biosCanvas.gameObject.SetActive(false);
        checkingCanvas.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (isMobile)
        {
            // Cek jika ada sentuhan pada layar
            if (Input.touchCount > 0)
            {
                // Tampilkan Canvas Bios saat sentuhan terdeteksi
                biosCanvas.gameObject.SetActive(true);
                checkingCanvas.gameObject.SetActive(false);
            }
        }
        /*else
        {
            // Cek jika tombol mouse kiri ditekan
            if (Input.GetMouseButtonDown(0))
            {
                // Tampilkan Canvas Bios saat klik mouse terdeteksi
                biosCanvas.gameObject.SetActive(true);
            }
        }*/
    }
}
