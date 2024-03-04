using UnityEngine;

public class ClearPlayerPrefs : MonoBehaviour
{
    public void ClearAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save(); // Simpan perubahan
    }
}
