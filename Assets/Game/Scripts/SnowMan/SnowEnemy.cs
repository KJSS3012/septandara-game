using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowEnemy : MonoBehaviour
{
    
    [Header("SnowEnemy")]
    private bool isAlive = false;
    public int life;
    private int timeForShooting;
    private float distanceForActivate;
    public Transform bullet;
    public Transform pivot;
    private Transform player;
    private float side = 1f;

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player").transform;
        isAlive = true;
        life = 5;
        timeForShooting = 3;
        distanceForActivate = 6f;
    }

    void Update(){
        if(isAlive){
            //Distancia da colisao para ativar o metodo shooting, que disparara na player
        }
    }

    void FixedUpdate(){
        
    }

    private void shooting(){
        Debug.Log(Vector2.Distance(transform.position, player.position));
    }

    private void isDead(){

    }


}
