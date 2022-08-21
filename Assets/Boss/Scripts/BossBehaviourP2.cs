using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviourP2 : MonoBehaviour
{
    public GameObject pillars;
    public GameObject moonRock;
    public GameObject wallAttack;

    private Vector2 playerPosition;
    private GameObject player;
    private int timer;
    private Vector2 pillarSpawn = new Vector2(0, -25);

    private void Start()
    {
        //GetComponent<DanmakuSpawner>().FireRing();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        // Update player's position
        playerPosition = player.transform.position;

        // Phase 2 should be less dense with attacks
        switch (timer)
        {
            case 2000:
                GetComponent<DanmakuSpawner>().RingFlare(playerPosition, transform.position, 6, 1);

                //GameObject spawnedPillars = Instantiate(pillars, pillarSpawn, Quaternion.identity);
                //spawnedPillars.GetComponent<FloorPillars>().isActivated = true;
                //Debug.Log("Pillars instantiated");
                break;
            case 2500:
                GameObject spawnedRock = Instantiate(moonRock, new Vector2(0, 25), Quaternion.identity);
                spawnedRock.GetComponent<MoonRock>().targetPos = playerPosition;
                Debug.Log("Moon Rock instantiated");
                break;
            case 6000:
                GameObject spawnedPillars = Instantiate(pillars, pillarSpawn, Quaternion.identity);
                spawnedPillars.GetComponent<FloorPillars>().isActivated = true;
                Debug.Log("Pillars instantiated");

                //spawnedRock = Instantiate(moonRock, new Vector2(0, 25), Quaternion.identity);
                //spawnedRock.GetComponent<MoonRock>().targetPos = playerPosition;
                //Debug.Log("Moon Rock instantiated");
                break;
            case 8500:
                int randSide = Random.Range(0, 51);
                int randHeight = Random.Range(-5, 4);

                if (randSide <= 25)
                {
                    Vector2 spawn = new Vector2(30, randHeight);
                    GameObject walls = Instantiate(wallAttack, spawn, Quaternion.identity);
                } else
                {
                    Vector2 spawn = new Vector2(-30, randHeight);
                    GameObject walls = Instantiate(wallAttack, spawn, Quaternion.identity);
                }

                break;
            case 10500:
                GetComponent<DanmakuSpawner>().RingFlare(playerPosition, transform.position, 6, 3);

                spawnedRock = Instantiate(moonRock, new Vector2(0, 25), Quaternion.identity);
                spawnedRock.GetComponent<MoonRock>().targetPos = playerPosition;
                Debug.Log("Moon Rock instantiated");
                break;
            case 11000:
                timer = 0;
                break;
            default:
                break;
        }

        timer++;
    }
}
