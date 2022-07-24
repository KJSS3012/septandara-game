using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCutScene : MonoBehaviour
{
    public Transform targetCamera;
    public CameraFollow cameraObj;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cameraObj.target = targetCamera;
            FindObjectOfType<Prince>().isAttack = true;
        }
    }


}
