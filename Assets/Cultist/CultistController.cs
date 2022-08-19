using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CultistController : MonoBehaviour
{
    public bool spawnBullet;
    public Animator dialog;
    public bool hasDialog;

    private Animator myAnim;
    private bool aggresive;
    private PlayerMovement player;
    private bool facingRight;
    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        player = FindObjectOfType<PlayerMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > player.transform.position.x)
        {
            facingRight = false;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (transform.position.x <= player.transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
            facingRight = true;
        }

        if (spawnBullet == true)
            SpawnBullet();
    }

    public void TurnAggro()
    {
        myAnim.SetTrigger("Aggro");
        aggresive = true;

        if (hasDialog == true)
        {
            dialog.SetTrigger("DoDialog");
        }
    }

    public void SpawnBullet()
    {
        spawnBullet = false;
        Debug.Log("Bullet Spawned!");
    }
}
