using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speedEnemy;
    public Transform posStart, posEnd;
    private Vector3 nextPosition;
    [SerializeField] private SpriteRenderer enemySprite;
    [SerializeField] private Animator enemyAnim;
    [SerializeField] private CircleCollider2D colliderAttack;

    private void Start()
    {
        nextPosition = posStart.position;
        enemySprite = GetComponent<SpriteRenderer>();
        enemyAnim = GetComponent<Animator>();
        colliderAttack = GetComponent<CircleCollider2D>();
        enemyAnim.SetBool("cursed", true);
    }

    private void DetectHead()
    {
        if (colliderAttack.CompareTag("Player"))
        {
            Debug.Log("PISANDO NA CABEÇA!");
        }
    }

    private void FixedUpdate()
    {
        DetectHead();
        if (transform.position == posStart.position)
        {
            enemySprite.flipX = true;
            nextPosition = posEnd.position;
        }
        if (transform.position == posEnd.position)
        {
            enemySprite.flipX = false;
            nextPosition = posStart.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPosition, speedEnemy * Time.fixedDeltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(posStart.position, posEnd.position);
    }

}
