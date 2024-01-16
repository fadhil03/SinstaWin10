using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeInAndOutTextAnimation : MonoBehaviour
{
    public Text[] textComponents;
    public GameObject[] textObject;
    public float fadeInDuration = 2f;
    public float fadeOutDuration = 2f;
    public float[] delaysBetweenTexts;
    private bool isLastTextObject;

    private int currentIndex = 0;

    void Awake()
    {
        // Pastikan semua komponen teks nonaktif pada awal permainan
        foreach (Text textComponent in textComponents)
        {
            textComponent.enabled = false;
        }

        foreach (GameObject textObject in textObject)
        {
            textObject.active = false;
        }
        isLastTextObject = false;
        PlayerPrefs.SetInt("LastTextFadeOut", isLastTextObject ? 1 : 0);

        // Mulai animasi fade in untuk komponen teks pertama
        StartCoroutine(PlayTextAnimations());
    }

    IEnumerator PlayTextAnimations()
    {
        while (currentIndex < textComponents.Length)
        {
            // Aktifkan komponen teks pada index saat ini
            Debug.Log("current index text = " + currentIndex);


            // Animasi fade in
            if (currentIndex == 2) // Element 2 and 6 fade in together
            {
                textComponents[currentIndex].enabled = true;
                textObject[currentIndex].active = true;
                yield return StartCoroutine(FadeInText(textComponents[currentIndex]));
                textObject[5].active = true;
                textComponents[5].enabled = true;
                yield return StartCoroutine(FadeInText(textComponents[5]));
            }
            else if (currentIndex == 5) // Element 4 and 6 fade out together
            {
                textComponents[5].enabled = false;
                textObject[5].active = false;
                //Destroy(textComponents[5]);
            }
            else
            {
                textComponents[currentIndex].enabled = true;
                textObject[currentIndex].active = true;
                yield return StartCoroutine(FadeInText(textComponents[currentIndex]));
            }

            // Tunggu sejenak sebelum memulai animasi fade out
            if (currentIndex < delaysBetweenTexts.Length)
            {
                yield return new WaitForSeconds(delaysBetweenTexts[currentIndex]);
            }

            // Animasi fade out
            if (currentIndex == 4) // Element 4 and 6 fade out together
            {
                textComponents[currentIndex].enabled = true;
                textObject[currentIndex].active = true;
                yield return StartCoroutine(FadeOutText(textComponents[currentIndex]));
                yield return StartCoroutine(FadeOutText(textComponents[5]));
                textComponents[5].enabled = false;
                textObject[5].active = false;
                isLastTextObject = true;
                PlayerPrefs.SetInt("LastTextFadeOut", isLastTextObject ? 1 : 0);
                //Destroy(textComponents[5]);
            }
            else
            {
                yield return StartCoroutine(FadeOutText(textComponents[currentIndex]));
            }

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
            //Debug.Log("Alpha color = " + alpha);

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