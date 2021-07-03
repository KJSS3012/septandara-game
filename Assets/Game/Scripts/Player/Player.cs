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
    [SerializeField] private bool isActiveMoviment;

    [Header("Collider CheckGround")]
    public bool isGround;
    [SerializeField] private float radious;
    [SerializeField] private Transform groundCheckCollider;

    [Header("Collider CheckWall")]
    [SerializeField] private Transform wallCheckCollider;
    [SerializeField] private float wallDistance;
    [SerializeField] private bool isTouchingWall;

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
        isActiveMoviment = true;
    }

    void FixedUpdate()
    {
        if (isActiveMoviment)
        {
            MovePlayer();
            JumpPlayer();
            CheckWall();
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
        CheckGround();

        if (isTouchingWall && isWalk)
        {
            speedMove = 0;
        }
        else
        {
            speedMove = 2.5f;
        }

        if (playerInput.IsJump())
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
        isGround = Physics2D.OverlapCircle(groundCheckCollider.position, radious, groundLayer);
        if (isGround)
        {
            animPlayer.SetBool("jump", false);
            Debug.Log("eiiiiiiiiiiiiiiiiiii");
        }
    }

    private void CheckWall()
    {
        isTouchingWall = Physics2D.OverlapBox(wallCheckCollider.position, new Vector3(wallDistance / 2, wallDistance, 0), wallDistance, groundLayer);
    }

    //Colisão com componentes/objetos do game
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("PlataformFloating"))
        {
            Debug.Log("oiiiiiiiiiiiiiii");
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
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(groundCheckCollider.position, radious);
        Gizmos.DrawWireCube(wallCheckCollider.position, new Vector3(wallDistance / 2, wallDistance, 0));
    }

}
