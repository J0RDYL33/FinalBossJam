using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonRock : MonoBehaviour
{
    public Vector2 targetPos;
    public float movementSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float step = movementSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, targetPos, step);

        if (transform.position.x == targetPos.x && transform.position.y == targetPos.y)
        {
            Destroy(gameObject);
        }
    }
}
