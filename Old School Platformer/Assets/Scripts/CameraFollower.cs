using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{

    public Transform target;

    public float smoothSpeed = 0.125f;
    private Vector3 offset;

    void FixedUpdate()
    {
        offset.y = 0;
        offset.x = 0;
        offset.z = -10;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

       // transform.LookAt(target);
    }

}