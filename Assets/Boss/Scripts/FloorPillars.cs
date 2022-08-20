using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorPillars : MonoBehaviour
{
    public bool isActivated = false;
    private Vector2 targetDest1 = new Vector2(0, -15);
    private Vector2 targetDest2 = new Vector2(0, 5);
    private Vector2 targetDest3 = new Vector2(0, -50);
    private float movementSpeed1 = 4f;
    private float movementSpeed2 = 8f;
    private Vector2 startPos;
    private float step = 0;
    private bool onReturn = false;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActivated)
        {

            StartCoroutine(PillarCR());
            //isActivated = false;
        }  
    }

    IEnumerator PillarCR()
    {
        step = movementSpeed1 * Time.deltaTime;

        // If not returning, move to the first checkpoint
        if (!onReturn)
            transform.position = Vector2.MoveTowards(transform.position, targetDest1, step);

        // If returning, head to bottom of screen
        if (onReturn)
        {
            step *= 16;
            yield return new WaitForSeconds(2f);
            transform.position = Vector2.MoveTowards(transform.position, targetDest3, step);
        }

        // If returning and has passed a threshold, destroy
        if (onReturn && transform.position.y < -30)
            Destroy(gameObject);

        // If reached first checkpoint but not next, speed up and move to next
        if (!onReturn && transform.position.y >= targetDest1.y && transform.position.y < targetDest2.y)
        {
            Debug.Log("Reached C1");
            step *= 16;
            transform.position = Vector2.MoveTowards(transform.position, targetDest2, step);

        }

        // If reached final checkpoint, bring it back down to startPos
        if (transform.position.y >= targetDest2.y)
        {
            Debug.Log("Reached C2, on return");
            onReturn = true;          
        }
    }
}
