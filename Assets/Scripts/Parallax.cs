using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    private float lengthBackground;
    private float startPosition;
    private Transform cam;
    public float ParallaxEffect;

    void Start(){
        startPosition = transform.position.x;
        lengthBackground = GetComponent<SpriteRenderer>().bounds.size.x;
        cam = Camera.main.transform;
    }

    void Update(){
        float rePosition = cam.transform.position.x * (1 - ParallaxEffect);
        float Distance = cam.transform.position.x * ParallaxEffect;
        transform.position = new Vector3(startPosition + Distance, transform.position.y, transform.position.z);

        if(rePosition > startPosition+lengthBackground/2){
            startPosition += lengthBackground;
        }else if(rePosition < startPosition-lengthBackground/2){
            startPosition -= lengthBackground;
        }
    }

}
