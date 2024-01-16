using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AlmostThereFade : MonoBehaviour
{
    public GameObject gameObject1;
    public GameObject gameObject2;
    public GameObject gameObject3;
    public float fadeDuration;
    public Text textComponent; // Membuat komponen Text publik

/*    private bool _isTextEnabled = false;

    public bool IsTextEnabled
    {
        get { return _isTextEnabled; }
        set
        {
            _isTextEnabled = value;
            if (_isTextEnabled)
            {
                // Ketika textComponent.enabled diaktifkan, mulai animasi fade
                StartCoroutine(FadeBetweenObjects(gameObject1, gameObject2));
            }
        }
    }
*/
    private void Awake()
    {
        if (textComponent.enabled)
        {
            // Mulai dengan mengatur IsTextEnabled ke true untuk memicu animasi fade
            Debug.Log("Komponen text masih enabled");
            //IsTextEnabled = true;
        }
        else
        {
            StartCoroutine(FadeBetweenObjects(gameObject1, gameObject2));
        }
    }

    private IEnumerator FadeBetweenObjects(GameObject fromObject, GameObject toObject)
    {
        CanvasGroup fromCanvasGroup = fromObject.GetComponent<CanvasGroup>();
        CanvasGroup toCanvasGroup = toObject.GetComponent<CanvasGroup>();

        if (fromCanvasGroup == null)
        {
            fromCanvasGroup = fromObject.AddComponent<CanvasGroup>();
        }

        if (toCanvasGroup == null)
        {
            toCanvasGroup = toObject.AddComponent<CanvasGroup>();
        }

        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            fromCanvasGroup.alpha = 1 - Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            toCanvasGroup.alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Disable the fromObject and enable the toObject after fading
        fromObject.SetActive(false);
        toObject.SetActive(true);

        // Start fading fromObject to the next target (gameObject3 in this case)
        if (toObject == gameObject2)
        {
            StartCoroutine(FadeBetweenObjects(toObject, gameObject3));
        }
    }
}
