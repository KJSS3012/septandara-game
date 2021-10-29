using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    private Animator animNPC;

    private void Start()
    {
        animNPC = GetComponent<Animator>();
    }

    private void OnParticleCollision(GameObject other)
    {
        animNPC.SetTrigger("disappear");
    }

    public void DestroyNPC()
    {
        Destroy(this);
    }
}
