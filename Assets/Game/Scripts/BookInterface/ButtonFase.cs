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
        buttonBook.SetUpButton(Book.instance.world.scenesFases, Book.instance.world.fasesUnlocked);
    }
    
    public void GetButtonBook()
    {
        buttonBook = GetComponent<ButtonBook>();
    }
}
