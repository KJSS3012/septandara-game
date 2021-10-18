using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Basic Components")]
    [SerializeField] private float speedMove = 2.5f;
    [SerializeField] private float jumpForce = 280;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private bool isWalk;
    public bool isActiveMoviment;

    [Header("Collider CheckGround")]
    public bool isGround;
    public CircleCollider2D footCollider;

    [Header("Collider CheckWall and CheckColliderBody")]
    [SerializeField] private bool isTouchingWall;
    [SerializeField] private bool isColliderEnemy;
    public BoxCollider2D bodyCollider;
    public LayerMask enemyLayer;

    private Rigidbody2D rig2D;
    private Animator animPlayer;
    public SpriteRenderer spritePlayer;
    public PlayerInput playerInput;

    void Start()
    {
        rig2D = GetComponent<Rigidbody2D>();
        animPlayer = GetComponent<Animator>();
        spritePlayer = GetComponent<SpriteRenderer>();
        playerInput = GetComponent<PlayerInput>();
        bodyCollider = GetComponent<BoxCollider2D>();
        isActiveMoviment = true;
    }

    void FixedUpdate()
    {
        if (isActiveMoviment)
        {
            CheckGround();
            MovePlayer();
            JumpPlayer();
            CheckWall();
            CheckEnemy();
        }
    }

    private void MovePlayer()
    {
        Vector3 movement = playerInput.GetMovimentInput();

        transform.position += movement * Time.fixedDeltaTime * speedMove;

        if (movement.x > 0f)
        {
            animPlayer.SetBool("walk", true);
            spritePlayer.flipX = false;
            isWalk = true;
        }
        else if (movement.x == 0f)
        {
            animPlayer.SetBool("walk", false);
            isWalk = false;
        }
        else if (movement.x < 0f)
        {
            animPlayer.SetBool("walk", true);
            spritePlayer.flipX = true;
            isWalk = true;
        }
    }

    private void JumpPlayer()
    {
        if (isTouchingWall && isWalk)
        {
            speedMove = 0;
        }
        else
        {
            speedMove = 2.5f;
        }

        if (playerInput.IsJumpButtonInterface() || playerInput.IsJumpKeyboard())
        {
            if (isGround)
            {
                rig2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                animPlayer.SetBool("jump", true);
            }
        }
    }

    private void CheckGround()
    {
        isGround = footCollider.IsTouchingLayers(groundLayer);
        if (isGround)
        {
            animPlayer.SetBool("jump", false);
        }
    }

    private void CheckWall()
    {
        isTouchingWall = bodyCollider.IsTouchingLayers(groundLayer);
    }

    private void CheckEnemy()
    {
        isColliderEnemy = bodyCollider.IsTouchingLayers(enemyLayer);
        if (isColliderEnemy)
        {
            //animPlayer.SetBool("hit", true);
            //Vector2 force = new Vector2(-jumpForce*10, 0);
            //rig2D.AddForce(force);
            //bodyCollider.enabled = false;
            //GameController.instance.SubtractLife(10);

            

            //Debug.Log(force);
        }
    }

    //Colisão com componentes/objetos do game
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("PlataformFloating"))
        {
            transform.parent = other.gameObject.transform;
        }
        else
        {
            transform.parent = null;
        }
    }

    //Reiniciar controles da personagem quando ela for desativada
    public void RestartControls(bool value)
    {
        isActiveMoviment = value;
        if (!isActiveMoviment)
        {
            playerInput.MoveLeftFalse();
            playerInput.MoveRightFalse();

            animPlayer.SetBool("walk", false);
            animPlayer.SetBool("jump", false);

            playerInput.enabled = value;
        }
    }
}
