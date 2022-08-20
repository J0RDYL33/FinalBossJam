using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSpinner : MonoBehaviour
{
    public float rotateAmount;

    private float currentRotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.localRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, currentRotation + rotateAmount);
        currentRotation += rotateAmount;
    }
}
