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
    }

    public void UnlockedButtonFase()
    {
        int indexSceneActive = SceneManager.GetActiveScene().buildIndex;
        if (indexSceneActive == buttonBook.number-1 && buttonBook.IsLock)
        {
            buttonBook.childLock.gameObject.SetActive(false); //quando for lock true, lembrar de colocar uma trava pra impedir de clicar no butão
            buttonBook.childImage.gameObject.SetActive(true);
            buttonBook.IsLock = false;
        }
    }

}
