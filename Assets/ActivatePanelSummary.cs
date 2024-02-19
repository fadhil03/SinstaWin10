using System.Collections;
using UnityEngine;

public class ActivatePanelSummary : MonoBehaviour
{
    public CanvasGroup canvasGroupCheck; // Referensi ke CanvasGroup yang akan diperiksa
    public GameObject panel; // Panel yang akan diaktifkan jika alpha CanvasGroup adalah 1


    void Update()
    {
        // Pastikan penundaan hanya dilakukan sekali
            
            StartCoroutine(DelayedActivation());
        
    }

    private IEnumerator DelayedActivation()
    {
        if (canvasGroupCheck != null)
        {
            // Mengecek alpha CanvasGroup
            if (canvasGroupCheck.alpha == 1f)
            {
                // Mengaktifkan panel jika alpha adalah 1
                if (panel != null)
                {
                    yield return new WaitForSeconds(3f);
                    panel.SetActive(true);
                }
                else
                {
                    Debug.LogWarning("Panel reference is not set!");
                }
            }
        }
        else
        {
            Debug.LogWarning("CanvasGroup reference is not set!");
        }
    }
}