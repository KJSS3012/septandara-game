using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public int speedBuleet;
    private Animator bulletAnimator;

    // Start is called before the first frame update
    void Start()
    {
        bulletAnimator = GetComponent<Animator>();
        GetComponent<Rigidbody2D>().AddForce(transform.right * speedBuleet * speedBuleet);
        Destroy(gameObject, 2f);
    }

    void animationsDestroy()
    {
        bulletAnimator.SetBool("destruct", true);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            StartCoroutine(DelayFireSlingshot());
        }
    }

    IEnumerator DelayFireSlingshot()
    {
        animationsDestroy();
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }


}
