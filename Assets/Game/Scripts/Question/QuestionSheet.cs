using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class QuestionSheet
{
    [Header("Question")]

    public string enunciated;
    public string alternative_A;
    public string alternative_B;
    public string alternative_C;
    public string alternative_D;
    public int alternativeCorrect;
    public Image imageQuestion;
    public bool isActivated;

}
