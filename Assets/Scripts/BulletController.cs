using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Rigidbody2D myrigidbody2D;
    public float bulletSpeed = 10f;
    public GameManager myGameManager;
    public Sprite[] bulletSprites; // Array de sprites para las balas
    private SpriteRenderer mySpriteRenderer; // Componente para cambiar los sprites

    void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
        myGameManager = FindFirstObjectByType<GameManager>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();

        // Asignar un sprite al azar al inicio
        if (bulletSprites.Length > 0)
        {
            mySpriteRenderer.sprite = bulletSprites[Random.Range(0, bulletSprites.Length)];
        }
    }

    void Update()
    {
        myrigidbody2D.linearVelocity = new Vector2(bulletSpeed, myrigidbody2D.linearVelocity.y);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ItemGood"))
        {
            Destroy(collision.gameObject); // Destruye el objeto bueno si la bala lo toca
        }
        else if (collision.CompareTag("ItemBad"))
        {
            //myGameManager.AddScore(); // Incrementa la puntuación
            Destroy(collision.gameObject); // Destruye el objeto malo
            Destroy(gameObject); // Destruye la bala tras el impacto
        }
    }
}