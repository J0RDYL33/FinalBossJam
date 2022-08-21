using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCamShaker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ScreenShake());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator ScreenShake()
    {
        Debug.Log("Starting screen shake");
        for (int i = 0; i < 5000; i++)
        {
            float randX = Random.Range(-0.1f, .1f);
            float randY = Random.Range(-0.1f, .1f);
            transform.position = new Vector3(0 + randX, 0 + randY, -10);
            yield return new WaitForSeconds(.005f);
        }
    }
}
