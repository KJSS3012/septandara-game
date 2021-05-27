using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Physics2D))]

public class Player : MonoBehaviour
{

    [SerializeField] private float speed = 2.5f;
    [SerializeField] private float jumpForce = 280;

    [SerializeField] private bool isGround;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float radious;
    [SerializeField] private Transform groundCheckCollider;
    

    private bool isJumping;
    private Rigidbody2D rig2D;
    private Animator animPlayer;
    private SpriteRenderer spritePlayer;
    private PlayerInput playerInput;

    void Start()
    {
        rig2D = GetComponent<Rigidbody2D>();
        animPlayer = GetComponent<Animator>();
        spritePlayer = GetComponent<SpriteRenderer>();
        playerInput = GetComponent<PlayerInput>();
    }

    void FixedUpdate()
    {

        //Movimentação Horizontal

        Vector3 movement = playerInput.GetMovimentInput();

        transform.position += movement * Time.fixedDeltaTime * speed;
        
        if (movement.x > 0f)
        {
            animPlayer.SetBool("walk", true);
            spritePlayer.flipX = false;
        }
        else if (movement.x == 0f)
        {
            animPlayer.SetBool("walk", false);
        }
        else if (movement.x < 0f)
        {
            animPlayer.SetBool("walk", true);
            spritePlayer.flipX = true;
        }

        //Pulo

        CheckGround();

        if (playerInput.IsJump())
        {
            if(!isJumping && isGround)
            {
                rig2D.AddForce(new Vector2(0f, jumpForce * Time.fixedDeltaTime), ForceMode2D.Impulse);
                animPlayer.SetBool("jump", true);
            }
            else
            {
                //Double Jump or Fly
            }
        }

        

    }

    private void CheckGround()
    {
        Collider2D collider = Physics2D.OverlapCircle(groundCheckCollider.position, radious, groundLayer);
        Debug.Log(collider);
        if (collider != null)
        {
            isGround = true;
            isJumping = false;
            animPlayer.SetBool("jump", false);
        }
        else
        {
            isGround = false;
            isJumping = true;
        }

    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(groundCheckCollider.position, radious);
    }

}
