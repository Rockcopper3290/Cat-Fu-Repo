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

    static string[] elementsArr = { "attack", "defend", "guardbreak" };
    private List<string> elements = new List<string>(elementsArr);

    //static bool newGame;
    //static bool startMatch;
    ////static Deck deck;

    //static Deck playerHand;
    //// static Bank player Bank; 

    //static Deck AIHand;
    //// static Bank AIBank; 

    Card currentPlayerCard;
    Card currentCPUCard;


    public void Start()
    {
        
    }

    
    Hand hands;
    Deck deck;
    Submit_Button PlayerBoard;
     
    public void ScoreRound()
    {
      
       

       
    }

    public void BackEndStuff()
    {

        
        
    }



}
