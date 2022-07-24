using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lupe : MonoBehaviour
{

    [Header("Components")]
    public GameObject pictureUI;
    protected bool isCollider;
    protected bool isClick;
    public VisibilityControls vsControls;
    public CircleCollider2D colliderLupe;

    private void Start()
    {
        vsControls = GameObject.FindGameObjectWithTag("Controls").GetComponent<VisibilityControls>();
        colliderLupe = this.GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isCollider = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isCollider = false;
    }

    private void OnMouseDown()
    {
        isClick = true;
    }

    private void OnMouseExit()
    {
        isClick = false;
    }

    private void Update()
    {
        Activate();
    }

    private void Activate()
    {
        if (isCollider && (isClick || Input.GetKeyDown(KeyCode.S)))
        {
            vsControls.OpacityControls(0.5f, false);
            pictureUI.SetActive(true);
            colliderLupe.enabled = false;
        }
    }
}
