using UnityEngine;
using UnityEngine.UI;

public class PlayerPrefsManager : MonoBehaviour
{
    // Key untuk PlayerPrefs, dapat diubah di Inspector
    public string playerPrefsKey = "PlayerName";

    // Referensi ke komponen Text
    public Text playerData;

    private void Start()
    {
        // Coba ambil data dari PlayerPrefs saat aplikasi dimulai
        //LoadData();
    }

    public void Update()
    {
        SaveData();
    }

    public void SaveData()
    {
        // Ambil nilai dari Text
        string playerDatas = playerData.text;

        // Simpan nilai ke PlayerPrefs dengan menggunakan kunci yang telah ditentukan
        PlayerPrefs.SetString(playerPrefsKey, playerDatas);

        // Simpan perubahan
        PlayerPrefs.Save();
    }

    public void LoadData()
    {
        // Ambil data dari PlayerPrefs berdasarkan kunci yang telah ditentukan
        string playerName = PlayerPrefs.GetString(playerPrefsKey, "");

        // Tampilkan data ke Text
        playerData.text = playerName;
    }
}