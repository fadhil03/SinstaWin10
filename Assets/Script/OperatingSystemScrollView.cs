using UnityEngine;
using UnityEngine.UI;

public class OperatingSystemScrollView : MonoBehaviour
{
    public ScrollRect scrollRect;
    public RectTransform content;
    public GameObject listItemPrefab;
    public float verticalSpacing = 1000f;
    public float scrollSpeed = 25f; // Kecepatan scroll, sesuaikan dengan kebutuhan

    private void Update()
    {
        // Mengambil input mouse scroll
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        // Menghitung perubahan scroll dengan kecepatan scroll
        float scrollDelta = scrollInput * scrollSpeed;

        // Mengambil posisi scroll saat ini
        float currentScrollPosition = scrollRect.verticalNormalizedPosition;

        // Menambahkan perubahan scroll ke posisi scroll saat ini
        float newScrollPosition = currentScrollPosition + scrollDelta;

        // Memastikan bahwa nilai scroll berada dalam rentang 0 hingga 1
        newScrollPosition = Mathf.Clamp01(newScrollPosition);

        // Mengatur posisi scroll baru
        scrollRect.verticalNormalizedPosition = newScrollPosition;
    }


    private void Start()
    {
        // Buat daftar item operating system
        string[] operatingSystems = {
            "Windows 10 Home",
            "Windows 10 Pro",
            "Windows 10 Education",
            "Windows 10 Enterprise",
            "Windows 10 S",
            "Windows 10 Team",
            "Windows 10 IoT Core",
            "Windows 10 Pro for Workstations",
            "Windows 10 IoT Enterprise",
            "Windows 10 Education N"
        };

        string[] architectures = {
            "x86",
            "x64",
            "x86",
            "x64",
            "x64",
            "x64",
            "ARM",
            "x64",
            "x86",
            "x64"
        };

        string[] dateModified = {
            "01/06/2023",
            "15/05/2023",
            "22/04/2023",
            "30/03/2023",
            "12/02/2023",
            "05/01/2023",
            "18/12/2022",
            "24/11/2022",
            "07/10/2022",
            "14/09/2022"
        };


        // Tampilkan daftar item dalam Scroll View
        for (int i = 0; i < operatingSystems.Length; i++)
        {
            // Buat instance dari prefab listItemPrefab
            GameObject listItem = Instantiate(listItemPrefab, content);

            // Setel parent dari objek menjadi content
            listItem.transform.SetParent(content, false);

            // Setel posisi, rotasi, dan skala objek
            float yPos = -i * (listItem.GetComponent<RectTransform>().rect.height + verticalSpacing) - 70f;
            listItem.transform.localPosition = new Vector3(547, yPos, 0);
            listItem.transform.localRotation = Quaternion.identity;
            listItem.transform.localScale = Vector3.one;

            // Ambil komponen Text dari listItem untuk menampilkan informasi operating system
            Text[] textComponents = listItem.GetComponentsInChildren<Text>();
            textComponents[0].text = operatingSystems[i];
            textComponents[1].text = architectures[i];
            textComponents[2].text = dateModified[i];
        }

        // Hitung ukuran content berdasarkan jumlah item dan ukuran setiap item
        float totalHeight = (listItemPrefab.GetComponent<RectTransform>().rect.height + verticalSpacing) * operatingSystems.Length;
        content.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, totalHeight);

        // Reset posisi Scroll View ke atas
        scrollRect.normalizedPosition = new Vector2(0, 1);
    }
}
