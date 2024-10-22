using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public TextMeshProUGUI textName;
    public TextMeshProUGUI textContent;
    public TextMeshProUGUI textType;

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
            textName.text = card.name;
            textContent.text = card.cardContent;
            textType.text = card.cardType.ToString();
        }
    }
}
