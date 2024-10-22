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

    public PerCard[] perCards; // 개인
    public CorCard[] corCards; // 기업
    public GovCard[] govCards; // 정부

    public Transform[] spawnPos;

    private void Start()
    {
        DrawCards();
    }

    public void DrawCards()
    {
        Instantiate(cardPrefab, spawnPos[0].position, Quaternion.identity).GetComponent<Card>().SetCard(perCards[0]);
        Instantiate(cardPrefab, spawnPos[1].position, Quaternion.identity).GetComponent<Card>().SetCard(corCards[0]);
        Instantiate(cardPrefab, spawnPos[2].position, Quaternion.identity).GetComponent<Card>().SetCard(govCards[0]);
    }
}
