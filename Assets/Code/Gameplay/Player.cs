using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Hand> hands;
    public Hand currentHand;

    private void Awake()
    {
        hands = new List<Hand>();
    }

    public void Hit()
    {
        
    }

    public void Stay()
    {

    }

    public void DoubleDown()
    {

    }

    public void Split()
    {

    }

    public void Bust()
    {

    }

    public void TakeInsurance()
    {

    }
}
