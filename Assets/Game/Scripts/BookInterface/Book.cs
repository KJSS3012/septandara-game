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
    public ButtonCard[] buttonsCard;
    public static Book instance;
    public GameObject bookInterfaceUI;
    public VisibilityControls vsControls;
    private Player player;
    private bool isActiveBook;

    private void Start()
    {
        instance = this;
        sceneActive = SceneManager.GetActiveScene().buildIndex;
        vsControls = GameObject.FindGameObjectWithTag("Controls").GetComponent<VisibilityControls>();
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        UnlockedFase();
        
        if (Input.GetKeyDown(KeyCode.C))
        {
            OpenBook();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            CloseBook();
        }
    }

    private void UnlockedFase()
    {
        buttonsFase = FindObjectsOfType<ButtonFase>();
        for (int i = 0; i<buttonsFase.Length; i++)
        {
            buttonsFase[i].GetButtonBook();
            if (buttonsFase[i].buttonBook.number-1 == sceneActive)
            {
                buttonsFase[i].buttonBook.UnlockedButton();
                world.fasesUnlocked[buttonsFase[i].buttonBook.number - 1] = false;
                break;
            }
        }
    }

    public void OpenBook()
    {
        if (player.isActiveMoviment)
        {
            isActiveBook = true;
            bookInterfaceUI.SetActive(true);
            vsControls.OpacityControls(0.5f, false);
        }
    }

    public void CloseBook()
    {
        if (isActiveBook)
        {
            bookInterfaceUI.SetActive(false);
            vsControls.OpacityControls(1f, true);
            isActiveBook = false;
        }
    }

}
