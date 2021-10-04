using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    //holds the different card elements/types
    public static int FIRE = 0;
    public static int WATER = 1;
    public static int SNOW = 2;

    //holds the different card categories/colours

    public static int RED = 0;
    public static int ORANGE = 1;
    public static int YELLOW = 2;
    public static int GREEN = 3;
    public static int BLUE = 4;
    public static int PURPLE = 5;

    private List<Card> deck;
    // Random rand = new Random();
    

    public Deck()
    {
        deck = new List<Card>();
    }

    
    public void CreateCards()
    {
        Card card;
        for (int value = 2; value <= 12; value++)
        {
            for (int element = FIRE; element <= SNOW; element++)
            {
                for (int color = RED; color <= PURPLE; color++)
                {
                    //int color = rand.nextInt(PURPLE + 1);
                    card = new Card(element, value, color);

                    //will print out a complete list of all possiable card combinations
                    Debug.Log(card.outputAsString());
                    deck.Add(card);
                    //Debug.Log();
                }
            }
        }
        

        //shuffle();
    }

    
    public List<Card> GetCards()
    {
        return deck;
    }
    public Card Deal()
    {
        Card card = deck[0];
        deck.RemoveAt(0);
        //if deck is empty
        if (deck.Count == 0)
        {
            CreateCards();
        }
        return card;
    }

    //public void shuffle()
    //{
    //    for (int i = 0; i < deck.size(); i++)
    //    {
    //        int index = rand.nextInt(deck.size());
    //        Card x = deck.get(i);
    //        Card y = deck.get(index);
    //        deck.set(i, y);
    //        deck.set(index, x);
    //    }
    //}

    //debugging: will print out a complete list of all possiable card combinations
    private void Start()
    {
        CreateCards();
    }



}
