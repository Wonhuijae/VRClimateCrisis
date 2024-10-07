using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum CardType
{
    Governmental,
    Corporate,
    Personal
}

public class CardSpawner : MonoBehaviour
{
    public GameObject cardPrefab;

    public PerCard[] perCards;
    public CorCard[] corCards;
    public GovCard[] govCards;

    public Transform[] spawnPos;

    private void Start()
    {
           
    }

    public void DrawCards()
    {
        Instantiate(cardPrefab, spawnPos[0].position, Quaternion.identity);
        Instantiate(cardPrefab, spawnPos[1].position, Quaternion.identity);
        Instantiate(cardPrefab, spawnPos[2].position, Quaternion.identity);
    }
}
