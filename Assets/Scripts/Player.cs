using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PlayerInput))]

public class Player : MonoBehaviour
{

    private float speed = 2.5f;
    private float jumpForce = 5f;
    private bool isJumping;
    private Rigidbody2D rig2D;
    private Animator animPlayer;
    private SpriteRenderer spritePlayer;
    private PlayerInput playerInput;
    public float test;

    void Start()
    {
        rig2D = GetComponent<Rigidbody2D>();
        animPlayer = GetComponent<Animator>();
        spritePlayer = GetComponent<SpriteRenderer>();
        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {

        //Movimentação Horizontal

        Vector3 movement = playerInput.GetMovimentInput();

        transform.position += movement * Time.deltaTime * speed;
        
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

        if (playerInput.IsJump())
        {
            test = 1f;

            if (!isJumping)
            {
                rig2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                animPlayer.SetBool("jump", true);
            }
            else
            {
                //Double Jump or Fly
            }
        }
        else
        {
            test = 0f;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6){
            isJumping = false;
            animPlayer.SetBool("jump", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6){
            isJumping = true;
        }
    }


}
