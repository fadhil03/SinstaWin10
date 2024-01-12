using UnityEngine;

public class ActivateDelayedNextPanel : MonoBehaviour
{
    public GameObject currentPanel;
    public DelayedNextPanel delayedNextPanelScript;

    void Start()
    {
        // Cek apakah currentPanel aktif
        if (currentPanel.activeSelf)
        {
            // Mengaktifkan skrip DelayedNextPanel jika currentPanel aktif
            if (delayedNextPanelScript != null)
            {
                delayedNextPanelScript.enabled = true;
            }
        }
    }
}
