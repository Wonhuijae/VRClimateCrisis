using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Scriptable/CorCard", fileName = "CorCard")]
public class CorCard : CardData
{
    public CorCard()
    {
        cardColor = new Color(1, (float)245 / 255, 0, 1);
        cardType = CardType.Corporate;

    }
}