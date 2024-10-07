using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/CardData", fileName = "Card Data")]
[System.Serializable]
public class CardData : ScriptableObject
{
    [SerializeField] public string cardName;
    [SerializeField] public string cardContent;
    [SerializeField] public Color cardColor;
    [SerializeField] public float carbonReduce;
}

[CreateAssetMenu(menuName = "Scriptable/PerCard", fileName = "PerCard")]
public class PerCard : CardData
{
    [SerializeField] public CardType cardType = CardType.Personal;

    public PerCard()
    {
        cardColor = Color.white;
    }
}

[CreateAssetMenu(menuName = "Scriptable/CorCard", fileName = "CorCard")]
public class CorCard : CardData
{
    [SerializeField] public CardType cardType = CardType.Corporate;

    public CorCard()
    {
        cardColor = new Color(1, (float)245 / 255, 0, 1);
    }
}

[CreateAssetMenu(menuName = "Scriptable/GovCard", fileName = "GovCard")]
public class GovCard : CardData
{
    [SerializeField] public CardType cardType = CardType.Governmental;

    public GovCard()
    {
        cardColor = new Color(1, (float)149 / 255, 0, 1);
    }
}