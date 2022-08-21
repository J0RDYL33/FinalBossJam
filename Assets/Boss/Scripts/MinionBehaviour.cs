using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionBehaviour : MonoBehaviour
{
    private Vector2 playerPosition;
    private GameObject player;
    private int timer;

    private void Start()
    {
        //GetComponent<DanmakuSpawner>().FireRing();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        // Update player's position
        playerPosition = player.transform.position;

        switch (timer)
        {
            case 10:
                GetComponent<DanmakuSpawner>().FireRing(playerPosition, transform.position, 6, 3);
                break;
            case 400:
                GetComponent<DanmakuSpawner>().SpiralFlare(playerPosition, transform.position, 6, 3);
                break;
            case 800:
                timer = 0;
                break;
            default:
                break;
        }

        timer++;
    }

    private void Update()
    {

    }

}
