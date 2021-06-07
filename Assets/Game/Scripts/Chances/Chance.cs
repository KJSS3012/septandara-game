using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Chance : MonoBehaviour
{

    [Header("Chance Question")]
    public bool isActive;
    public int indetifyChance;
    public Animator animChance;
    public StatusGame statusGame;

    private void Start()
    {
        animChance = GetComponent<Animator>();
        isActive = statusGame.chances[indetifyChance - 1];
        if (!isActive)
        {
            SwitchAnimation("idle-desactive", true);
        }
        else
        {
            SwitchAnimation("idle-active", true);
        }
    }

    public void SetActiveChance(bool value)
    {
        isActive = value;
    }

    public bool IsActiveChance()
    {
        return isActive;
    }

    public void SwitchAnimation(string anim, bool active)
    {
        animChance.SetBool(anim, active);
    }



}