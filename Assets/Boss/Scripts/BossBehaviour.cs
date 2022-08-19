using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
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
            case 1000:
                GetComponent<DanmakuSpawner>().RingFlare(playerPosition, transform.position, 24, 3);
                break;
            case 4500:
                GetComponent<DanmakuSpawner>().RingFlare(playerPosition, transform.position, 24, 3);
                break;
            default:
                break;
        }

        timer++;
    }
}
