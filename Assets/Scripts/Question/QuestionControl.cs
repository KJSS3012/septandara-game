using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionControl : MonoBehaviour
{

    [Header("Components")]
    public GameObject questionObj;
    public Text enunciatedText;
    public Text alternativeA;
    public Text alternativeB;
    public Text alternativeC;
    public Text alternativeD;
    //public Image imageQuestion;
    //Tratamento de imagens: Criar uma pasta para armazenar as imagens. 
    //No arquivo JSON, colocar o nome da imagem e quando for feito a leitura, 
    //lembrar de verificar se a imagem existe na pasta.

    public void ShowQuestion(string enunciated, string altA, string altB, string altC, string altD)
    {
        questionObj.SetActive(true);
        enunciatedText.text = enunciated;
        alternativeA.text = altA;
        alternativeB.text = altB;
        alternativeC.text = altC;
        alternativeD.text = altD;
    }

}
