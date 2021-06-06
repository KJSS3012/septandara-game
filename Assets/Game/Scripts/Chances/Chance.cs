using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Chance : MonoBehaviour
{

    [Header("Chance Question")]
    public bool isActive;
    public int indetifyChance;
    public Animator animChance;

    private void Start()
    {
        animChance = GetComponent<Animator>();
        isActive = true;
    }

    public void SetActiveChance(bool value)
    {
        isActive = value;
    }

    public bool IsActiveChance()
    {
        return isActive;
    }

    public void SwitchAnimationEmptyTrue()
    {
        StartCoroutine(DelayDesactiveChance());
        animChance.SetBool("desactive", true);
    }

    IEnumerator DelayDesactiveChance()
    {
        yield return new WaitForSeconds(2);
    }



}