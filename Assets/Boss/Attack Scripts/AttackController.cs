using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* <Joe>
 * 
 * This controller is the part of the boss that co-ordinates attacks
 * on the player. It will be setup differently between each phase.
 * 
 * There is a list of attacks that can be used by this instance. These
 * are considered to be the boss' special moves. Generic projectile moves
 * are handled differently.
 */

public class AttackController : MonoBehaviour
{
    public GameObject[] attacks;
    public Vector2 playerLocation;

    public GameObject Player;

    private GameObject currentAttack;

    private int _timer = 0;

    public void Start()
    {
        // Get reference to Player in scene
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Update()
    {
        // Get player's location each frame
        playerLocation = Player.transform.position;

        // This timer switch calls attacks based on passed frames
        switch (_timer)
        {
            // Introduce attacks slowly
            case 60:    // Rock Throw
                currentAttack = Instantiate(attacks[0]);
                currentAttack.GetComponent<BossAttack>().Summon(playerLocation);
                break;
            case 800:   // Drop Pillar
                currentAttack = Instantiate(attacks[1]);
                currentAttack.GetComponent<BossAttack>().Summon(playerLocation);
                break;
            case 1500:   // Wall Attack
                currentAttack = Instantiate(attacks[2]);
                currentAttack.GetComponent<BossAttack>().Summon(playerLocation);
                break;
            default:
                break;
        }

        _timer++;

        if (_timer >= 2800)
        {
            _timer = 0;
        }
    }
}
