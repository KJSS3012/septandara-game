using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    public bool isJumping;
    private Rigidbody2D rig2D;
    private Animator animPlayer;

    void Start(){
        rig2D = GetComponent<Rigidbody2D>();
        animPlayer = GetComponent<Animator>();
    }

    void Update(){
        Move();
        Jump();
    }

    //Movimentação horizontal
    void Move(){
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * speed;
        if(Input.GetAxis("Horizontal")>0f){
            animPlayer.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }else if(Input.GetAxis("Horizontal")==0f){
            animPlayer.SetBool("walk", false);
        }else if(Input.GetAxis("Horizontal")<0f){
            animPlayer.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
    }

    void Jump(){
        if(Input.GetButtonDown("Jump")){
            if(!isJumping){
                rig2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                animPlayer.SetBool("jump", true);
            }else{
                //Double Jump
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.layer == 6){
            isJumping = false;
            animPlayer.SetBool("jump", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if(collision.gameObject.layer == 6){
            isJumping = true;
        }
    }


}
