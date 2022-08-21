using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CultistController : MonoBehaviour
{
    public bool spawnBullet;
    public Animator dialog;
    public bool hasDialog;
    public int health;

    private SpriteRenderer mySR;
    private Animator myAnim;
    private bool aggresive;
    private PlayerMovement player;
    private bool facingRight;
    private CameraMover theCam;
    private float invulTime = 0.5f;
    private Rigidbody2D myRB;
    private BoxCollider2D myCol;

    private Vector2 playerPosition;
    private GameObject playerObject;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        player = FindObjectOfType<PlayerMovement>();
        theCam = FindObjectOfType<CameraMover>();
        mySR = GetComponent<SpriteRenderer>();
        myRB = GetComponent<Rigidbody2D>();
        myCol = GetComponent<BoxCollider2D>();

        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = playerObject.transform.position;

        if (transform.position.x > player.transform.position.x)
        {
            facingRight = false;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (transform.position.x <= player.transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
            facingRight = true;
        }
    }

    private void FixedUpdate()
    {
        if (spawnBullet == true && health > 0)
            SpawnBullet();

        if (invulTime > 0)
            invulTime -= Time.deltaTime;
    }

    public void TurnAggro()
    {
        myAnim.SetTrigger("Aggro");
        aggresive = true;

        if (hasDialog == true)
        {
            dialog.SetTrigger("DoDialog");
        }
    }

    public void SpawnBullet()
    {
        spawnBullet = false;
        Debug.Log("Bullet Spawned!");
        //theCam.StartScreenShake();

        GameObject bul = Instantiate(bullet, transform.position, Quaternion.identity);
        bullet.GetComponent<cultBullet>().target = playerPosition;
    }

    public void TakeDamage()
    {
        health--;
        StartCoroutine(FlashRed());
        if(health <= 0)
        {
            myAnim.SetTrigger("Death");
            StartCoroutine(Death());
        }
    }   
    
    IEnumerator FlashRed()
    {
        mySR.color = Color.red;
        yield return new WaitForSeconds(.3f);
        mySR.color = Color.white;
    }

    IEnumerator Death()
    {
        myRB.bodyType = RigidbodyType2D.Static;
        myCol.enabled = false;
        yield return new WaitForSeconds(1.0f);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision enter");
        if (collision.gameObject.tag == "weapon" && invulTime <= 0)
        {
            Debug.Log("Taking damage");
            TakeDamage();
            invulTime = 0.5f;
        }
    }
}
