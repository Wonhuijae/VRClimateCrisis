using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    List<GameObject> spawnCards;

    GameManager gmInstance;

    private void Start()
    {
        spawnCards= new List<GameObject>();

        gmInstance = GameManager.instance;

        if (gmInstance != null) gmInstance.OnCardSelected += RemoveCards;
    }

    public void DrawCards()
    {
        if (spawnCards.Count > 0) RemoveCards();

        CreateCards<PerCard>(perCards, 0);
        CreateCards<CorCard>(corCards, 1);
        CreateCards<GovCard>(govCards, 2);
    }

    public void RemoveCards()
    {
        foreach(GameObject o in spawnCards)
        {
            Destroy(o);
        }

        spawnCards.Clear();
    }

    public void CreateCards<T>(T[] cardsGroup, int posIdx)
    {
        int idx = Random.Range(0, cardsGroup.Length);

        GameObject o = Instantiate(cardPrefab, spawnPos[posIdx].position, Quaternion.identity);

        if (cardsGroup[idx] is CardData)
        {
            CardData c = cardsGroup[idx] as CardData;
            o.GetComponent<Card>().SetCard(c);
        }

        spawnCards.Add(o);
    }
}
