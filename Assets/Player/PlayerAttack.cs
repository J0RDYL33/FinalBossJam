using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float damage;
    public float startTimeBtwAttack;
    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemies;
    public Animator playersAnim;

    private AudioManager audioObject;
    private float timeBtwAttack;
    // Start is called before the first frame update
    void Start()
    {
        audioObject = FindObjectOfType<AudioManager>();
        Debug.Log(playersAnim);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwAttack <= 0)
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                audioObject.PlaySound("swordSwing");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                Debug.Log("Attacking");
                StartCoroutine(StartAttack());
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    //enemiesToDamage[i].TakeDamage(damage);
                }

                timeBtwAttack = startTimeBtwAttack;
            }
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    public IEnumerator StartAttack()
    {
        playersAnim.SetBool("Attacking", true);
        yield return new WaitForSeconds(0.333f);
        playersAnim.SetBool("Attacking", false);
    }
}
