using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI textDeltaTempY;
    public TextMeshProUGUI textTurn;
    public TextMeshProUGUI textCost;

    public Color[] colors;
    public Image map;

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
        SetUI();

        cardTypes = new Dictionary<CardType, string>(){
                                                        { CardType.Personal, "개인" },
                                                        { CardType.Corporate, "기업" },
                                                        { CardType.Governmental, "정부"}
                                                    };
    }

    void GameEnd()
    {

    }

    public void OnSelectCard(CardData _card)
    {
        // 턴 전환
        curTurn++;
        if(curTurn > maxTurn)
        {
            GameEnd();
            return;
        }

        month = curTurn % 13;
        if (month == 0)
        {
            month = 1;
            year++;
        }

        // 자금 차감
        if(_card.cardCost <=  budget)
        {
            budget -= _card.cardCost;
            
        }

        // 온도 변화량 계산
        deltaTempM *= _card.deltaTemperature;
        deltaTempY += deltaTempM;

        SetUI();
        // 턴 종료
        OnCardSelected();
    }

    void SetUI()
    {
        textCost.text = "자금: " + budget.ToString("N0");
        textTurn.text = year + "/" + month;

        string deltaTemp = "";
        if (deltaTempY > 0) deltaTemp = "+";
        deltaTemp += deltaTempY + "°C";
        textDeltaTempY.text = deltaTemp;

        int colorIdx = (int)deltaTempY;
        if (colorIdx > colors.Length - 1) colorIdx = colors.Length - 1; 
        map.color = colors[colorIdx];
    }

    public string GetType(CardType _cardType)
    {
        return cardTypes[_cardType];
    }
}