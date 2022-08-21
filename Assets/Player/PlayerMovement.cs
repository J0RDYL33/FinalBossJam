using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float health;
    public Vector2 speed = new Vector2(50, 50);
    public float jumpAmount = 10;
    public bool grounded;
    public bool doubleJump;
    public GameObject healthbar;
    public Animator deathAnim;

    private Rigidbody2D myRb;
    private GroundCheck myGC;
    private bool facingRight;

    private float invulTimer = 0.5f;
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 5f;
    private float dashingTime = 0.02f;
    private float dashingCooldown = 1f;
    private Animator myAnim;
    private SpriteRenderer mySR;
    private BoxCollider2D myCol;
    private CameraMover theCam;

    [SerializeField] private TrailRenderer tr;

    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
        myGC = FindObjectOfType<GroundCheck>();
        myAnim = GetComponent<Animator>();
        mySR = GetComponent<SpriteRenderer>();
        myCol = GetComponent<BoxCollider2D>();
        theCam = FindObjectOfType<CameraMover>();
        tr.material.color = new Color(0.8588236f, 0.5411765f, 0.7098039f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        if (invulTimer > 0)
            invulTimer -= Time.deltaTime;

        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(speed.x * inputX, 0, 0);

        movement *= Time.deltaTime;

        transform.Translate(movement);
    }

    private void Update()
    {
        if (isDashing)
        {
            return;
        }

        //Move player
        if (Input.GetKeyDown(KeyCode.A))
        {
            facingRight = false;
            transform.localScale = new Vector3(-1f, 1f, 1);

        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.localScale = new Vector3(1f, 1f, 1);
            facingRight = true;
        }

        //Handle running animation
        if (Input.GetKey(KeyCode.A))
            myAnim.SetBool("Running", true);
        else if (Input.GetKey(KeyCode.D))
            myAnim.SetBool("Running", true);
        else if (Input.GetKey(KeyCode.A) == false || Input.GetKey(KeyCode.D) == false)
            myAnim.SetBool("Running", false);

        if (Input.GetKeyDown(KeyCode.Space) && (grounded == true || doubleJump == true))
        {
            StartCoroutine(PauseJumpForDouble());
            //myRb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
            //float jumpForce = Mathf.Sqrt(jumpAmount * -2 * (Physics2D.gravity.y * myRb.gravityScale));
            //myRb.AddForce(new Vector2(0, jumpForce * myRb.gravityScale), ForceMode2D.Impulse);
            myRb.velocity = new Vector2(myRb.velocity.x, jumpAmount);

            if (grounded == true)
                grounded = false;
            else if (doubleJump == true)
                doubleJump = false;
        }

        if ((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.S)) && canDash)
        {
            Debug.Log("Dash call");
            StartCoroutine(Dash());
        }
    }

    IEnumerator PauseJumpForDouble()
    {
        myAnim.SetBool("Jumping", false);
        yield return null;
        myAnim.SetBool("Jumping", true);
    }

    public void TakeDamage()
    {
        if (invulTimer <= 0)
        {
            theCam.StartScreenShake();
            health--;
            healthbar.transform.localScale = new Vector3(health, 1, 1);
            StartCoroutine(FlashRed());
            if (health <= 0)
            {
                myAnim.SetTrigger("Death");
                StartCoroutine(Death());
            }
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
        deathAnim.SetTrigger("Active");
        myRb.bodyType = RigidbodyType2D.Static;
        myCol.enabled = false;
        yield return new WaitForSeconds(1.0f);
        Destroy(this.gameObject);
    }

    private IEnumerator Dash()
    {
        myAnim.SetBool("Dashing", true);
        Debug.Log("Dashing");
        canDash = false;
        isDashing = true;
        float originalGravity = myRb.gravityScale;
        myRb.gravityScale = 0f;

        if(Input.GetKey(KeyCode.S))
            myRb.velocity = new Vector2(0, transform.localScale.y * (-dashingPower * 2.5f));
        else
            myRb.velocity = new Vector2(transform.localScale.x * dashingPower, transform.localScale.y * dashingPower);
        StartCoroutine(DashTrail());
        yield return new WaitForSeconds(dashingTime);
        myRb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    private IEnumerator DashTrail()
    {
        tr.material.color = new Color(1f, 0.5998304f, 0.3160377f);
        yield return new WaitForSeconds(0.5f);
        myAnim.SetBool("Dashing", false);
        tr.material.color = new Color(0.8588236f, 0.5411765f, 0.7098039f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            TakeDamage();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            TakeDamage();
        }
    }
}
