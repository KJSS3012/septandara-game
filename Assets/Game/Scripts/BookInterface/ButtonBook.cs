using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBook : MonoBehaviour
{

    public bool IsLock;
    public int number;
    public GameObject childLock;
    public GameObject childImage;

    void Start()
    {
        IsLock = true;
        childLock = GameObject.FindGameObjectWithTag("Lock");
        childImage = GameObject.FindGameObjectWithTag("Image");
        Debug.Log(childLock + "---------------" + childImage);
    }


}
