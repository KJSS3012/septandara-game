using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    private float lengthBackground;
    private float startPosition;
    private Transform cam;
    public float speedParallaxEffect;

    void Start()
    {
        startPosition = transform.position.x;
        lengthBackground = GetComponent<SpriteRenderer>().bounds.size.x;
        cam = Camera.main.transform;
    }

    void Update()
    {
        float rePosition = cam.transform.position.x * (1 - speedParallaxEffect);
        float distance = cam.transform.position.x * speedParallaxEffect;
        transform.position = new Vector3(startPosition + distance, transform.position.y, transform.position.z);

        if(rePosition > startPosition+lengthBackground){
            startPosition += lengthBackground;
        }else if(rePosition < startPosition-lengthBackground){
            startPosition -= lengthBackground;
        }
    }

}
