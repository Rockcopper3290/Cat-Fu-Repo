using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    //holds the different card elements/types
    public static int ATTACK = 0;
    public static int DEFEND = 1;
    public static int GUARDBREAK = 2;

    //holds the different card categories/colours
    public static int RED = 0;
    public static int ORANGE = 1;
    public static int YELLOW = 2;
    public static int GREEN = 3;
    public static int BLUE = 4;
    public static int PURPLE = 5;

    //Deck Hands;

    public List<GameObject> playerHand;
    public List<GameObject> enemyHand;


    // list of cards which represent the players hand 
    public Hand()
    {
        //playerHand = Hands.playerHand;
        //enemyHand = Hands.enemyHand;
    }


    //public void addCard(Card card)
    //{
    //    hand.Add(card);
    //}

    //public Card GetCard(int element, int value)
    //{
    //    for (int i = 0; i < hand.Count; i++) // for the size of hand ( amount of cards in hand)
    //    {
    //        // if hand at i's element is equal to passed in element and hand at i's value is equal to passed in value
    //        if (hand[i].getElement() == element && hand[i].getValue() == value)
    //        {
    //            return hand[i]; // then return the card in hand
    //        }
    //    }

    //    return null;
    //}

    //// let player pick a card
    //public Card useCard(int element, int value)
    //{
    //    Card card = GetCard(element, value); // create a card element and get what card player using

    //    if (card == null) // if no card return null
    //    {
    //        return null;
    //    }

    //    hand.Remove(card); // remove the players card  

    //    return card;
    //}

    // let AI pick a card
    /*
    public Card useCard(int index)
    {
        Card card = hand[index];
        hand.Remove(index);
        return card; 
    }
    */
}
