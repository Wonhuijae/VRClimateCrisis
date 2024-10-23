﻿using System;
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

    public Color[] mapColors;
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

    private float deltaTempResult = 1.1f;
    private float deltaTempSpeed = 0.16f; // 아무것도 하지 않을 경우 1달에 0.16도씩 상승
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

    private int budget = 5000;

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
        // 자금 확인
        if (-_card.cardCost <= budget)
        {
            budget += _card.cardCost;
        }
        else return;
        
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

        // 온도 변화량 계산
        deltaTempResult += deltaTempSpeed * _card.deltaTemperature;

        SetUI();
        // 턴 종료
        OnCardSelected();
    }

    void SetUI()
    {
        textCost.text = "자금: " + budget.ToString("N0");
        textTurn.text = year + "/" + month;

        string deltaTemp = "";
        if (deltaTempResult > 0) deltaTemp = "+";
        deltaTemp += deltaTempResult.ToString("F3") + "°C";
        textDeltaTempY.text = deltaTemp;

        int colorIdx = (int)deltaTempResult;
        if (colorIdx > mapColors.Length - 1) colorIdx = mapColors.Length - 1;
        else if (colorIdx < 0) colorIdx = 0;
        map.color = mapColors[colorIdx];
    }

    public string GetType(CardType _cardType)
    {
        return cardTypes[_cardType];
    }
}