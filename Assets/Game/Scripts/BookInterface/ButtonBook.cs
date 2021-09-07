using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBook : MonoBehaviour
{

    public int number;
    public GameObject button;
    public GameObject childLock;
    public GameObject childImage;

    void Start()
    {

    }

    public void SetUpButton(int[] quant, bool[] unlocked)
    {
        if (number <= unlocked.Length)
        {
            bool IsLocked = unlocked[number - 1];
            if (!IsLocked && number == quant[number - 1])
            {
                UnlockedButton();
            }
            else if (IsLocked && number == quant[number - 1])
            {
                LockedButton();
            }
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    public void UnlockedButton()
    {
        childLock.SetActive(false);
        childImage.SetActive(true);
        Book.instance.world.fasesUnlocked[number - 1] = false;
    }

    public void LockedButton()
    {
        childLock.SetActive(true); //quando for lock true, lembrar de colocar uma trava pra impedir de clicar no butão
        childImage.SetActive(false);
    }

}
