using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public Image cardImage;
    public TextMeshProUGUI textName;
    public TextMeshProUGUI textContent;
    public TextMeshProUGUI textType;
    public TextMeshProUGUI textCost;
    public TextMeshProUGUI textDeltaT;

    CardData card;

    GameManager gmInstance;

    private void Awake()
    {
        gmInstance = GameManager.instance;
    }

    private void Start()
    {
        GetComponentInChildren<Button>().onClick.AddListener(() => gmInstance.OnSelectCard(card));
    }

    public void SetCard(CardData _card)
    {
        card = _card;

        if (card != null)
        {
            textName.text = card.cardName;
            textContent.text = card.cardContent;
            textType.text = gmInstance.GetType(card.cardType);
            cardImage.color = card.cardColor;

            int dB = card.cardCost;
            if (dB > 0)
            {
                textCost.color = Color.red;
                textCost.text += "+";
            }
            else if (dB < 0)
            {
                textCost.color = Color.blue;
            }
            else
            {
                textCost.color = Color.white;
            }

            textCost.text +=  dB.ToString("N0");

            float dT = card.deltaTemperature * 0.16f;
            if (dT < 0)
            {
                textDeltaT.color = Color.red;
            }
            else if (dT > 0)
            {
                textDeltaT.color = Color.blue;
                textDeltaT.text += "+";
            }
            else
            {
                textDeltaT.color = Color.white;
            }

            textDeltaT.text += dT.ToString("F3") + "¡ÆC";
        }
    }
}
