using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaBulletPool : MonoBehaviour
{
    public static MegaBulletPool megaBulletPoolInstance;


    [SerializeField]
    private GameObject pooledBullet;
    private bool notEnoughPooled = true;
    private List<GameObject> bullets;

    private void Awake()
    {
        // Set the instance reference
        megaBulletPoolInstance = this;
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
