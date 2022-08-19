using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* <Joe>
 * 
 * Boss Attack parent class
 *  All attacks will inherit from this class. The structure of attacks will be simply to
 *  receive a player location, infer a target destination, enable hitboxes, and progress 
 *  towards it. Once reached, destroy.
 */

public class BossAttack : MonoBehaviour
{
    public Vector2 targetDest;
    public Vector2 playerPosOnSummon;

    [SerializeField] public float movementSpeed;
    [SerializeField] public bool _canMove = false;

    // ONLY NEEDED FOR TESTING, REMOVE WHEN BOSS CAN PROVIDE DETAILS
    public void Start()
    {
        // Dummy setup for Summon
        Vector2 pL = GameObject.FindGameObjectWithTag("Player").transform.position;

        Summon(pL);
    }

    // Called once per frame
    public void Update()
    {
        // Only allow movement once Summon has set up the attack
        if (_canMove == true)
        {
            // Move towards destination
            float step = movementSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetDest, step);
        }

        // Check for reaching destination
        if (transform.position.x == targetDest.x && transform.position.y == targetDest.y)
        {
            DestroySelf();
        }
    }

    // Summon is the master function for initiating behaviour
    public void Summon(Vector2 playerLocation)
    {
        // Store player location on summon
        playerPosOnSummon = playerLocation;

        Init();
        InferDestination();
        PlaceSelfAppropriately();

        // Allow attack to move
        _canMove = true;
    }

    // Initialise custom properties
    public virtual void Init()
    {

    }

    // Given playerLocation, find where to move to
    public virtual void InferDestination()
    {

    }

    // Set initial position to appropriate placement for attack
    public virtual void PlaceSelfAppropriately()
    {

    }

    // Once destination reached, die
    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
