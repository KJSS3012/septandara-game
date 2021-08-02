using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MouseTouchLoadScene : MonoBehaviour
{

    public GameObject fadeUI;
    public Animator animFade;
    [SerializeField] private Animator animObject;
    public bool isMouseDown;
    public bool isCollider;
    public Player player;
    public Animator animPlayer;
    public GameObject controlsUI;
    [SerializeField] private ObjectActivator objAct;

    private void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
        animPlayer = player.GetComponent<Animator>();
        controlsUI = GameObject.FindGameObjectWithTag("Controls");
        objAct = GetComponentInParent<ObjectActivator>();
        animObject = objAct.GetComponent<Animator>();
    }

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
        isCollider = true;   
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isCollider = false;
    }

    private void Update()
    {
        if (isMouseDown && isCollider && player.isGround)
        {
            animObject.SetTrigger("open");
            player.RestartControls(false);
            controlsUI.SetActive(false);
            objAct.Active();
        }
    }

    

}
