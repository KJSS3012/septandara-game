using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public int speedBuleet;
    public Animator bulletAnimator;

    // Start is called before the first frame update
    void Start()
    {
        bulletAnimator = GetComponent<Animator>();
        GetComponent<Rigidbody2D>().AddForce(transform.right * speedBuleet);
        Destroy(gameObject, 2);
    }
    
    
}
