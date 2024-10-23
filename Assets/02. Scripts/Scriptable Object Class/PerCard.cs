using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Scriptable/PerCard", fileName = "PerCard")]
public class PerCard : CardData
{
    public PerCard()
    {
        cardColor = new Color(1, 1, 1, 1);
        cardType = CardType.Personal;
    }
}
