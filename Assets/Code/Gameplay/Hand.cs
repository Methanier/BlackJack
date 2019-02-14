using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HandType
{
    Soft,
    Hard,
}

public class Hand : MonoBehaviour
{
    private List<Card> hand;
    private Vector3 cardOffset;
    public int HandTotal { get; set; }
    public HandType handType { get; set; }

    private void Awake()
    {
        hand = new List<Card>();
        cardOffset = new Vector3(Card.Width / 2, Card.Thickness, Card.Length / 2);
    }

    public void AddCard(Card card)
    {
        hand.Add(card);
    }

    public void ClearHand()
    {
        foreach(Card card in hand)
        {
            if(card.face == Face.Ace)
            {
                card.value = 11;
            }
        }
        hand.Clear();
    }

    public int CalculateHand()
    {
        int total = 0;
        foreach(Card card in hand)
        {
            total += card.value;
            SetHandType();
        }

        if(ContainsAce() && total > 21)
        {
            SetAceValue(1);
            return CalculateHand();
        }

        return total;
    }

    public void SetHandType()
    {
        if(ContainsAce())
        {
            foreach(Card card in hand)
            {
                if(card.face == Face.Ace && card.value == 11)
                {
                    handType = HandType.Soft;
                }
            }
        }
    }

    private bool ContainsAce()
    {
        foreach(Card card in hand)
        {
            if (card.face == Face.Ace)
                return true;
        }
        return false;
    }

    private void SetAceValue(int value)
    {
        foreach(Card card in hand)
        {
            if(card.face == Face.Ace)
            {
                card.value = value;
                break;
            }
        }
    }
}
