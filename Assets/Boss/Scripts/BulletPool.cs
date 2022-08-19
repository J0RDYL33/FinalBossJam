using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* <Joe>
 * 
 * This is a bullet pool for efficient use of bullets without resorting
 * to constant instantiate and destroy calls that may impact performance.
 * It acts like a reservoir of all currently unused bullets that can be
 * pulled from when required.
 */

public class BulletPool : MonoBehaviour
{
    public static BulletPool bulletPoolInstance;


    [SerializeField] 
    private GameObject pooledBullet;
    private bool notEnoughPooled = true;
    private List<GameObject> bullets;

    private void Awake()
    {
        // Set the instance reference
        bulletPoolInstance = this;
    }

    private void Start()
    {
        // Initialise new list of bullets
        bullets = new List<GameObject>();
    }

    public GameObject GetBullet()
    {
        if (bullets.Count > 0)
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                if (!bullets[i].activeInHierarchy)
                {
                    return bullets[i];
                }
            }
        }

        if (notEnoughPooled)
        {
            GameObject bullet = Instantiate(pooledBullet);
            bullet.SetActive(false);
            bullets.Add(bullet);
            return bullet;
        }

        return null;
    }
}
