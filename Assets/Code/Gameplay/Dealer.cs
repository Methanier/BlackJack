using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dealer : MonoBehaviour
{
    public Hand hand;

    public IEnumerator PlayHand()
    {
        if(hand.handType == HandType.Soft)
        {
            while(hand.HandTotal <= 18)
            {
                Hit();
                yield return null;
            }

            if(hand.HandTotal > 21)
            {
                Bust();
                yield return null;
            }
            else
            {
                Stay();
                yield return null;
            }
        }
        else
        {
            while(hand.HandTotal <= 17)
            {
                Hit();
                yield return null;
            }

            if(hand.HandTotal > 21)
            {
                Bust();
                yield return null;
            }
            else
            {
                Stay();
                yield return null;
            }
        }
    }

    private void Hit()
    {
        //ask for card
        hand.HandTotal = hand.CalculateHand();
    }

    private void Stay()
    {
        
    }

    private void Bust()
    {
        //Dealer Loses
    }
}
