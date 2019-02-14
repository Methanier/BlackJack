using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;

[ExecuteInEditMode]
public class Deck : MonoBehaviour
{
    public List<Card> cards;

    private void Awake()
    {
        cards = new List<Card>();
        InitDeck();
    }

    public void InitDeck()
    {
        Vector3 offset = Vector3.zero;
        foreach(int i in Enum.GetValues(typeof(Suite)))
        {
            if ((Suite)i != Suite.None)
            {
                foreach (int j in Enum.GetValues(typeof(Face)))
                {
                    if ((Face)j != Face.None)
                    {
                        Suite suite = (Suite)i;
                        Face face = (Face)j;
                        GameObject temp = LoadCard($"{face.ToString()} of {suite.ToString()}s");
                        GameObject newCard = GameObject.Instantiate(temp, transform);
                        Card card = newCard.AddComponent<Card>();
                        card.suite = suite;
                        card.face = face;
                        card.value = (j < 10) ? j : 10;
                        if ((Face)j == Face.Ace)
                            card.value = 11;
                        card.UpdateName();
                        newCard.name = card.cardName;
                        newCard.transform.localPosition = offset;
                        newCard.transform.eulerAngles = new Vector3(90, 0, 0);
                        float y = offset.y + Card.Thickness;
                        offset = new Vector3(0, y, 0);
                        cards.Add(card);
                    }
                }
            }
        }
    }

    private GameObject LoadCard(string name)
    {
        GameObject temp = Resources.Load<GameObject>($"Cards/{name}");
        return temp;
    }
}
