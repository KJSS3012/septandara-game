using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject playerObject;
    private Animator playerAnim;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (playerObject.GetComponent<SpriteRenderer>().flipX)
            {
                playerObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(5 / 4, 3 / 2), ForceMode2D.Impulse);
                player.animPlayer.SetBool("hit", true);
            }
            else
            {
                playerObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-5 / 4, 3 / 2), ForceMode2D.Impulse);
                player.animPlayer.SetBool("hit", true);
            }
        }
    }
}
