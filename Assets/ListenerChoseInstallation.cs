using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ListenerChoseInstallation : MonoBehaviour
{
    public Button btnNewInstallation;
    public Button btnRenewInstallation;
    public CanvasGroup panelCanvasGroup;
    public GameObject panelGameObject;
    public float fadeDuration = 3f; // Durasi animasi fading

    void Start()
    {
        btnNewInstallation.onClick.AddListener(OnClickButton1);
        btnRenewInstallation.onClick.AddListener(OnClickButton2);
    }

    void OnClickButton1()
    {
        PlayerPrefs.SetString("TypeInstallation", "Instalasi Baru");

        // Memulai coroutine untuk animasi fading
        StartCoroutine(FadeCanvasGroupInstallation(panelCanvasGroup, 1f, 0f, fadeDuration));

        // Menonaktifkan panel GameObject setelah animasi selesai
        StartCoroutine(DisablePanelAfterDelay(fadeDuration));
    }

    void OnClickButton2()
    {
        PlayerPrefs.SetString("TypeInstallation", "Instalasi Ulang");
        // Memulai coroutine untuk animasi fading
        StartCoroutine(FadeCanvasGroupInstallation(panelCanvasGroup, 1f, 0f, fadeDuration));

        // Menonaktifkan panel GameObject setelah animasi selesai
        StartCoroutine(DisablePanelAfterDelay(fadeDuration));
    }

    IEnumerator FadeCanvasGroupInstallation(CanvasGroup canvasGroup, float startAlpha, float targetAlpha, float duration)
    {
        float timer = 0f;

        while (timer < duration)
        {
            // Menghitung persentase selesai animasi
            float alphaPercentage = timer / duration;

            // Mengubah alpha CanvasGroup secara perlahan
            canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, alphaPercentage);

            // Menunggu satu frame
            yield return null;

            // Mengupdate timer
            timer += Time.deltaTime;
        }

        // Memastikan alpha mencapai nilai target pada akhir animasi
        canvasGroup.alpha = targetAlpha;
    }

    IEnumerator DisablePanelAfterDelay(float delay)
    {
        // Menunggu sebelum menonaktifkan panel
        yield return new WaitForSeconds(delay);

        // Menonaktifkan panel GameObject
        panelGameObject.SetActive(false);
    }


}
