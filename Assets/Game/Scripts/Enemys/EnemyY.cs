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

    [Header("Enemy Y Life")]
    public int life;

    [SerializeField] private SpriteRenderer enemySprite;
    [SerializeField] private GameObject playerObject;
    [SerializeField] private Player player;
    [SerializeField] private BoxCollider2D colliderDetect;

    // Start is called before the first frame update
    void Start()
    {
        // posição dele apos o Start
        nextPosition = posStart.position;
        // sprite do inimigo
        enemySprite = GetComponent<SpriteRenderer>();
        // box collider para detectar a colisao
        colliderDetect = GetComponent<BoxCollider2D>();
        playerObject = GameObject.FindGameObjectWithTag("Player");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        colliderDetect.enabled = true;
        // define a vida do inimigo como 3
        life = 3;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        MoveEnemy();
        DetectPlayer();
        ToDie();
    }

    // move o  inimigo de um lugar para outro e retorna a posição inicial
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
            // subtrai da vida do player
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
