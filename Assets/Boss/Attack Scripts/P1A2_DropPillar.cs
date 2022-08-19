using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1A2_DropPillar : BossAttack
{
    public override void Init()
    {
        movementSpeed = 5f;
    }

    public override void InferDestination()
    {
        // In order to infer its destination, raycast below player location
        // to find the platform beneath it.

        // For now, just fall off bottom of screen
        targetDest = new Vector2(playerPosOnSummon.x, -15);
    }

    public override void PlaceSelfAppropriately()
    {
        // The pillar needs placing directly above player
        transform.position = new Vector2(playerPosOnSummon.x, 6);
    }
}
