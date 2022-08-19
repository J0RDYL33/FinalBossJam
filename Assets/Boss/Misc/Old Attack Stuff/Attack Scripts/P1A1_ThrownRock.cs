using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1A1_ThrownRock : BossAttack
{
    public override void Init()
    {
        movementSpeed = 5f;
    }

    public override void InferDestination()
    {
        targetDest = playerPosOnSummon;
    }

    public override void PlaceSelfAppropriately()
    {
        transform.position = new Vector2 (0, 6);
    }
}
