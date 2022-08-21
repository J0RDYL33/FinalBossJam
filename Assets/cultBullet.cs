using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cultBullet : MonoBehaviour
{
    public Vector2 target;
    public float speed = 3f;

    private float step;

    public void Start()
    {
        Invoke("DestroySelf", 2f);
    }

    public void Update()
    {
        step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target, step);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision enter");
        if (collision.gameObject.layer == 6) // "Player" layer
        {
            Debug.Log("Bullet hit player");
            DestroySelf();
        }
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
