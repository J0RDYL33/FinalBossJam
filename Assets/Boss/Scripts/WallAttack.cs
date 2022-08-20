using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallAttack : MonoBehaviour
{
    public float movementSpeed;
    private bool isMovingRight;
    private float step = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // Determine where to move based on spawn location
        if (transform.position.x > 0)
            isMovingRight = false;
        else
            isMovingRight = true;

        movementSpeed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        step = movementSpeed * Time.deltaTime;

        if (isMovingRight)
            transform.position = Vector2.MoveTowards(transform.position, new Vector2 (50, transform.position.y), step);
        else
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(-50, transform.position.y), step);

        if (transform.position.x == 50 || transform.position.x == -50)
            Destroy(gameObject);
    }
}
