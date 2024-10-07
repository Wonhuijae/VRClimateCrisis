using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/CardData", fileName = "Card Data")]
[System.Serializable]
public class CardData : ScriptableObject
{
    [SerializeField] public string cardName;
    [SerializeField] public string cardContent;
    [SerializeField] public CardType cardType;
    [SerializeField] public Color cardColor;
    [SerializeField] public float carbonReduce;
}