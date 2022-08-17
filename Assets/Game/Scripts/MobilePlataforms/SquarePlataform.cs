using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquarePlataform : MonoBehaviour
{
     public float speedPlataform;
    private Vector3 nextPosition;
    public Transform posOne, posTwo, posThree, posFour;
    // Start is called before the first frame update
    void Start()
    {
        nextPosition = posOne.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveEnemy();
    }

     private void MoveEnemy()
    {
            if (transform.position == posOne.position)
            {
                nextPosition = posTwo.position;
            }
            if (transform.position == posTwo.position)
            {
                nextPosition = posThree.position;
            }
            if (transform.position == posThree.position)
            {
                nextPosition = posFour.position;
            }
             if (transform.position == posFour.position)
            {
                nextPosition = posOne.position;
            }

            transform.position = Vector3.MoveTowards(transform.position, nextPosition, speedPlataform * Time.fixedDeltaTime);
        }
     private void OnDrawGizmos()
    {
        Gizmos.DrawLine(posOne.position, posTwo.position);
        Gizmos.DrawLine(posTwo.position, posThree.position);
        Gizmos.DrawLine(posThree.position, posFour.position);
        Gizmos.DrawLine(posFour.position, posOne.position);
    }
}
