using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class deckSaver
{
    public string[] deckBlue;
    public string[] deckRed;

    public string tabBlue;
    public string tabRed;

    int i;

    public deckSaver (CardManager cardMan)
    {
        deckBlue = new string[12];
        deckRed = new string[12];

        foreach (Transform child in cardMan.deck1.transform)
        {
            cardCollection card = child.GetComponent<cardCollection>();

            deckBlue[i] = card.cardName;

            i++;
        }

        i = 0;

        foreach (Transform child in cardMan.deck2.transform)
        {
            cardCollection card = child.GetComponent<cardCollection>();

            deckRed[i] = card.cardName;

            i++;
        }

        i = 0;

        tabBlue = cardMan.tabTypeBlue;
        tabRed = cardMan.tabTypeRed;
    }
}
