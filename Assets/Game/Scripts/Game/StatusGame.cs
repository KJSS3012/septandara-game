using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StatusGame : ScriptableObject
{

    public bool[] chances; //chances ativas da personagem
    public int consecutiveQuestion;
    public int quantLife; //porcentagem de vida
    public int scoreCoins; //quantidade de moedas

    public int scene;

}
