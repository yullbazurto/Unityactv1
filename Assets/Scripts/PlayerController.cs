using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    
   public float playerJumpForce = 20f;
   public float playerSpeed = 5f;
   public Sprite[] mySprites;
   private int index = 0;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("ItemGood"))
        {
            Destroy(collision.gameObject);
            myGameManager.AddScore();
        }
        else if(collision.CompareTag("ItemBad"))
        {
                Destroy(collision.gameObject);
                PlayerDeath();

        }
        else if(collision.CompareTag("DeathZone"))
        {
                PlayerDeath();
        }

    }

    void PlayerDeath()
    {

        SceneManager.LoadScene("SampleScene");
    }





   private Rigidbody2D  myrigidbody2D;
   private SpriteRenderer mySpriteRenderer;
   public GameObject Bullet;
  public GameManager myGameManager;
    void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(WalkCoRutine());
       myGameManager = FindObjectOfType<GameManager>();
        if (myGameManager == null)
        {
            Debug.LogError("GameManager no encontrado en la escena. Asegúrate de que está añadido.");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            myrigidbody2D.linearVelocity = new Vector2(myrigidbody2D.linearVelocity.x,playerJumpForce);
        }
        myrigidbody2D.linearVelocity = new Vector2(playerSpeed,myrigidbody2D.linearVelocity.y);


         if(Input.GetKeyDown(KeyCode.E)){

        Instantiate(Bullet,transform.position,Quaternion.identity);
    }
    }
   

IEnumerator WalkCoRutine(){
yield return new WaitForSeconds(0.05f);
        mySpriteRenderer.sprite = mySprites[index];
        index++;
        if(index == 6)
        {

            index = 0;

        }
        StartCoroutine(WalkCoRutine());

}

}