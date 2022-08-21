using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviourP3 : MonoBehaviour
{
    public GameObject pillars;
    public GameObject moonRock;

    private Vector2 playerPosition;
    private GameObject player;
    private int timer;
    private Vector2 pillarSpawn = new Vector2(0, -25);

    private void Start()
    {
        //GetComponent<DanmakuSpawner>().FireRing();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {

        switch (timer)
        {
            case 200:
                GetComponent<DanmakuSpawner>().RingFlare(playerPosition, transform.position, 8, 4);

                GameObject spawnedPillars = Instantiate(pillars, pillarSpawn, Quaternion.identity);
                spawnedPillars.GetComponent<FloorPillars>().isActivated = true;
                Debug.Log("Pillars instantiated");
                break;
            case 250:
                GameObject spawnedRock = Instantiate(moonRock, new Vector2(0, 25), Quaternion.identity);
                spawnedRock.GetComponent<MoonRock>().targetPos = playerPosition;
                Debug.Log("Moon Rock instantiated");
                break;
            case 500:
                spawnedPillars = Instantiate(pillars, pillarSpawn, Quaternion.identity);
                spawnedPillars.GetComponent<FloorPillars>().isActivated = true;
                Debug.Log("Pillars instantiated");

                spawnedRock = Instantiate(moonRock, new Vector2(0, 25), Quaternion.identity);
                spawnedRock.GetComponent<MoonRock>().targetPos = playerPosition;
                Debug.Log("Moon Rock instantiated");
                break;
            case 800:
                GetComponent<DanmakuSpawner>().RingFlare(playerPosition, transform.position, 6, 3);

                spawnedRock = Instantiate(moonRock, new Vector2(0, 25), Quaternion.identity);
                spawnedRock.GetComponent<MoonRock>().targetPos = playerPosition;
                Debug.Log("Moon Rock instantiated");
                break;
            case 1000:
                timer = 0;
                break;
            default:
                break;
        }

        timer++;
    }

    private void Update()
    {
        // Update player's position
        playerPosition = player.transform.position;


    }
}
