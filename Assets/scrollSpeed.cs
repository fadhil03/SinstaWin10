using UnityEngine;
using UnityEngine.UI;

public class scrollSpeed : MonoBehaviour
{
    public ScrollRect scrollRect;
    public float scrollSpeedDesktop = 0.1f;
    public float scrollSpeedAndroid = 0.5f;

    private Vector2 lastPosition;

    private void Update()
    {
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor)
        {
            // Desktop (Windows/Mac)
            float scrollWheelInput = Input.GetAxis("Mouse ScrollWheel");
            float verticalScrollSpeed = scrollWheelInput * scrollSpeedDesktop;
            scrollRect.verticalNormalizedPosition -= verticalScrollSpeed;
            scrollRect.verticalNormalizedPosition = Mathf.Clamp01(scrollRect.verticalNormalizedPosition);
        }
        else if (Application.platform == RuntimePlatform.Android)
        {
            // Android
            if (Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                    Vector2 deltaPosition = touch.deltaPosition;
                    float verticalScrollSpeed = deltaPosition.y * scrollSpeedAndroid;
                    scrollRect.verticalNormalizedPosition -= verticalScrollSpeed;
                    scrollRect.verticalNormalizedPosition = Mathf.Clamp01(scrollRect.verticalNormalizedPosition);
                }
            }
        }
    }
}
