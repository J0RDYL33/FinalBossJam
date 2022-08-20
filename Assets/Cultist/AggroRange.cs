using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroRange : MonoBehaviour
{
    public CultistController myCultist;
    private CircleCollider2D myCol;
    // Start is called before the first frame update
    void Start()
    {
        myCol = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {


        if(other.gameObject.layer == 6 || other.gameObject.tag == "weapon")
        {
            myCol.enabled = false;
            myCultist.TurnAggro();
        }
    }
}
