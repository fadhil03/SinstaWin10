using UnityEngine;

public class DragAndDrop2Dobj : MonoBehaviour
{
    public Sprite oldSprite;
    public Sprite newSprite; // Gambar sprite baru yang akan digunakan setelah diklik
    public SpriteRenderer spriteRenderer;
    private bool isHitBox;

    Vector3 offset;
    Collider2D collider2d;
    public string destinationTag = "DropArea";

    void Start()
    {
        // Mendapatkan referensi ke komponen SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Mendapatkan referensi ke komponen Collider2D
        collider2d = GetComponent<Collider2D>();
    }

    void Update()
    {
        // spriteRenderer.sprite = oldSprite;
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

            // Menyimpan offset untuk drag-and-drop
            offset = transform.position - MouseWorldPosition();
        }
        else
        {
            Debug.LogWarning("Sprite baru belum ditetapkan.");
        }
    }

    void OnMouseDrag()
    {
        if (newSprite != null)
        {
            // Menggerakkan objek berdasarkan input mouse atau sentuhan
            //spriteRenderer.sprite = newSprite;
            transform.position = MouseWorldPosition() + offset;
        }
    }

    void OnMouseUp()
    {
        if (newSprite != null)
        {
            // Mengembalikan ke sprite lama
            //spriteRenderer.sprite = oldSprite;

            // Mengatur rotasi transform.z menjadi -70f
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, -70f);

            // Menonaktifkan collider sementara
            collider2d.enabled = false;

            // Mengecek jika objek berada di atas objek dengan tag yang sesuai
            var rayOrigin = Camera.main.transform.position;
            var rayDirection = MouseWorldPosition() - Camera.main.transform.position;
            RaycastHit2D[] hitInfo = Physics2D.RaycastAll(rayOrigin, rayDirection);

            // Reset nilai isHitBox
            isHitBox = false;

            if (hitInfo.Length > 0)
            {
                foreach (RaycastHit2D hit in hitInfo)
                {
                    if (hit.transform.tag == destinationTag)
                    {
                        // Menggeser objek ke posisi objek yang dituju
                        transform.position = hit.transform.position + new Vector3(0, 0, -0.01f);
                        Debug.Log("hit the box");
                        //spriteRenderer.sprite = newSprite;

                        // Mengatur nilai isHitBox menjadi true dan keluar dari loop
                        isHitBox = true;
                        break;
                    }
                }
            }

            // Mengatur rotasi dan sprite berdasarkan nilai isHitBox
            if (isHitBox)
            {
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0f);
                spriteRenderer.sprite = newSprite;
            }
            else
            {
                spriteRenderer.sprite = oldSprite;
            }

            // Mengaktifkan collider kembali
            collider2d.enabled = true;
        }
        else
        {
            //spriteRenderer.sprite = oldSprite;
            Debug.LogWarning("Sprite baru belum ditetapkan.");
        }
    }


    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }
}