using UnityEngine;

public class TopPanelSwitcher : MonoBehaviour
{
    public GameObject gameObj1;
    public GameObject gameObj2;

    public GameObject[] gameObj1panels;
    public GameObject[] gameObj2panels;

    void Update()
    {
        // Memeriksa kondisi panel dan mengaktifkan/deaktifkan game objek sesuai dengan aturan yang diberikan.
        bool isGameObj1Active = IsAnyPanelActive(gameObj1panels);
        bool isGameObj2Active = IsAnyPanelActive(gameObj2panels);

        gameObj1.SetActive(isGameObj1Active);
        gameObj2.SetActive(isGameObj2Active);
    }

    // Fungsi untuk memeriksa apakah salah satu panel dalam array aktif.
    private bool IsAnyPanelActive(GameObject[] panels)
    {
        foreach (var panel in panels)
        {
            if (panel.activeSelf)
            {
                return true;
            }
        }
        return false;
    }
}
