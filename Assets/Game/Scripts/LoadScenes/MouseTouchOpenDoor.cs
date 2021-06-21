using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MouseTouchOpenDoor : MonoBehaviour
{

    public GameObject fadeUI;
    public Animator animFade;
    [SerializeField] private Animator animObject;
    public int sceneIndex;
    public bool isMouseDown;
    public bool isCollider;
    public Player player;
    public Animator animPlayer;


    private void OnMouseDown()
    {
        isMouseDown = true;
    }

    private void OnMouseExit()
    {
        isMouseDown = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isCollider = true;   
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isCollider = false;
        }
    }

    private void Update()
    {
        if (isMouseDown && isCollider)
        {
            animObject.SetBool("open", true);
        }
    }

    public void StartTransition()
    {
        if (player.isGround)
        {
            fadeUI.SetActive(true);
            animFade.SetTrigger("out");
            animPlayer.SetBool("entry", true);
        }
        
    }

  
}
