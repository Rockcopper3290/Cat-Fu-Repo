using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Game : MonoBehaviour
{
    //holds the different card elements/types
    public static int ATTACK = 0;
    public static int DEFEND = 1;
    public static int GUARDBREAK = 2;

    public static int WIN = 0;
    public static int LOSE = 1;
    public static int TIE = 2;

    static int MAX_HAND = 5;

    static string[] elementsArr = { "attack", "defend", "guardbreak" };
    private List<string> elements = new List<string>(elementsArr);

    static bool newGame;
    static bool startMatch;
    static Deck deck;

    static Hand playerHand;
    // static Bank player Bank; 

    static Hand AIHand;
    // static Bank AIBank; 

    static Card currentPlayerCard = null;
    static Card currentAICard = null;

    // static Random rand = new Random(); 

    public void Start()
    {
        newGame = true; 
    }

    public void game(string input)
    {
        if (newGame)
        {
            newGame = false;
            deck = new Deck();
            //deck.createCards(); 

            playerHand = new Hand();
            createHand(playerHand);
            //playerBank = new Bank()

            AIHand = new Hand();
            createHand(AIHand);
            //AIBank = new Bank();

        }
    }

    static void createHand(Hand hand)
    {
        for(int i = 0; i < MAX_HAND; i++)
        {
            
        }
    }

}
