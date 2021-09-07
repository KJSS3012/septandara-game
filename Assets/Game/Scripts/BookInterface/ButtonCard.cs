using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCard : MonoBehaviour
{
    public ButtonBook buttonBook;

    private void Start()
    {
        buttonBook = GetComponent<ButtonBook>();
        buttonBook.SetUpButton(Book.instance.world.cards, Book.instance.world.cardsUnlocked);
    }

    public void GetButtonBook()
    {
        buttonBook = GetComponent<ButtonBook>();
    }
}
