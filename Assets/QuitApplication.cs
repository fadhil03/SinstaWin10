using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApplication : MonoBehaviour
{
    public void ExitApplication()
    {
        // Keluar dari aplikasi
        Application.Quit();

        // Jika Anda menjalankan di dalam editor Unity, berhenti juga secara manual
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
