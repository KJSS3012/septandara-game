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
    [SerializeField] private BoxCollider2D colliderDetect;
    [SerializeField] private GameObject playerObject;
    [SerializeField] private Player player;
    public LayerMask footLayerPlayer;
    public LayerMask playerLayer;
    public float forceReturnDown;
    [SerializeField] private bool isAttack;

    private void Start()
    {
        nextPosition = posStart.position;
        colliderHeadEnemy = GetComponent<CircleCollider2D>();
        colliderBodyEnemy = GetComponent<CapsuleCollider2D>();
        colliderDetect = GetComponent<BoxCollider2D>();
        enemySprite = GetComponent<SpriteRenderer>();
        enemyAnim = GetComponent<Animator>();
        enemyAnim.SetBool("cursed", true);
        isMoviment = true;
        isAttack = false;
        playerObject = GameObject.FindGameObjectWithTag("Player");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void FixedUpdate()
    {
        MoveEnemy();
        DownEnemy();
        DetectPlayer();
    }

    private void MoveEnemy()
    {
        if (isMoviment)
        {
            if (transform.position == posStart.position && !isAttack)
            {
                enemySprite.flipX = true;
                nextPosition = posEnd.position;
            }
            if (transform.position == posEnd.position && !isAttack)
            {
                enemySprite.flipX = false;
                nextPosition = posStart.position;
            }

            transform.position = Vector3.MoveTowards(transform.position, nextPosition, speedEnemy * Time.fixedDeltaTime);
        }
    }

    public void DownEnemy()
    {
        if (colliderHeadEnemy.IsTouchingLayers(footLayerPlayer))
        {
            enemyAnim.SetBool("cursed", false);
            enemyAnim.SetBool("down", true);
            isMoviment = false;
            colliderHeadEnemy.enabled = false;
            colliderBodyEnemy.enabled = false;
            colliderDetect.enabled = false;
            playerObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, forceReturnDown), ForceMode2D.Impulse);
            StartCoroutine(DelayStandUp());
        }
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
        enemyAnim.SetBool("attack", false);
        isMoviment = true;
        colliderHeadEnemy.enabled = true;
        colliderBodyEnemy.enabled = true;
        colliderDetect.enabled = true;
        StartCoroutine(DelayProxAttack());
    }

    public void DetectPlayer()
    {
        if (colliderDetect.IsTouchingLayers(playerLayer) && !isAttack)
        {
            isMoviment = false;
            enemyAnim.SetBool("attack", true);
            isAttack = true;
            player.animPlayer.SetBool("hit", true);
            player.bodyCollider.enabled = false;
            GameController.instance.SubtractLife(10);
            if (playerObject.GetComponent<SpriteRenderer>().flipX)
            {
                enemySprite.flipX = true;
                nextPosition = posEnd.position;
                playerObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(forceReturnDown/4, forceReturnDown/2), ForceMode2D.Impulse);
            }
            else
            {
                enemySprite.flipX = false;
                nextPosition = posStart.position;
                playerObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-forceReturnDown/4, forceReturnDown/2), ForceMode2D.Impulse);
            }
        }
    }

    IEnumerator DelayProxAttack()
    {
        yield return new WaitForSeconds(0.5f);
        isAttack = false;
    }

}
