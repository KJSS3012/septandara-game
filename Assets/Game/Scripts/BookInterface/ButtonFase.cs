using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFase : MonoBehaviour
{

    public ButtonBook buttonBook;

    private void Start()
    {
        buttonBook = GetComponent<ButtonBook>();
        SetUpButton();
    }

    public void SetUpButton()
    {
        if (buttonBook.number <= Book.instance.world.fasesUnlocked.Length)
        {
            bool IsLocked = Book.instance.world.fasesUnlocked[buttonBook.number - 1];
            if (!IsLocked && buttonBook.number == Book.instance.world.scenesFases[buttonBook.number - 1])
            {
                UnlockedButtonFase();
            }
            else if(IsLocked && buttonBook.number == Book.instance.world.scenesFases[buttonBook.number - 1])
            {
                LockedButtonFase();
            }
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    public void UnlockedButtonFase()
    {
        buttonBook = GetComponent<ButtonBook>();
        buttonBook.childLock.gameObject.SetActive(false); //quando for lock true, lembrar de colocar uma trava pra impedir de clicar no butão
        buttonBook.childImage.gameObject.SetActive(true);
        Book.instance.world.fasesUnlocked[buttonBook.number - 1] = false;
    }

    public void LockedButtonFase()
    {
        buttonBook.childLock.gameObject.SetActive(true); //quando for lock true, lembrar de colocar uma trava pra impedir de clicar no butão
        buttonBook.childImage.gameObject.SetActive(false);
        Book.instance.world.fasesUnlocked[buttonBook.number - 1] = true;
    }

}
