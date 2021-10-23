using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Game : MonoBehaviour
{
    /*
    //holds the different card elements/types
    public static int ATTACK = 0;
    public static int DEFEND = 1;
    public static int GUARDBREAK = 2;

    public static int WIN = 0;
    public static int LOSE = 1;
    public static int TIE = 2;

    static string[] elementsArr = { "attack", "defend", "guardbreak" };
    private List<string> elements = new List<string>(elementsArr);
    */



    public string Player_Card;
    public string CPU_Card;

    public Submit_Button submitButton;
    public AIBehaviour AI_Behaviour;
    public Deck deck;

    //public Debugging debug;

    public Card currentPlayerCard;
    public Card currentCPUCard;

    private void Update()
    {
        //Every frame check to see if the AI has taken their turn
        //If they have begin main game logic
        if (AI_Behaviour.AIPlayed == true)
        {
            MainGame();
        }
    }

    public void MainGame()
    {
        bool DidThePlayerWin = false;
        //get Values of:
        // Player Card
        // Cpu Card

        Player_Card = submitButton.PlayerSelection.name;
        CPU_Card = AI_Behaviour.EnemySelection.name;

        // Split with multiple separators  
        string[] Player_Card_Array = Player_Card.Split(new char[] { ' ', ',', '.', '-', '\n', '\t' });
        Debug.Log(Player_Card_Array[0]);
        Player_Card_Array[0] = asignElement(Player_Card_Array[0]);
        Debug.Log(Player_Card_Array[0]);

        Debug.Log(Player_Card_Array[2]);
        Debug.Log(Player_Card_Array[4]);




        string[] CPU_Card_Array = CPU_Card.Split(new char[] { ' ', ',', '.', '-', '\n', '\t' });
        Debug.Log(CPU_Card_Array[0]);
        CPU_Card_Array[0] = asignElement(CPU_Card_Array[0]);
        Debug.Log(CPU_Card_Array[0]);

        Debug.Log(CPU_Card_Array[2]);
        Debug.Log(CPU_Card_Array[4]);



        //bool CTC_SameType_Answer = CardType_Comparison_SameType(Player_Card_Array[0], CPU_Card_Array[0]);

        //if both players have the same card trype
        if (Player_Card_Array[0] == CPU_Card_Array[0])
        {
            //run a check on which player has the higher powered card.
            DidThePlayerWin = PowerScore_Comparison(Player_Card_Array[2], CPU_Card_Array[2]);
        }
        //if both players do not have the same card type
        else if (Player_Card_Array[0] != CPU_Card_Array[0])
        {
            //Check card types for winner
            DidThePlayerWin = CardType_Comparison_DifferentTypes(Player_Card_Array[0], CPU_Card_Array[0]);
        }

        //for scoring cards
        if (DidThePlayerWin == true)
        {
            //score the players card
            Debug.Log("Player won the round");

        }
        else if (DidThePlayerWin == false && Player_Card_Array[2] != CPU_Card_Array[2])
        {
            //CPU Scores their card
            Debug.Log("CPU won the round");

        }
        else if (DidThePlayerWin == false && Player_Card_Array[2] == CPU_Card_Array[2])
        {
            // A Tie, No one scores this round, continue to next round
            Debug.Log("Tie: no winners");

        }



        AI_Behaviour.AIPlayed = false;
    }

    private string asignElement(string element)
    {
        if (element == "A")
        {
            element = "Attack";
        }
        else if (element == "D")
        {
            element = "Defend";
        }
        else if (element == "G")
        {
            element = "Guard Break";
        }

        return element;
    }

    private bool CardType_Comparison_SameType(string playerCard_Type, string CPUCard_Type)
    {
        bool answer = false;

        //is the Player card the same as the CPU card?
        if (playerCard_Type == CPUCard_Type)
        {
            answer = true;
        }
        else if (playerCard_Type != CPUCard_Type)
        {
            answer = false;
        }
        return answer;
    }

    private bool PowerScore_Comparison(string playerCard_PowerScore, string CPUCard_PowerScore)
    {
        bool answer = false;
        int Player_PowerScore;
        int CPU_PowerScore;

        //converts the strings to int
        int.TryParse(playerCard_PowerScore, out Player_PowerScore);
        int.TryParse(CPUCard_PowerScore, out CPU_PowerScore);



        //TODO: Finish...
        //is the Player card the same as the CPU card?
        if (Player_PowerScore > CPU_PowerScore)
        {
            // Player Scores the round
        }
        else if (Player_PowerScore < CPU_PowerScore)
        {
            // CPU Scores the round
        }
        else if (Player_PowerScore == CPU_PowerScore)
        {
            // A Tie, No one scores this round, continue to next round
        }


        return answer;
    }

    private bool CardType_Comparison_DifferentTypes(string playerCard_Type, string CPUCard_Type)
    {
        // Key:
        // Attack -> Guard Break
        // Guard Break -> Defend
        // Defend -> Attack


        bool answer = false;
        
        //is the Player card the same as the CPU card?
        if (playerCard_Type == "Attack")
        {
            if (CPUCard_Type == "Defend")
            {
                answer = false;
            }
            else if (CPUCard_Type == "Guard Break")
            {
                answer = true;
            }
        }
        else if (playerCard_Type == "Defend")
        {
            if (CPUCard_Type == "Attack")
            {
                answer = true;
            }
            else if (CPUCard_Type == "Guard Break")
            {
                answer = false;
            }
        }
        else if (playerCard_Type == "Guard Break")
        {
            if (CPUCard_Type == "Attack")
            {
                answer = false;
            }
            else if (CPUCard_Type == "Defend")
            {
                answer = true;
            }
        }


        //If answer is True: Player has the winning card type
        //If answer is False: Player has lost
        return answer;
    }




}
