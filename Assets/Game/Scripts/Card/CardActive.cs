using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardActive : MonoBehaviour
{

    public Text cardName;
    public Text cardDescription;
    public GameObject spamTextUI;
    public GameObject showCardUI;
    public DataCards cards;
    public int idCard;
    public VisibilityControls vsControls;

    private void Start()
    {
        vsControls = GameObject.FindGameObjectWithTag("Controls").GetComponent<VisibilityControls>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        vsControls.OpacityControls(0.5f, false);
        cardName.text = cards.cards[idCard-1].name;
        cardDescription.text = cards.cards[idCard-1].description;
        showCardUI.SetActive(true);
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2f);
        spamTextUI.SetActive(true);
        Destroy(this.gameObject, 0.2f);
    }

}
