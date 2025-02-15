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
    [SerializeField] private Detect detect;
    private bool isStart;

    [Header("Enemy X Life")]
    public int life;

    [SerializeField] private SpriteRenderer enemySprite;
    [SerializeField] private Animator enemyAnim;
    [SerializeField] private GameObject playerObject;
    [SerializeField] private Player player;
    [SerializeField] private CircleCollider2D colliderDetect;
    // Start is called before the first frame update
    void Start()
    {
        nextPosition = posStart.position;
        enemySprite = GetComponent<SpriteRenderer>();
        colliderDetect = GetComponent<CircleCollider2D>();
        playerObject = GameObject.FindGameObjectWithTag("Player");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        enemyAnim = GetComponent<Animator>();
        isStart = false;
        life = 3;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        MoveEnemy();
        DetectPlayer();
        ToDie();
    }

    public void DetectPlayer()
    {
        if (colliderDetect.IsTouchingLayers(playerLayer))
        {
            GameController.instance.SubtractLife(10);
            DisableCollider();
            if (playerObject.GetComponent<SpriteRenderer>().flipX)
            {
                DisableCollider();
                playerObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(forceReturnDown / 4, forceReturnDown / 2), ForceMode2D.Impulse);
            }
            else
            {
                DisableCollider();
                playerObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-forceReturnDown / 4, forceReturnDown / 2), ForceMode2D.Impulse);
            }
        }
    }

    private void MoveEnemy()
    {
        if (detect.isDetect)
        {
            StartCoroutine(DelayAnimationStart());
            if (isStart)
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
            StartCoroutine(DelayAnimationRollingExit());
        }
    }
    IEnumerator DelayAnimationStart()
    {
        enemyAnim.SetBool("Idle", false);
        enemyAnim.SetBool("Attack", true);
        yield return new WaitForSeconds(0.8f);
        isStart = true;
        StartCoroutine(DelayAnimationRolling());
    }
    IEnumerator DelayAnimationRolling()
    {
        yield return new WaitForSeconds(0);
        enemyAnim.SetBool("Attack", false);
        enemyAnim.SetBool("Rolling", true);
        if (!detect.isDetect)
        {
            StartCoroutine(DelayAnimationRollingExit());
        }
    }

    IEnumerator DelayAnimationRollingExit()
    {
        enemyAnim.SetBool("Rolling", false);
        enemyAnim.SetBool("RollingExit", true);
        yield return new WaitForSeconds(0.3f);
        StartCoroutine(DelayAnimationIdle());
    }

    IEnumerator DelayAnimationIdle()
    {
        yield return new WaitForSeconds(0);
        enemyAnim.SetBool("RollingExit", false);
        enemyAnim.SetBool("Idle", true);
        isStart = false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(posStart.position, posEnd.position);
    }

    public void DisableCollider()
    {
        // caso o colidor seja dectectado, o eneblad se torna falso
        // e a courotina vai ser ativada
        colliderDetect.enabled = false;
        StartCoroutine(ColliderActive());
    }

    IEnumerator ColliderActive()
    {
        yield return new WaitForSeconds(2f);
        colliderDetect.enabled = true;
    }
    private void OnTriggerEnter2D(Collider2D col){
        // decrescenta uma "vida" do inimigo ao ser atingido
        if (col.gameObject.tag == "Bullet"){
            life = life - 1;
            
        }
    }

    private void ToDie(){
        // destroi o inimigo quando a vida for igual ou menor que 0
        if(life<=0){
            Destroy(gameObject);
        }
    }
}
