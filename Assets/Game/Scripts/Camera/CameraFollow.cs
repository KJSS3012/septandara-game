using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Transform target;
    public float smoothSpeed = 0.08f;
    public float offset_X;
    public float offset_Y;
    public bool isFollowX;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {

        if (isFollowX)
        {
            HorizontalFollow();
        }
        else
        {
            Follow();
        }
        
    }

    public void Follow()
    {
        Vector3 startPosition = new Vector3(target.position.x + offset_X, target.position.y + offset_Y, -1f);
        Vector3 smoothPosition = Vector3.Lerp(transform.position, startPosition, smoothSpeed);
        transform.position = smoothPosition;
    }

    public void HorizontalFollow()
    {
        Vector3 startPosition = new Vector3(target.position.x + offset_X, transform.position.y, -1f);
        Vector3 smoothPosition = Vector3.Lerp(transform.position, startPosition, smoothSpeed);
        transform.position = smoothPosition;
    }


}
