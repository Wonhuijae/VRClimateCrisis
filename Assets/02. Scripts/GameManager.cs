using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI textDeltaTempY;
    public TextMeshProUGUI textTurn;
    public TextMeshProUGUI textCost;

    public static GameManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<GameManager>();
            }
            return m_instance;
        }
    }
    private static GameManager m_instance;

    private float carbonAmount;
    private float deltaTempY = 1.1f;
    private float deltaTempM = 0.16f;
    private int _curTurn;
    public int curTurn
    {
        get { return _curTurn; }
        set
        { 
            _curTurn = value;
        }
    }
    private int maxTurn = 48;

    private int budget = 500;

    int year = 2020;
    int month = 1;

    private Dictionary<CardType, string> cardTypes;

    private CardSpawner CardSpawner;

    public event Action OnCardSelected;

    private void Awake()
    {
        if(instance != this)
        {
            Destroy(gameObject);
        }

        curTurn = 1;
        textDeltaTempY.text = "+" + deltaTempY + "°C";
        textCost.text = "자금: " + budget.ToString("N0");

        cardTypes = new Dictionary<CardType, string>(){
                                                        { CardType.Personal, "개인" },
                                                        { CardType.Corporate, "기업" },
                                                        { CardType.Governmental, "정부"}
                                                    };
    }

    public void OnSelectCard(CardData _card)
    {
        curTurn++;
        month = curTurn % 13;
        if (month == 0)
        {
            month = 1;
            year++;
        }

        deltaTempM *= _card.deltaTemperature;
        deltaTempY += deltaTempM;

        if(_card.cardCost <=  budget)
        {
            budget -= _card.cardCost;
            textCost.text = "자금: " + budget.ToString("N0");
        }

        string deltaTemp = "";

        if (deltaTempY > 0) deltaTemp = "+";

        deltaTemp += deltaTempY + "°C";

        textDeltaTempY.text = deltaTemp;
        textTurn.text = year + "/" + month;

        OnCardSelected();
    }

    public string GetType(CardType _cardType)
    {
        return cardTypes[_cardType];
    }
}
