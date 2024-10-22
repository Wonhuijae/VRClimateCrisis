using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI textDeltaTempY;

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

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }

        curTurn = 1;
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

        textDeltaTempY.text = deltaTempY + "°C";
    }
}
