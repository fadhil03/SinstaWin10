using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AlmostThereFade : MonoBehaviour
{
    public GameObject gameObject1;
    public GameObject gameObject2;
    public GameObject gameObject3;
    public GameObject textObject;

    private bool checkLastFadeOut;

    private CanvasGroup canvasGroup1;
    private CanvasGroup canvasGroup2;
    private CanvasGroup canvasGroup3;

    void Start()
    {
        // Ambil komponen CanvasGroup dari setiap GameObject
        canvasGroup1 = gameObject1.GetComponent<CanvasGroup>();
        canvasGroup2 = gameObject2.GetComponent<CanvasGroup>();
        canvasGroup3 = gameObject3.GetComponent<CanvasGroup>();
    }

    void Update()
    {
        checkLastFadeOut = PlayerPrefs.GetInt("LastTextFadeOut") == 1 ? true : false;
        // Memeriksa kondisi setiap frame
        if (!textObject.activeSelf && checkLastFadeOut)
        {
            StartCoroutine(FadeCanvasGroup(canvasGroup1, 1f, 0f, 1f));
            StartCoroutine(FadeCanvasGroup(canvasGroup2, 0f, 1f, 2f));
            StartCoroutine(FadeCanvasGroup(canvasGroup2, 1f, 0f, 2f));
            StartCoroutine(FadeCanvasGroup(canvasGroup3, 0f, 1f, 1f));
            //gameObject2.active = false;
            checkLastFadeOut = false; // Set checkLastFadeOut menjadi false agar tidak terjadi transisi lagi
            PlayerPrefs.SetInt("LastTextFadeOut", checkLastFadeOut ? 1 : 0);
            Debug.Log("checkLastFadeOut almost there = " + checkLastFadeOut);
        }
    }

    /*IEnumerator StartObjectTransition()
    {
        while (true)
        {
            // Delay 3 detik sebelum melanjutkan ke transisi selanjutnya
            yield return new WaitForSeconds(3f);

            // Lakukan transisi fade dari gameObject2 ke gameObject3
            yield return StartCoroutine(FadeCanvasGroup(canvasGroup2, 1f, 0f, 1f));
            yield return StartCoroutine(FadeCanvasGroup(canvasGroup3, 0f, 1f, 1f));

        }
    }*/

    // Coroutine untuk transisi fade pada CanvasGroup
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

    void SetActiveGameObject2()
    {
        // Lakukan transisi fade dari gameObject3
        StartCoroutine(FadeCanvasGroup(canvasGroup1, 1f, 0f, 1f));
        StartCoroutine(FadeCanvasGroup(canvasGroup2, 0f, 1f, 1f));
        
    }
    void SetActiveGameObject3()
    {
        // Lakukan transisi fade dari gameObject3
        StartCoroutine(FadeCanvasGroup(canvasGroup2, 1f, 0f, 1f));
        StartCoroutine(FadeCanvasGroup(canvasGroup3, 0f, 1f, 1f));
    }
}
