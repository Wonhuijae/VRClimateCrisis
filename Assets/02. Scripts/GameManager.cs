using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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
    private int curTurn;
    private int maxTurn = 12;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }

        curTurn = 0;
    }
}
