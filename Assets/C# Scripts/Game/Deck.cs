using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{

    //houses a list of every card combonation in the game

    //package com.polymars.game;

    //import java.util.ArrayList;
    //import java.util.Random;


    public enum cardType
    {
        FIRE,
        WATER,
        SNOW
    }
    

    public enum cardColour
    {
        RED,
        ORANGE,
        YELLOW,
        GREEN,
        BLUE,
        PURPLE
    }

    private List<Card> deck;
    //Random rand = new Random();

    public Deck()
    {
        deck = new List<Card>();
    }

    public void createCards()
    {
        for (int value = 2; value <= 12; value++)
        {
            for (int element = FIRE; element <= SNOW; element++)
            {
                int color = rand.nextInt(PURPLE + 1);
                Card card = new Card(element, value, color);
                deck.add(card);
            }
        }
        shuffle();
    }



    public List<Card> getCards()
    {
        return deck;
    }

    public Card deal()
    {
        Card card = deck.remove(0);
        if (deck.isEmpty())
        {
            createCards();
        }
        return card;
    }

    public void shuffle()
    {
        for (int i = 0; i < deck.size(); i++)
        {
            int index = rand.nextInt(deck.size());
            Card x = deck.get(i);
            Card y = deck.get(index);
            deck.set(i, y);
            deck.set(index, x);
        }
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
