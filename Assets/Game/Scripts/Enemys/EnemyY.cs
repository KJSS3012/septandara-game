using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyY : MonoBehaviour
{
    public float speedEnemy;
    private Vector3 nextPosition;
    public Transform posStart, posEnd;
    public LayerMask playerLayer;
    public float forceReturnDown;

    [SerializeField] private SpriteRenderer enemySprite;
    [SerializeField] private GameObject playerObject;
    [SerializeField] private Player player;
    [SerializeField] private BoxCollider2D colliderDetect;

    // Start is called before the first frame update
    void Start()
    {
        nextPosition = posStart.position;
        enemySprite = GetComponent<SpriteRenderer>();
        colliderDetect = GetComponent<BoxCollider2D>();
        playerObject = GameObject.FindGameObjectWithTag("Player");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        colliderDetect.enabled = true;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        MoveEnemy();
        DetectPlayer();
    }

    private void MoveEnemy()
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

    public void DetectPlayer()
    {
        if (colliderDetect.IsTouchingLayers(playerLayer))
        {
            GameController.instance.SubtractLife(10);
            DisableCollider();
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
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(posStart.position, posEnd.position);
    }

    public void DisableCollider()
    {
        colliderDetect.enabled = false;
        StartCoroutine(ColliderActive());
    }

    IEnumerator ColliderActive()
    {
        yield return new WaitForSeconds(2f);
        colliderDetect.enabled = true;
    }
}
