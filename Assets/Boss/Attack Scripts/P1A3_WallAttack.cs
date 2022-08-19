using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1A3_WallAttack : BossAttack
{
    public override void Init()
    {
        movementSpeed = 4f;
    }

    public override void InferDestination()
    {
        targetDest = playerPosOnSummon;
    }

    public override void PlaceSelfAppropriately()
    {
        // 0 = left, 1 = right
        int randSide = Random.Range(0, 51);

        int randHeight = Random.Range(-4, 4);

        int xStart = 0;

        // Also overwrite destination to the opposite side
        if (randSide <= 25)
        {
            xStart = -12;
            targetDest.x = 12;

        } else
        {
            xStart = 12;
            targetDest.x = -12;
        }

        targetDest.y = randHeight;

        transform.position = new Vector2(xStart, randHeight);

    }
}
