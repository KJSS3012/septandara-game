using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookNarrative : MonoBehaviour
{

    public GameObject bookNarrativeUI;
    public VisibilityControls vsControls;
    public GameObject altarObject;
    public bool isMouseDown;
    public bool isCollider;
    public bool isKeyDownS;
    public Player player;
    public CapsuleCollider2D colliderCapsule;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        vsControls = GameObject.FindGameObjectWithTag("Controls").GetComponent<VisibilityControls>();
        colliderCapsule = GetComponent<CapsuleCollider2D>();
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

    private void OnKeyCodeS()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            isKeyDownS = true;
        }
        else
        {
            isKeyDownS = false;
        }
    }

    private void Update()
    {
        OnKeyCodeS();
        if ((isMouseDown || isKeyDownS) && (isCollider && player.isGround))
        {
            altarObject.GetComponent<Animator>().SetBool("open", true);
;        }
    }

}
