using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX : MonoBehaviour
{
    public float speedEnemy;
    private Vector3 nextPosition;
    public Transform posStart, posEnd;
    public LayerMask playerLayer;
    public float forceReturnDown;
    private bool isDetect;
    [SerializeField] private SpriteRenderer enemySprite;
    [SerializeField] private Animator enemyAnim;
    [SerializeField] private GameObject playerObject;
    [SerializeField] private Player player;
    [SerializeField] private BoxCollider2D colliderDetect, playerDetect;

    // Start is called before the first frame update
    void Start()
    {
        nextPosition = posStart.position;
        enemySprite = GetComponent<SpriteRenderer>();
        colliderDetect = GetComponent<BoxCollider2D>();
        playerDetect = GetComponent<BoxCollider2D>();
        playerObject = GameObject.FindGameObjectWithTag("Player");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        colliderDetect.enabled = true;
        enemyAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        MoveEnemy();
        DetectPlayer();
    }

    private void MoveEnemy()
    {
        if (isDetect)
        {
            StartCoroutine(DelayAnimationStart());
            while (isDetect)
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
        else
        {
            StartCoroutine(DelayAnimationEnd());
        }

    }

    public void DetectPlayer()
    {
        if (colliderDetect.IsTouchingLayers(playerLayer))
        {
            player.DisableBodyCollider();
            DisableBodyCollider();
            GameController.instance.SubtractLife(10);
            if (playerObject.GetComponent<SpriteRenderer>().flipX)
            {
                playerObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(forceReturnDown / 4, forceReturnDown / 2), ForceMode2D.Impulse);
            }
            else
            {
                playerObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-forceReturnDown / 4, forceReturnDown / 2), ForceMode2D.Impulse);
            }
        }
    }

    IEnumerator DelayActiveCollider()
    {
        yield return new WaitForSeconds(2f);
        colliderDetect.enabled = true;
    }

    IEnumerator DelayAnimationStart()
    {
        yield return new WaitForSeconds(1.5f);
        enemyAnim.SetBool("preattack", true);
        yield return new WaitForSeconds(1.5f);
        enemyAnim.SetBool("preattack", false);
        enemyAnim.SetBool("attack", true);
    }

    IEnumerator DelayAnimationEnd()
    {
        yield return new WaitForSeconds(1.5f);
        enemyAnim.SetBool("outattack", true);
        yield return new WaitForSeconds(1.5f);
        enemyAnim.SetBool("outattack", false);
    }
    public void DisableBodyCollider()
    {
        colliderDetect.enabled = false;
        StartCoroutine(DelayActiveCollider());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (playerDetect.gameObject.tag == "Player")
        {
            isDetect = true;
        }
        else
        {
            isDetect = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(posStart.position, posEnd.position);
    }
}
