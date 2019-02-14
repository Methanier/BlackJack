using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public enum Suite
{
    None,
    Heart,
    Spade,
    Diamond,
    Club
}

public enum Face
{
    None = 0,    
    Two = 2,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Jack,
    Queen,
    King,
    Ace,
}


[ExecuteInEditMode]
public class Card : MonoBehaviour
{
    [ReadOnly] public string cardName;
    public Suite suite;
    public Face face;
    public int value;

    private const float width = 0.153f;
    private const float length = 0.22f;
    private const float thickness = 0.0014f;

    public static float Width => width;
    public static float Length => length;
    public static float Thickness => thickness;

    private void Awake()
    {
        cardName = $"{face.ToString()} of {suite.ToString()}s";
    }

    public void UpdateName()
    {
        cardName = $"{face.ToString()} of {suite.ToString()}s";
    }
}
