using UnityEngine;

public class ChangeSpriteOnClick : MonoBehaviour
{
    public Sprite oldSprite;
    public Sprite newSprite; // Gambar sprite baru yang akan digunakan setelah diklik
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        // Mendapatkan referensi ke komponen SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Memastikan bahwa objek memiliki SpriteRenderer sebelum menggunakan skrip ini
    }

    private void Update()
    {
        //spriteRenderer.sprite = oldSprite;
    }

    void OnMouseDown()
    {
        // Memeriksa apakah newSprite telah ditetapkan sebelum mengubah sprite
        if (newSprite != null)
        {
            // Mengubah gambar sprite
            spriteRenderer.sprite = newSprite;

            // Mengatur rotasi transform.z menjadi 0
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0f);
        }
        else
        {
            Debug.LogWarning("Sprite baru belum ditetapkan.");
        }
    }

    void OnMouseUp()
    {
        if (newSprite != null)
        {
            // Mengubah gambar sprite
            spriteRenderer.sprite = oldSprite;

            // Mengatur rotasi transform.z menjadi 0
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, -70f);
        }
        else
        {
            spriteRenderer.sprite = oldSprite;
            Debug.LogWarning("Sprite baru belum ditetapkan.");
        }
    }
}
