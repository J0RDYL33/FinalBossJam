using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* <Joe>
 * 
 * Laserbeam Bullet Object
 *  The laserbeam is an object that will point towards the player's
 *  location from offscreen and move through it, out towards the
 *  opposite side of the screen. It has simple movement behaviour once
 *  created.
 */

public class Laserbeam : MonoBehaviour
{
    Vector2 targetDestination;
    int speed;
    bool canMove = false;

    public void Initialise(Vector2 playerPosition, Vector2 spawnPosition, int moveSpeed)
    {
        targetDestination = playerPosition;
        transform.position = spawnPosition;
        speed = moveSpeed;

        canMove = true;
        Invoke("Destroy", 10f);
    }

    private void Update()
    {
        if (canMove)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetDestination, step);          
        }
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }
}
