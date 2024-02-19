using System.Collections;
using UnityEngine;

public class DelayedfadePanelSummary : MonoBehaviour
{
    public CanvasGroup canvasGroupPanel; // Referensi ke CanvasGroup yang akan diubah

    void OnEnable()
    {
        // Mengeksekusi fungsi DelayedStart setelah game object diaktifkan
        StartCoroutine(DelayedStart());
    }

    IEnumerator DelayedStart()
    {
        // Menunggu selama 5 detik setelah game object diaktifkan
        yield return new WaitForSeconds(2f);

        // Memulai coroutine FadeCanvasGroup setelah penundaan
        StartCoroutine(FadeCanvasGroup(canvasGroupPanel, 0f, 1f, 0.3f));
    }

    IEnumerator FadeCanvasGroup(CanvasGroup canvasGroup, float startAlpha, float endAlpha, float duration)
    {
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = endAlpha;
    }
}
