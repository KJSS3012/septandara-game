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
    [SerializeField] private bool isMoviment;
    [SerializeField] private CircleCollider2D colliderHeadEnemy;
    [SerializeField] private CapsuleCollider2D colliderBodyEnemy;
    [SerializeField] private Player player;

    private void Start()
    {
        nextPosition = posStart.position;
        colliderHeadEnemy = GetComponent<CircleCollider2D>();
        colliderBodyEnemy = GetComponent<CapsuleCollider2D>();
        enemySprite = GetComponent<SpriteRenderer>();
        enemyAnim = GetComponent<Animator>();
        enemyAnim.SetBool("cursed", true);
        isMoviment = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.gameObject.GetComponent<Player>();
        }
    }

    public void DownEnemy()
    {
        enemyAnim.SetBool("cursed", false);
        enemyAnim.SetBool("down", true);
        isMoviment = false;
        colliderHeadEnemy.enabled = false;
        colliderBodyEnemy.enabled = false;
    }


    private void FixedUpdate()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        if (isMoviment)
        {
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
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(posStart.position, posEnd.position);
    }

}
