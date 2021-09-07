using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Book : MonoBehaviour
{
    public WorldMath world;
    public int sceneActive;
    public ButtonFase[] buttonsFase;
    public static Book instance;
    public GameObject bookInterfaceUI;
    public VisibilityControls vsControls;


    private void Start()
    {
        instance = this;
        sceneActive = SceneManager.GetActiveScene().buildIndex;
        vsControls = GameObject.FindGameObjectWithTag("Controls").GetComponent<VisibilityControls>();
    }

    private void Update()
    {
        
    }

    public void OpenBook()
    {
        bookInterfaceUI.SetActive(true);
        buttonsFase[sceneActive].UnlockedButtonFase();
        vsControls.OpacityControls(0.5f, false);
    }

    public void CloseBook()
    {
        bookInterfaceUI.SetActive(false);
        vsControls.OpacityControls(1f, true);
    }

}
