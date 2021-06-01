using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    [Header("Coin Controller")]
    public int totalScoreCoins;
    [SerializeField] private Text textScoreCoins;

    public static GameController instance;

    private void Start()
    {
        instance = this;
    }

    
    // MECHANICAL COINS
    public void UpdateScoreCoins()
    {
        if (totalScoreCoins < 100)
        {
            //ajustar exibição das moedas
        }
        textScoreCoins.text = totalScoreCoins.ToString();
    }


}
