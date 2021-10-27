using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingMath : MonoBehaviour
{

    public ParticleSystem partSystem;
    private Animator animKingMath;

    private void Start()
    {
        animKingMath = GetComponent<Animator>();
    }

    private void OnParticleCollision(GameObject other)
    {
        animKingMath.SetTrigger("disappear");
    }

}
