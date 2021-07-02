using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentPlataform : MonoBehaviour
{
    public float speedMove;
    public Transform posOne, posTwo;
    public Transform startPosition;

    private Vector3 nextPosition;

    private void Start()
    {
        nextPosition = startPosition.position;
    }

    private void FixedUpdate()
    {
        if (transform.position == posOne.position)
        {
            nextPosition = posTwo.position;
        }
        if(transform.position == posTwo.position)
        {
            nextPosition = posOne.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPosition, speedMove * Time.fixedDeltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(posOne.position, posTwo.position);
    }



}
