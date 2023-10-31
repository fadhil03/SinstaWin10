using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeInAndOutTextAnimation : MonoBehaviour
{
    public Text[] textComponents;
    public float fadeInDuration = 2f;
    public float fadeOutDuration = 2f;
    public float[] delaysBetweenTexts;

    private int currentIndex = 0;

    void Start()
    {
        // Pastikan semua komponen teks nonaktif pada awal permainan
        foreach (Text textComponent in textComponents)
        {
            textComponent.enabled = false;
        }

        // Mulai animasi fade in untuk komponen teks pertama
        StartCoroutine(PlayTextAnimations());
    }

    IEnumerator PlayTextAnimations()
    {
        while (currentIndex < textComponents.Length)
        {
            // Aktifkan komponen teks pada index saat ini
            textComponents[currentIndex].enabled = true;

            // Animasi fade in
            yield return StartCoroutine(FadeInText(textComponents[currentIndex]));

            // Tunggu sejenak sebelum memulai animasi fade out
            if (currentIndex < delaysBetweenTexts.Length)
            {
                yield return new WaitForSeconds(delaysBetweenTexts[currentIndex]);
            }

            // Animasi fade out
            yield return StartCoroutine(FadeOutText(textComponents[currentIndex]));

            // Nonaktifkan komponen teks pada index saat ini
            textComponents[currentIndex].enabled = false;

            // Pindah ke komponen teks berikutnya
            currentIndex++;
        }

        // Semua animasi selesai
        Debug.Log("Semua animasi selesai.");
    }

    IEnumerator FadeInText(Text textComponent)
    {
        float elapsedTime = 0f;
        Color currentColor = textComponent.color;

        while (elapsedTime < fadeInDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeInDuration);
            textComponent.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
            Debug.Log("Alpha color = " + alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        textComponent.color = new Color(currentColor.r, currentColor.g, currentColor.b, 1f);
    }

    IEnumerator FadeOutText(Text textComponent)
    {
        float elapsedTime = 0f;
        Color currentColor = textComponent.color;

        while (elapsedTime < fadeOutDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeOutDuration);
            textComponent.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        textComponent.color = new Color(currentColor.r, currentColor.g, currentColor.b, 0f);
    }
}