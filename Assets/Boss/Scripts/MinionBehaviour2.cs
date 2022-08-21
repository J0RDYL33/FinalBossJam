using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionBehaviour2 : MonoBehaviour
{
    private Vector2 playerPosition;
    private GameObject player;
    private int timer;

    private void Start()
    {
        //GetComponent<DanmakuSpawner>().FireRing();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        // Update player's position
        playerPosition = player.transform.position;

        switch (timer)
        {
            case 100:
                GetComponent<DanmakuSpawner>().FireRing(playerPosition, transform.position, 15, 1);        
                break;
            case 2000:
                timer = 0;
                break;
            default:
                break;
        }

        timer++;
    }

}
