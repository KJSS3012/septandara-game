using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColiderWithElements : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col){
        // destroi a bala disparada no ataque 
        if(col.gameObject.CompareTag("Bullet")){
            Destroy(col.gameObject);
        }
    }
}
