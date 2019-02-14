using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Shoe : MonoBehaviour
{
    public int numberOfDecks = 6;
    public List<Card> shoe;

    private void Awake()
    {
        if (shoe == null || shoe.Count == 0)
        {
            shoe = new List<Card>();
            InitShoe();
        }
    }

    public void InitShoe()
    {
        GameObject temp = LoadCutCard();
        GameObject cutCardObj = GameObject.Instantiate(temp, transform);
        cutCardObj.transform.localPosition = Vector3.zero;
        Card cutCard = cutCardObj.AddComponent<Card>();
        cutCard.suite = Suite.None;
        cutCard.face = Face.None;
        cutCard.value = 0;
        cutCard.cardName = "CutCard";
        shoe.Add(cutCard);
        float y = transform.position.y + Card.Thickness;
        Vector3 offset = new Vector3(transform.position.x, y, transform.position.z);

        for(int i = 0; i < numberOfDecks; i++)
        {
            GameObject newDeck = new GameObject();
            newDeck.name = $"deck{i + 1}";
            newDeck.transform.position = offset;
            newDeck.transform.parent = transform;
            Deck deck = newDeck.AddComponent<Deck>();
            shoe.AddRange(deck.cards);
            y = deck.cards[deck.cards.Count - 1].gameObject.transform.position.y + Card.Thickness;
            offset = new Vector3(offset.x, y, offset.z);
        }
    }

    private GameObject LoadCutCard()
    {
        GameObject temp = Resources.Load<GameObject>("Cards/CutCard");
        return temp;
    }
}
