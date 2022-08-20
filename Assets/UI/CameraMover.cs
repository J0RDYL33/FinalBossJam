using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public bool screenShaking;
    public int screenShakeAmount;

    private PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(screenShaking == false)
            transform.position = new Vector3(player.transform.position.x + 4, 0, -10);
    }

    public void StartScreenShake()
    {
        StartCoroutine(ScreenShake());
    }

    private IEnumerator ScreenShake()
    {
        screenShaking = true;
        Debug.Log("Starting screen shake");
        for (int i = 0; i < screenShakeAmount; i++)
        {
            float randX = Random.Range(-0.1f, .1f);
            float randY = Random.Range(-0.1f, .1f);
            transform.position = new Vector3((player.transform.position.x + 4) + randX, 0 + randY, -10);
            yield return new WaitForSeconds(.005f);
        }
        screenShaking = false;
    }
}
