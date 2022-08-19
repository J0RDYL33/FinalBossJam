using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 moveDir;
    public float speed = 5f;
    public float deathTime = 5f;

    private void OnEnable()
    {
        Invoke("Destroy", deathTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDir * speed * Time.deltaTime);
    }

    public void SetMoveDir(Vector2 direction)
    {
        moveDir = direction;
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
