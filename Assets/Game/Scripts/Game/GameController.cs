using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    [Header("Coin Controller")]
    public int totalScoreCoins;
    [SerializeField] private Text textScoreCoins;

    [Header("Heart Life Controller")]
    public int percentageLife;
    [SerializeField] private Text textPercentageHeart;

    [Header("Chances Controller")]
    public Text resultsChanceActive;
    public Text resultsChanceDesactive;
    public Chance[] chances = new Chance[5];
    public int concecutiveCorrectQuestion;

    public static GameController instance;

    public StatusGame statusGame;

    private void Start()
    {
        instance = this;
        textPercentageHeart.text = percentageLife.ToString() + "%";
        concecutiveCorrectQuestion = 0;
        
        totalScoreCoins = statusGame.scoreCoins;
        UpdateScoreCoins();
        percentageLife = statusGame.quantLife;
        UpdatePercentageLife();
    }

    
    // MECHANICAL COINS
    public void UpdateScoreCoins()
    {
        textScoreCoins.text = totalScoreCoins.ToString();
        statusGame.scoreCoins = totalScoreCoins;
    }


    //MECHANICAL HEARTS LIFE
    public void UpdatePercentageLife()
    {
        textPercentageHeart.text = percentageLife.ToString() + "%";
        statusGame.quantLife = percentageLife;
    }


    //MECHANICAL CHANCES QUESTION
    public void ActiveAnimChanceNow(int index, bool isDesactive)
    {
        if (isDesactive)
        {
            chances[index].SwitchAnimation("idle-active", true);
            chances[index].SwitchAnimation("desactive", true);
        }
        else if(!isDesactive)
        {
            chances[index].SwitchAnimation("idle-desactive", true);
            chances[index].SwitchAnimation("active", true);
        }
    }

    public void VerifyChances(bool isMissChange)
    {
        int indexDesactive = chances.Length-1;
        int indexActive = 0;
        do
        {
            if (chances[indexDesactive].IsActiveChance() && isMissChange)
            {
                ActiveAnimChanceNow(indexDesactive, true);
                chances[indexDesactive].SetActiveChance(false);
                statusGame.chances[indexDesactive] = false;
                resultsChanceDesactive.gameObject.SetActive(true);
                resultsChanceDesactive.text = "-1 Chance";
                StartCoroutine(DelayDesactiveText(true));
                break;
            }
            else if(!chances[indexActive].IsActiveChance() && !isMissChange && concecutiveCorrectQuestion == 2)
            {
                ActiveAnimChanceNow(indexActive, false);
                chances[indexActive].SetActiveChance(true);
                statusGame.chances[indexActive] = true;
                concecutiveCorrectQuestion = 0;
                resultsChanceActive.gameObject.SetActive(true);
                resultsChanceActive.text = "+1 Chance";
                StartCoroutine(DelayDesactiveText(false));
                break;
            }
            Debug.Log("0-4 : [" + indexActive + "] 4-0: [" + indexDesactive + "]");
            indexDesactive--;
            indexActive++;
        } while (indexDesactive>=0 && indexActive>0);
    }

    IEnumerator DelayDesactiveText(bool alternative)
    {
        yield return new WaitForSeconds(2.5f);
        if (alternative)
        {
            resultsChanceDesactive.gameObject.SetActive(false);
        }
        else
        {
            resultsChanceActive.gameObject.SetActive(false);
        }
    }



}
