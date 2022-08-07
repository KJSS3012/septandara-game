using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject playerObject;
    public Collider2D box2d;
    private Animator animTrap;
    private Detect detect;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerObject = GameObject.FindGameObjectWithTag("Player");
        animTrap = GetComponent<Animator>();
        detect = GameObject.FindGameObjectWithTag("Detect").GetComponent<Detect>();
    }
    private void Update()
    {
        DetectPlayer(box2d);
    }
    private void DetectPlayer(Collider2D collider2D)
    {
        if (detect.isDetect)
        {
            StartCoroutine(ActivateAnim());
            OnTriggerStay2D(collider2D);
        }
    }
    IEnumerator ActivateAnim()
    {
        yield return new WaitForSeconds(0);
        animTrap.SetBool("Start", false);
        animTrap.SetBool("Activate", true);
        StartCoroutine(DesactiveAnim());
    }
    IEnumerator DesactiveAnim()
    {
        yield return new WaitForSeconds(1f);
        detect.isDetect = false;
        animTrap.SetBool("Desactivate", true);
        animTrap.SetBool("Activate", false);
        StartCoroutine(StartAnim());
    }

    IEnumerator StartAnim()
    {
        yield return new WaitForSeconds(0.5f);
        animTrap.SetBool("Desactivate", false);
        animTrap.SetBool("Start", true);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (playerObject.GetComponent<SpriteRenderer>().flipX)
            {
                playerObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(3 / 4, 3 / 2), ForceMode2D.Impulse);
                player.animPlayer.SetBool("hit", true);
            }
            else
            {
                playerObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-3 / 4, 3 / 2), ForceMode2D.Impulse);
                player.animPlayer.SetBool("hit", true);
            }
        }
    }
}
