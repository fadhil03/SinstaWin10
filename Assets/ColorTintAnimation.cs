using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ColorTintAnimation : MonoBehaviour
{
    public Image targetImage;
    public Text textComponent;
    public Color color1 = new Color(0, 0, 0, 1); // Warna hitam
    public Color color2 = new Color(0, 50, 91, 255) / 255f; // Color #00325b
    public Color color3 = new Color(1, 108, 191, 255) / 255f; // Color #016cbf
    public float transitionDuration = 1f;

    private Coroutine colorChangeCoroutine;
    private bool animationStarted = false;

    private void Start()
    {
        // Periksa nilai .enabled pada komponen Text
        if (textComponent.enabled)
        {
            // Inisialisasi warna targetImage dengan color1 saat komponen teks aktif
            targetImage.color = color1;
            // Memulai animasi color tint dari color1 ke color2
            colorChangeCoroutine = StartCoroutine(AnimateColorTint(color1, color2, true));
            animationStarted = true;
        }
    }

    private void Update()
    {
        // Periksa nilai .enabled pada komponen Text saat Update dipanggil
        if (textComponent.enabled && !animationStarted)
        {
            // Inisialisasi warna targetImage dengan color1 saat komponen teks aktif
            targetImage.color = color1;
            // Memulai animasi color tint dari color1 ke color2
            colorChangeCoroutine = StartCoroutine(AnimateColorTint(color1, color2, true));
            animationStarted = true;
        }
    }

    private IEnumerator AnimateColorTint(Color fromColor, Color toColor, bool isFirstTransition)
    {
        float elapsedTime = 0f;

        while (elapsedTime < transitionDuration)
        {
            targetImage.color = Color.Lerp(fromColor, toColor, elapsedTime / transitionDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        if (isFirstTransition)
        {
            // Setelah transisi pertama selesai, memulai transisi kedua dari color2 ke color3
            colorChangeCoroutine = StartCoroutine(AnimateColorTint(color2, color3, false));
            //colorChangeCoroutine = StartCoroutine(AnimateColorTint(color3, color2, false));
        }
        else
        {
            // Setelah transisi kedua selesai, memulai transisi pertama lagi dari color1 ke color2
            colorChangeCoroutine = StartCoroutine(AnimateColorTint(color2, color3, true));
            colorChangeCoroutine = StartCoroutine(AnimateColorTint(color3, color2, true));
        }
    }

    // Menghentikan coroutine jika skrip dinonaktifkan atau dihapus
    private void OnDisable()
    {
        if (colorChangeCoroutine != null)
        {
            StopCoroutine(colorChangeCoroutine);
        }
    }
}
