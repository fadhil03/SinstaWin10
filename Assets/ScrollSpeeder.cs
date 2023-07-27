using UnityEngine;
using UnityEngine.UI;

public class ScrollSpeeder : MonoBehaviour
{
    public ScrollRect scrollRect;
    public float scrollSpeed = 25f;

    private void Start()
    {
        scrollRect.scrollSensitivity = scrollSpeed;
    }
}
