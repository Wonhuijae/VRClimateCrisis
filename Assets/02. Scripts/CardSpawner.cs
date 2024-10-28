using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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

    List<PerCard> perCards = new(); // 개인
    List<CorCard> corCards = new(); // 기업
    List<GovCard> govCards = new(); // 정부

    public Transform[] spawnPos;
    
    AudioSource audioSource;
    public AudioClip spawnClip;

    List<GameObject> spawnCards;

    GameManager gmInstance;

    private void Start()
    {
        spawnCards= new List<GameObject>();

        gmInstance = GameManager.instance;
        audioSource = GetComponent<AudioSource>();

        if (gmInstance != null) gmInstance.OnCardSelected += RemoveCards;

        InitCards<PerCard>(perCards, "Per");
        InitCards<CorCard>(corCards, "Cor");
        InitCards<GovCard>(govCards, "Gov");
    }

    public void DrawCards()
    {
        if (spawnCards.Count > 0) RemoveCards();

        audioSource.PlayOneShot(spawnClip);
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

    public void CreateCards<T>(List<T> cardsGroup, int posIdx)
    {
        int idx = Random.Range(0, cardsGroup.Count);

        GameObject o = Instantiate(cardPrefab, spawnPos[posIdx].position, Quaternion.identity);
        CardData c = cardsGroup[idx] as CardData;

        if (c != null)
        {
            if (gmInstance.budget < -c.cardCost) o.GetComponentInChildren<Button>().interactable = false;
            o.GetComponent<Card>().SetCard(c);
        }

        spawnCards.Add(o);
    }

    // 리소스 폴더에서 데이터 불러와서 초기화
    // UnityEngine.Object를 상속받은 경우에만 사용하도록 제한
    void InitCards<T>(List<T> cardGroup, string path) where T : UnityEngine.Object
    {
        T[] cards = Resources.LoadAll<T>("Scriptable Object/" + path);
        foreach (var c in cards)
        {
            cardGroup.Add(c);

            Debug.Log(c.name);
        }
    }
}
