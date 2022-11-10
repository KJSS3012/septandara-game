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
    private AudioSource sound;

    [Header("Collider CheckGround")]
    public bool isGround;
    public CircleCollider2D footCollider;

    [Header("Collider CheckWall and CheckColliderBody")]
    [SerializeField] private bool isTouchingWall;
    public BoxCollider2D bodyCollider;
    private Rigidbody2D rig2D;
    public Animator animPlayer;
    public SpriteRenderer spritePlayer;
    public PlayerInput playerInput;
    public Vector3 respawnPoint;

    [Header("Elements for Slingshot")]
    public bool isGetSlingShot = false;
    private float side = 1f;
    public Transform bullet;
    public Transform pivot;
    public GameObject Slingshot;

    void Start()
    {
        rig2D = GetComponent<Rigidbody2D>();
        animPlayer = GetComponent<Animator>();
        spritePlayer = GetComponent<SpriteRenderer>();
        playerInput = GetComponent<PlayerInput>();
        bodyCollider = GetComponent<BoxCollider2D>();
        isActiveMoviment = true;
        respawnPoint = transform.position;
        sound = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (isGetSlingShot)
        {
            SlingshotShoot();
        }
    }

    void FixedUpdate()
    {
        if (isActiveMoviment)
        {
            CheckGround();
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
            side = 1;
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
            side = -1;
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

    //Colis�o com componentes/objetos do game
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
        if (other.gameObject.tag == "GameOver")
        {
            transform.position = respawnPoint;
            GameController.instance.SubtractLife(30);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "CheckPoint")
        {
            if (transform.position.x > respawnPoint.x)
            {
                respawnPoint = transform.position;
            }
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

    //Slingshot schemes for shooting
    private void SlingshotShoot()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Slingshot.transform.right = Vector2.right * side;
            Slingshot.GetComponent<Transform>().position = new Vector3(Slingshot.GetComponent<Transform>().position.x, Slingshot.GetComponent<Transform>().position.y, 0);
            animPlayer.SetBool("fire", true);
            isGetSlingShot = false;
            StartCoroutine(DelayFireSlingshot());
        }
    }

    IEnumerator DelayFireSlingshot()
    {
        yield return new WaitForSeconds(0.3f);
        Instantiate(bullet, pivot.position, pivot.transform.rotation);
        isActiveMoviment = true;
        animPlayer.SetBool("fire", false);
        isGetSlingShot = true;
    }

    public void DisableMoviment()
    {
        isActiveMoviment = false;
        animPlayer.SetBool("walk", false);
    }

    public void EnableMoviment()
    {
        isActiveMoviment = true;
    }
}
