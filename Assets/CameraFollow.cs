using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //public Transform target;
    //public float smoothSpeed = 0.125f;

    //private void FixedUpdate()
    //{
    //    Vector3 desiredPosition = new Vector3(2.5f, target.position.y + 1.5f, -7);
    //    Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
    //    transform.position = smoothedPosition;
    //}

    public Transform target;
    private Vector3 offset;
    public float smoothSpeed;
    void Start()
    {
        offset = transform.position - target.position;
    }
    //void Update()
    //{
    //    Vector3 newPos = Vector3.Lerp(transform.position, offset + target.position, smoothSpeed);
    //    transform.position = newPos;
    //}
    private void FixedUpdate()
    {
        Vector3 newPos = Vector3.Lerp(transform.position, offset + target.position, smoothSpeed);
        transform.position = newPos;
    }
}
