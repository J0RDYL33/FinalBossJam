using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 speed = new Vector2(50, 50);
    public float jumpAmount = 10;
    public bool grounded;
    public bool doubleJump;

    private Rigidbody2D myRb;
    private GroundCheck myGC;
    private bool facingRight;

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 7f;
    private float dashingTime = 0.02f;
    private float dashingCooldown = 1f;

    [SerializeField] private TrailRenderer tr;

    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
        myGC = FindObjectOfType<GroundCheck>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

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

        if (Input.GetKeyDown(KeyCode.A))
        {
            facingRight = false;
            transform.localScale = new Vector3(-0.5f, 0.5f, 1);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 1);
            facingRight = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && (grounded == true || doubleJump == true))
        {
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

    private IEnumerator Dash()
    {
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
        tr.material.color = new Color(1f, 0f, 0f);
        yield return new WaitForSeconds(0.5f);
        tr.material.color = new Color(1f, 1f, 1f);
    }
}
