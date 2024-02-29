using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarController : MonoBehaviour
{
    public Image foregroundImage;
    public Image backgroundImage;
    public GameObject[] loadingPanels;

    void OnEnable()
    {
        // Panggil fungsi simulasi loading ketika game object diaktifkan
        StartCoroutine(SimulateLoading());
    }

    void Start()
    {
        // Inisialisasi progres
        float progress = 0.0f;
        UpdateLoading(progress);
    }

    private void Update()
    {

    }

    IEnumerator SimulateLoading()
    {
        float totalProgress = 1.0f; // Total progres yang diinginkan
        float panelIncrement = totalProgress / loadingPanels.Length; // Increment progres per panel

        float currentFillAmount = 0.0f;
        UpdateLoading(currentFillAmount);

        foreach (var panel in loadingPanels)
        {
            // Tunggu panel aktif
            yield return new WaitUntil(() => panel.activeSelf);

            // Tambahkan progres
            currentFillAmount += panelIncrement;
            Debug.Log("currentFillAmount =" + currentFillAmount);
            Debug.Log("panelIncrement =" + panelIncrement);
            UpdateLoading(currentFillAmount);

            yield return null; // Jeda untuk memberi kesempatan update UI
        }
    }

    void UpdateLoading(float progress)
    {
        // Atur tampilan foreground, background, atau panel-panel sesuai dengan progres
        foregroundImage.fillAmount = Mathf.Clamp01(progress);
    }
}
