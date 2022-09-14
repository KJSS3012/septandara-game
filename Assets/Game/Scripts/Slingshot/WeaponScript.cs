using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
   
    int side = 1;
    public Transform bullet;
    public Transform pivot;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X)){
            side = 1;
        }
        if(Input.GetKeyDown(KeyCode.Z)){
            side = -1;
        }

        transform.right = Vector2.right * side;

        if(Input.GetKeyDown(KeyCode.C))
        {
            Instantiate(bullet, pivot.position, transform.rotation);
        }

    }

    void start(){

    }

}
