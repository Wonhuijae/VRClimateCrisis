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

            // 예산 변화량
            int dB = card.cardCost;
            SetText(textCost, dB);
            textCost.text +=  dB.ToString("+#,0;-#,0");

            // 기온 변화량
            float dT = card.deltaTemperature * 0.16f;
            SetText(textDeltaT, -dT);
            textDeltaT.text += dT.ToString("+0.###;-0.###") + "°C";
        }
    }

    void SetText(TextMeshProUGUI _text, float _value)
    {
        if (_value == 0) _text.color = Color.white;
        else if (_value < 0) _text.color = Color.magenta;
        else
        {
            _text.color = Color.green;
        }
    }
}
