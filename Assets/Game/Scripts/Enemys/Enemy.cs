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
    [SerializeField] private GameObject playerObject;
    [SerializeField] private Player player;
    public LayerMask footLayerPlayer;
    public float forceReturnDown;

    private void Start()
    {
        nextPosition = posStart.position;
        colliderHeadEnemy = GetComponent<CircleCollider2D>();
        colliderBodyEnemy = GetComponent<CapsuleCollider2D>();
        enemySprite = GetComponent<SpriteRenderer>();
        enemyAnim = GetComponent<Animator>();
        enemyAnim.SetBool("cursed", true);
        isMoviment = true;
        playerObject = GameObject.FindGameObjectWithTag("Player");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        isMoviment = true;
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
        if (colliderHeadEnemy.IsTouchingLayers(footLayerPlayer) && isMoviment)
        {
            DownEnemy();
        }
    }

    public void DownEnemy()
    {
        enemyAnim.SetBool("cursed", false);
        enemyAnim.SetBool("down", true);
        isMoviment = false;
        colliderHeadEnemy.enabled = false;
        colliderBodyEnemy.enabled = false;
        playerObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, forceReturnDown), ForceMode2D.Impulse);
        StartCoroutine(DelayStandUp());
    }

    IEnumerator DelayStandUp()
    {
        yield return new WaitForSeconds(3f);
        StandUp();
    }

    public void StandUp()
    {
        enemyAnim.SetBool("down", false);
    }

    public void MovimentCursed()
    {
        enemyAnim.SetBool("cursed", true);
        isMoviment = true;
        colliderHeadEnemy.enabled = true;
        colliderBodyEnemy.enabled = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(posStart.position, posEnd.position);
    }

}
