using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* <Joe>
 * 
 * Multi-Target Camera
 *  Following Brackey's tutorial https://www.youtube.com/watch?v=aLpixrPvlB8
 */

[RequireComponent(typeof(Camera))]
public class MultiTargetCam : MonoBehaviour
{
    public List<Transform> targets;

    public Vector3 offset;
    public float smoothTime = 0f;

    public float minZoom = 40f;
    public float maxZoom = 10f;
    public float zoomLimiter = 50f;

    private Vector3 velocity;
    private Camera cam;


    private void Start()
    {
        cam = GetComponent<Camera>();
    }


    private void LateUpdate()
    {
        if (targets.Count == 0)
            return;

        Move();
        Zoom();
    }

    private void Move()
    {
        Vector3 centrePoint = GetCentrePoint();

        Vector3 newPosition = centrePoint + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    private void Zoom()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / zoomLimiter);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, newZoom, Time.deltaTime);
    }

    float GetGreatestDistance()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);

        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.size.x;
    }

    Vector3 GetCentrePoint()
    {
        if (targets.Count == 1)
        {
            return targets[0].position;
        }

        var bounds = new Bounds (targets[0].position, Vector3.zero);

        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.center;
    }
}
