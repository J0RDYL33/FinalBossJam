using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 moveDir;
    private float speed = 3f;

    private void OnEnable()
    {
        Invoke("Destroy", 3f);
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
