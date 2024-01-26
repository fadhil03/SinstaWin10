using UnityEngine;

public class GuidePlugBootable : MonoBehaviour
{
    public Transform targetCollider; // Collider yang menjadi target
    public GameObject objectStartPosition;
    public float delayBetweenMovements = 2f; // Waktu jeda antara gerakan

    private Vector3 targetPosition; // Posisi target collider
    private Vector3 startPosition; // Posisi awal gambar penunjuk jari
    private float duration = 2f; // Durasi gerakan

    private float startTime; // Waktu mulai gerakan
    private bool isMoving = false; // Status apakah objek sedang bergerak

    void Start()
    {
        // Memulai gerakan pertama kali
        MoveToTarget();
    }

    void Update()
    {
        // Periksa apakah gerakan sedang berlangsung
        if (isMoving)
        {
            // Hitung waktu yang sudah berlalu sejak mulai gerakan
            float timeElapsed = Time.time - startTime;

            // Normalisasi waktu menjadi nilai antara 0 dan 1
            float t = Mathf.Clamp01(timeElapsed / duration);

            // Interpolasi linier antara posisi awal dan posisi target
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);

            // Jika waktu sudah habis, gerakan selesai
            if (t >= 1f)
            {
                isMoving = false;
            }
        }
        else
        {
            // Jika gerakan sudah selesai, tunggu delay sebelum memulai gerakan baru
            if (Time.time - startTime >= delayBetweenMovements)
            {
                MoveToTarget();
            }
        }
    }

    void MoveToTarget()
    {
        // Dapatkan posisi awal dari objectStartPosition
        startPosition = objectStartPosition.transform.position;

        // Dapatkan posisi target collider
        targetPosition = targetCollider.position;

        // Mulai gerakan baru
        startTime = Time.time;
        isMoving = true;
    }
}
