using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public int totalScoreCoins;
    public Text textScoreCoins;

    public static GameController instance;

    private void Start()
    {
        instance = this;
    }


    public void UpdateScoreCoins()
    {
        textScoreCoins.text = totalScoreCoins.ToString();
    }

}
