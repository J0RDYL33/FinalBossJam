using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* <Joe>
 * 
 * Danmaku Spawner Script
 *  This script can be attached to any entity that can fire bullet patterns.
 *  It will function as a library of bullet patterns to be called by the attached
 *  entity. The utility of this script will be that calling a pattern's function will
 *  be all you need to do to fire it. The functions are wrappers for co-routines.
 */

public class DanmakuSpawner : MonoBehaviour
{
    // References to less used prefabs

    
    // Fires rings of bullets out from centre
    public void FireRing(Vector2 playerPosAtCall, Vector2 spawnPatternAt, int bulletsInRing, int bulletWaves)
    {
        StartCoroutine(FireRingCR(playerPosAtCall, spawnPatternAt, bulletsInRing, bulletWaves));
    }

    IEnumerator FireRingCR(Vector2 playerPos, Vector2 spawnPos, int bulCount, int bulWaves)
    {
        float angleStep = 360 / bulCount;
        float angle = 0;

        for (int i = 0; i < bulWaves; i++)
        {
            for (int j = 0; j < bulCount; j++)
            {
                float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
                float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

                Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
                Vector2 bulDir = (bulMoveVector - transform.position).normalized;

                GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
                bul.transform.position = transform.position;
                bul.transform.rotation = transform.rotation;
                bul.SetActive(true);
                bul.GetComponent<Bullet>().SetMoveDir(bulDir);

                angle += angleStep;
            }

            yield return new WaitForSeconds(0.5f);
        }
    }


    // Fires a spiral of bullets
    public void SpiralFlare(Vector2 playerPosAtCall, Vector2 spawnPatternAt, int spiralArms, int armLength)
    {
        StartCoroutine(SpiralFlareCR(playerPosAtCall, spawnPatternAt, spiralArms, armLength));
    }

    IEnumerator SpiralFlareCR(Vector2 playerPos, Vector2 spawnPos, int arms, int length)
    {
        float angleStep = 360 / arms;
        float angle = 0;

        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < arms; j++)
            {
                float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
                float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

                Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
                Vector2 bulDir = (bulMoveVector - transform.position).normalized;

                GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
                bul.transform.position = transform.position;
                bul.transform.rotation = transform.rotation;
                bul.SetActive(true);
                bul.GetComponent<Bullet>().SetMoveDir(bulDir);

                angle += angleStep;
            }

            angle += 10;
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void RingFlare(Vector2 playerPosAtCall, Vector2 spawnPatternAt, int bulletsInRing, int bulletWaves)
    {
        StartCoroutine(RingFlareCR(playerPosAtCall, spawnPatternAt, bulletsInRing, bulletWaves));
    }

    IEnumerator RingFlareCR(Vector2 playerPos, Vector2 spawnPos, int bulCount, int bulWaves)
    {
        float angleStep = 360 / bulCount;
        float angle = 0;

        StartCoroutine(SpiralFlareCR(playerPos, spawnPos, 5, 8));

        for (int i = 0; i < bulWaves; i++)
        {
            for (int j = 0; j < bulCount; j++)
            {
                float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
                float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

                Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
                Vector2 bulDir = (bulMoveVector - transform.position).normalized;

                GameObject bul = MegaBulletPool.megaBulletPoolInstance.GetBullet();
                bul.transform.position = transform.position;
                bul.transform.rotation = transform.rotation;
                bul.SetActive(true);
                bul.GetComponent<Bullet>().SetMoveDir(bulDir);

                angle += angleStep;
            }

            yield return new WaitForSeconds(1f);
        }
    }
}
