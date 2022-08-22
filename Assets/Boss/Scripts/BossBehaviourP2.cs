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

    //JC
    public GameObject healthbar;
    public SpriteRenderer cloakSR;
    public SpriteRenderer maskSR;
    private LevelLoader loader;
    private float invulTimer = 0.6f;
    private float healthbarScale = 0.97f;
    private float health = 100;
    private AudioManager audioObject;

    private void Start()
    {
        //GetComponent<DanmakuSpawner>().FireRing();
        player = GameObject.FindGameObjectWithTag("Player");

        //JC
        loader = FindObjectOfType<LevelLoader>();
        audioObject = FindObjectOfType<AudioManager>();
    }

    private void FixedUpdate()
    {
        if (invulTimer >= 0)
            invulTimer -= Time.deltaTime;

        // Phase 2 should be less dense with attacks
        switch (timer)
        {
            case 200:
                GetComponent<DanmakuSpawner>().RingFlare(playerPosition, transform.position, 6, 1);
                audioObject.PlaySound("bossBullet");
                //GameObject spawnedPillars = Instantiate(pillars, pillarSpawn, Quaternion.identity);
                //spawnedPillars.GetComponent<FloorPillars>().isActivated = true;
                //Debug.Log("Pillars instantiated");
                break;
            case 250:
                GameObject spawnedRock = Instantiate(moonRock, new Vector2(0, 25), Quaternion.identity);
                spawnedRock.GetComponent<MoonRock>().targetPos = playerPosition;
                Debug.Log("Moon Rock instantiated");
                break;
            case 600:
                GameObject spawnedPillars = Instantiate(pillars, pillarSpawn, Quaternion.identity);
                spawnedPillars.GetComponent<FloorPillars>().isActivated = true;
                Debug.Log("Pillars instantiated");

                //spawnedRock = Instantiate(moonRock, new Vector2(0, 25), Quaternion.identity);
                //spawnedRock.GetComponent<MoonRock>().targetPos = playerPosition;
                //Debug.Log("Moon Rock instantiated");
                break;
            case 850:
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
            case 1050:
                GetComponent<DanmakuSpawner>().RingFlare(playerPosition, transform.position, 6, 3);
                audioObject.PlaySound("bossBullet");
                spawnedRock = Instantiate(moonRock, new Vector2(0, 25), Quaternion.identity);
                spawnedRock.GetComponent<MoonRock>().targetPos = playerPosition;
                Debug.Log("Moon Rock instantiated");
                break;
            case 1100:
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

    //JC
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Boss hitbox entered");
        if (collision.gameObject.tag == "weapon" && invulTimer <= 0)
        {
            StartCoroutine(FlashRed());
            Debug.Log("Boss damaged!");
            invulTimer = 0.6f;
            TakeDamage(4);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthbar.gameObject.transform.localScale = new Vector3((healthbarScale / 100) * health, 0.8f, 1);

        if (health <= 20)
        {
            loader.SceneTransition();
        }
    }

    IEnumerator FlashRed()
    {
        cloakSR.color = Color.red;
        maskSR.color = Color.red;
        yield return new WaitForSeconds(.2f);
        cloakSR.color = Color.white;
        maskSR.color = Color.white;
    }
}
