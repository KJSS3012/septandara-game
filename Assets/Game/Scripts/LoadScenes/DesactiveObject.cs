using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactiveObject : MonoBehaviour
{
    private GameObject objectComponent;

    public void Desactive()
    {
        objectComponent = this.gameObject;
        objectComponent.SetActive(false);
    }
}
