using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{

    public float speed;
    private Animator animSheep;

    void Start(){
        animSheep = GetComponent<Animator>();
    }

    void Update(){
        
    }

    void Move(){
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * speed;
        
    }

}
