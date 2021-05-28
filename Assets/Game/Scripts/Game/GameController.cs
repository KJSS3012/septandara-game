using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    [Header("Coin Controller")]
    public int totalScoreCoins;
    [SerializeField] private Text textScoreCoins;

    [Header("Dialogue Controller")]
    [SerializeField] private GameObject dialogueUI;
    [SerializeField] private Text speechText;
    [SerializeField] private Text actorNameText;
    [SerializeField] private float writeSpeedSpeech;

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



    // MECHANICAL DIALOGUE
    public void ActiveDialogue(string actorName, string speech)
    {
        dialogueUI.SetActive(true);
        actorNameText.text = actorName;
        speechText.text = speech;
        StartCoroutine(WriteSpeech(speech));
    }

    IEnumerator WriteSpeech(string speech)
    {
        foreach (char letter in speech.ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(writeSpeedSpeech);
        }
    }

   



}
