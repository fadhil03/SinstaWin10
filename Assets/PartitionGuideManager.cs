using UnityEngine;

public class PartitionGuideManager : MonoBehaviour
{
    public GameObject[] InstalasiBaru;
    public GameObject[] InstalasiUlang;

    void Start()
    {
        string typeInstallation = PlayerPrefs.GetString("TypeInstallation", "");

        if (typeInstallation == "Instalasi Baru")
        {
            foreach (GameObject obj in InstalasiBaru)
            {
                obj.SetActive(true);
            }

            foreach (GameObject obj in InstalasiUlang)
            {
                obj.SetActive(false);
            }
        }
        else if (typeInstallation == "Instalasi Ulang")
        {
            foreach (GameObject obj in InstalasiUlang)
            {
                obj.SetActive(true);
            }

            foreach (GameObject obj in InstalasiBaru)
            {
                obj.SetActive(false);
            }
        }
    }
}
