using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandHitter : MonoBehaviour
{
    private float invulTimer = 0.6f;
    private BossBehaviourP1 boss;
    private SpriteRenderer mySR;
    // Start is called before the first frame update
    void Start()
    {
        boss = FindObjectOfType<BossBehaviourP1>();
        mySR = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (invulTimer >= 0)
            invulTimer -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "weapon" && invulTimer <= 0)
        {
            StartCoroutine(FlashRed());
            invulTimer = 0.6f;
            boss.TakeDamage(2);
        }
    }

    IEnumerator FlashRed()
    {
        mySR.color = Color.red;
        yield return new WaitForSeconds(.2f);
        mySR.color = Color.white;
    }
}
