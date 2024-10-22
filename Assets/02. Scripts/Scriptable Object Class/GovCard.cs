using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/GovCard", fileName = "GovCard")]
public class GovCard : CardData
{
    public GovCard()
    {
        cardColor = new Color(1, (float)149 / 255, 0, 1);
        cardType = CardType.Governmental;
    }
}
