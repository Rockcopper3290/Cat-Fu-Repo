using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPU_AI : MonoBehaviour
{
    public GameObject CPU_Hand_Location;

    //Location for where the CPU Stores their scored cards
    public GameObject CPU_ScoredCards_Attack_Zone;
    public GameObject CPU_ScoredCards_Defence_Zone;
    public GameObject CPU_ScoredCards_GuardBreak_Zone;

    //Location for where the Player Stores their scored cards
    public GameObject Player_ScoredCards_Attack_Zone;
    public GameObject Player_ScoredCards_Defence_Zone;
    public GameObject Player_ScoredCards_GuardBreak_Zone;

    //A List that is used to hold the colour values of the scored CPU cards
    public List<string> CPU_ScoredCards_Attack_Colour;
    public List<string> CPU_ScoredCards_Defence_Colour;
    public List<string> CPU_ScoredCards_GuardBreak_Colour;

    //A List that is used to hold the colour values of the scored Player cards
    public List<string> Player_ScoredCards_Attack_Colour;
    public List<string> Player_ScoredCards_Defence_Colour;
    public List<string> Player_ScoredCards_GuardBreak_Colour;


    public Game game;
    public AIBehaviour AI_Behaviour;


    public string[] CPU_CurrentHand;

    // A 2D Array to store all the infomation about the CPU's current hand
    public string[,] CPU_CurrentHand_Matrix_Storage;


    const int HandSize = 5;

    //Main Function of the CPU's AI proper
    public void CpuAI_Main()
    {
        //get Values of:
        // CPU Hand

        // Initialize variables
        CPU_CurrentHand = new string[5];
        CPU_CurrentHand_Matrix_Storage = new string[5, 5];

        // Start of card hand infomation gathering
        GatherHandInfo_and_Store();

        // Adds the scored cards name (Colour to a list)
        ScoredCards_Attack();
        ScoredCards_Defend();
        ScoredCards_GuardBreak();

        // Adds the scored cards name for the player (Colour to a list)
        Player_ScoredCards_Attack();
        Player_ScoredCards_Defend();
        Player_ScoredCards_GuardBreak();


        //TODO: Figure out what card type is the closest to winning me (AI/CPU) the game
        //Run the Win con check/card pick on each card type independently from each other


        // Offensive Win Con Checking: Begin 
        //
        //    This section the AI will check its the cards that it has 
        // scored (Scored zones) and hand to see if they have a card 
        // that will win them the game. These functions will also 
        // automaticly select the winning card and play said card.
        // =================================================================================================================

        if (AI_Behaviour.AIPlayed == false)
        {
            //Will run a check to see if playing any kind of Guard Break card from the hand will win CPU the game
            DoubleCardType_WinCon_Check(CPU_ScoredCards_Attack_Zone.transform.childCount,
                                        CPU_ScoredCards_Attack_Colour,
                                        CPU_ScoredCards_Defence_Zone.transform.childCount,
                                        CPU_ScoredCards_Defence_Colour,
                                        AI_Behaviour.EnemySelection,
                                        "G");
        }

        if (AI_Behaviour.AIPlayed == false)
        {
            //Will run a check to see if playing any kind of Attack card from the hand will win CPU the game
            DoubleCardType_WinCon_Check(CPU_ScoredCards_Defence_Zone.transform.childCount,
                                        CPU_ScoredCards_Defence_Colour,
                                        CPU_ScoredCards_GuardBreak_Zone.transform.childCount,
                                        CPU_ScoredCards_GuardBreak_Colour,
                                        AI_Behaviour.EnemySelection,
                                        "A");
        }

        if (AI_Behaviour.AIPlayed == false)
        {
            //Will run a check to see if playing any kind of Defence card from the hand will win CPU the game
            DoubleCardType_WinCon_Check(CPU_ScoredCards_GuardBreak_Zone.transform.childCount,
                                        CPU_ScoredCards_GuardBreak_Colour,
                                        CPU_ScoredCards_Attack_Zone.transform.childCount,
                                        CPU_ScoredCards_Attack_Colour,
                                        AI_Behaviour.EnemySelection,
                                        "D");
        }


        if (AI_Behaviour.AIPlayed == false)
        {
            //Will run a check to see if playing any kind of Attack card from the hand will win CPU the game
            SingleCardType_WinCon_Check(CPU_ScoredCards_Attack_Zone.transform.childCount,
                                        CPU_ScoredCards_Attack_Colour,
                                        AI_Behaviour.EnemySelection);
        }
        if (AI_Behaviour.AIPlayed == false)
        {
            //Will run a check to see if playing any kind of Defence card from the hand will win CPU the game
            SingleCardType_WinCon_Check(CPU_ScoredCards_Defence_Zone.transform.childCount,
                                        CPU_ScoredCards_Defence_Colour,
                                        AI_Behaviour.EnemySelection);
        }
        if (AI_Behaviour.AIPlayed == false)
        {
            //Will run a check to see if playing any kind of Guard Break card from the hand will win CPU the game
            SingleCardType_WinCon_Check(CPU_ScoredCards_GuardBreak_Zone.transform.childCount,
                                        CPU_ScoredCards_GuardBreak_Colour,
                                        AI_Behaviour.EnemySelection);
        }

        // Offensive Win Con Checking: End 
        // =================================================================================================================




        // Defensive Move Checking: Begin 
        //
        //    This section the AI will check its the hand and what the 
        // player has scored as well as the to see if they have a  
        // card that will win them the game. These functions will  
        // also automaticly select the card that would best counter 
        // the player and play said card.
        // =================================================================================================================

        if (AI_Behaviour.AIPlayed == false)
        {
            //Will run a check to see if playing any kind of Guard Break card from the hand will win CPU the game
            Defensive_DoubleCardType_WinCon_Check(Player_ScoredCards_Attack_Zone.transform.childCount,
                                        Player_ScoredCards_Attack_Colour,
                                        Player_ScoredCards_Defence_Zone.transform.childCount,
                                        Player_ScoredCards_Defence_Colour,
                                        AI_Behaviour.EnemySelection,
                                        "A");
        }

        if (AI_Behaviour.AIPlayed == false)
        {
            //Will run a check to see if playing any kind of Attack card from the hand will win CPU the game
            Defensive_DoubleCardType_WinCon_Check(Player_ScoredCards_Defence_Zone.transform.childCount,
                                        Player_ScoredCards_Defence_Colour,
                                        Player_ScoredCards_GuardBreak_Zone.transform.childCount,
                                        Player_ScoredCards_GuardBreak_Colour,
                                        AI_Behaviour.EnemySelection,
                                        "D");
        }

        if (AI_Behaviour.AIPlayed == false)
        {
            //Will run a check to see if playing any kind of Defence card from the hand will win CPU the game
            Defensive_DoubleCardType_WinCon_Check(Player_ScoredCards_GuardBreak_Zone.transform.childCount,
                                        Player_ScoredCards_GuardBreak_Colour,
                                        Player_ScoredCards_Attack_Zone.transform.childCount,
                                        Player_ScoredCards_Attack_Colour,
                                        AI_Behaviour.EnemySelection,
                                        "G");
        }


        if (AI_Behaviour.AIPlayed == false)
        {
            //Will run a check to see if playing any kind of Attack card from the hand will win CPU the game
            SingleCardType_WinCon_Check(CPU_ScoredCards_Attack_Zone.transform.childCount,
                                        CPU_ScoredCards_Attack_Colour,
                                        AI_Behaviour.EnemySelection);
        }
        if (AI_Behaviour.AIPlayed == false)
        {
            //Will run a check to see if playing any kind of Defence card from the hand will win CPU the game
            SingleCardType_WinCon_Check(CPU_ScoredCards_Defence_Zone.transform.childCount,
                                        CPU_ScoredCards_Defence_Colour,
                                        AI_Behaviour.EnemySelection);
        }
        if (AI_Behaviour.AIPlayed == false)
        {
            //Will run a check to see if playing any kind of Guard Break card from the hand will win CPU the game
            SingleCardType_WinCon_Check(CPU_ScoredCards_GuardBreak_Zone.transform.childCount,
                                        CPU_ScoredCards_GuardBreak_Colour,
                                        AI_Behaviour.EnemySelection);
        }


        // Defensive Move Checking: End 
        // =================================================================================================================



    } // END AI_MAIN


    public void GatherHandInfo_and_Store()
    {
        // Start of Infomation Gathering:
        //   This section of the code gathers the names which we are then able to 
        //   learn what the cards type, power and colour

        CPU_CurrentHand[0] = CPU_Hand_Location.transform.GetChild(0).name;
        CPU_CurrentHand[1] = CPU_Hand_Location.transform.GetChild(1).name;
        CPU_CurrentHand[2] = CPU_Hand_Location.transform.GetChild(2).name;
        CPU_CurrentHand[3] = CPU_Hand_Location.transform.GetChild(3).name;
        CPU_CurrentHand[4] = CPU_Hand_Location.transform.GetChild(4).name;


        string[] CPU_Card_0 = CPU_CurrentHand[0].Split(new char[] { ' ', ',', '.', '-', '\n', '\t' });
        CPU_Card_0[0] = game.asignElement(CPU_Card_0[0]);
        Debug.Log(CPU_Card_0[0]);// --- Element
        Debug.Log(CPU_Card_0[2]);// --- Power
        Debug.Log(CPU_Card_0[4]);// --- Colour

        string[] CPU_Card_1 = CPU_CurrentHand[1].Split(new char[] { ' ', ',', '.', '-', '\n', '\t' });
        CPU_Card_1[1] = game.asignElement(CPU_Card_1[1]);

        string[] CPU_Card_2 = CPU_CurrentHand[2].Split(new char[] { ' ', ',', '.', '-', '\n', '\t' });
        CPU_Card_2[2] = game.asignElement(CPU_Card_2[2]);

        string[] CPU_Card_3 = CPU_CurrentHand[3].Split(new char[] { ' ', ',', '.', '-', '\n', '\t' });
        CPU_Card_3[2] = game.asignElement(CPU_Card_3[3]);

        string[] CPU_Card_4 = CPU_CurrentHand[4].Split(new char[] { ' ', ',', '.', '-', '\n', '\t' });
        CPU_Card_4[2] = game.asignElement(CPU_Card_3[4]);
        // End of hand Infomation Gathering


        //Store all current hand values into a 2d array
        for (int i = 0; i < 5; i++)
            CPU_CurrentHand_Matrix_Storage[0, i] = CPU_Card_0[i];

        for (int i = 0; i < 5; i++)
            CPU_CurrentHand_Matrix_Storage[1, i] = CPU_Card_1[i];

        for (int i = 0; i < 5; i++)
            CPU_CurrentHand_Matrix_Storage[2, i] = CPU_Card_2[i];

        for (int i = 0; i < 5; i++)
            CPU_CurrentHand_Matrix_Storage[3, i] = CPU_Card_3[i];

        for (int i = 0; i < 5; i++)
            CPU_CurrentHand_Matrix_Storage[4, i] = CPU_Card_4[i];
        //End of storage
    }

    // what type of card (Card Type) do I have the most of in my (AI/CPU's) hand
    public void HandPriority(string CPU_Card_0_Type,
                             string CPU_Card_1_Type,
                             string CPU_Card_2_Type,
                             string CPU_Card_3_Type,
                             string CPU_Card_4_Type)
    {

        //Load CPU's cards hand type into an array
        string[] Current_CardTypes = new string[5];
        Current_CardTypes[0] = CPU_Card_0_Type;
        Current_CardTypes[1] = CPU_Card_1_Type;
        Current_CardTypes[2] = CPU_Card_2_Type;
        Current_CardTypes[3] = CPU_Card_3_Type;
        Current_CardTypes[4] = CPU_Card_4_Type;

        int Attack_CardType_Tally = 0;
        int Defend_CardType_Tally = 0;
        int GuardBreak_CardType_Tally = 0;

        // Tally up to see which card type we have the most of
        for (int i = 0; i < HandSize; i++)
        {
            if (Current_CardTypes[i] == "Attack")
            {
                Attack_CardType_Tally += 1;
            }
            else if (Current_CardTypes[i] == "Defend")
            {
                Defend_CardType_Tally += 1;
            }
            else if (Current_CardTypes[i] == "Guard Break")
            {
                GuardBreak_CardType_Tally += 1;
            }
        }



    }

    // Adds the scored cards name (Colour to a list)
    public void ScoredCards_Attack()
    {
        //Clear the previosly stored scored cards (to prevent any errors)
        CPU_ScoredCards_Attack_Colour.Clear();

        int CPU_ScoredAttackCards_ChildCount = CPU_ScoredCards_Attack_Zone.transform.childCount;
        if (CPU_ScoredAttackCards_ChildCount != 0)
        {
            for (int index = 0; index < CPU_ScoredAttackCards_ChildCount; index++)
            {
                //Get the name (Card Colour of the currently indexed card).
                string CurrentIndex_CardColour = CPU_ScoredCards_Attack_Zone.transform.GetChild(index).name;

                // Add currently indexed card to the list of colours for this zone (To be used for comparisons)
                CPU_ScoredCards_Attack_Colour.Add(CurrentIndex_CardColour);
            }
        }
        
    }

    // Adds the scored cards name (Colour to a list)
    public void ScoredCards_Defend()
    {
        //Clear the previosly stored scored cards (to prevent any errors)
        CPU_ScoredCards_Defence_Colour.Clear();

        int CPU_ScoredDefendCards_ChildCount = CPU_ScoredCards_Defence_Zone.transform.childCount;
        if (CPU_ScoredDefendCards_ChildCount != 0)
        {
            for (int index = 0; index < CPU_ScoredDefendCards_ChildCount; index++)
            {
                //Get the name (Card Colour of the currently indexed card).
                string CurrentIndex_CardColour = CPU_ScoredCards_Defence_Zone.transform.GetChild(index).name;

                // Add currently indexed card to the list of colours for this zone (To be used for comparisons)
                CPU_ScoredCards_Defence_Colour.Add(CurrentIndex_CardColour);
            }
        }
    }

    // Adds the scored cards name (Colour to a list)
    public void ScoredCards_GuardBreak()
    {
        //Clear the previosly stored scored cards (to prevent any errors)
        CPU_ScoredCards_GuardBreak_Colour.Clear();

        int CPU_ScoredGuardBreakCards_ChildCount = CPU_ScoredCards_GuardBreak_Zone.transform.childCount;
        if (CPU_ScoredGuardBreakCards_ChildCount != 0)
        {
            for (int index = 0; index < CPU_ScoredGuardBreakCards_ChildCount; index++)
            {
                //Get the name (Card Colour of the currently indexed card).
                string CurrentIndex_CardColour = CPU_ScoredCards_GuardBreak_Zone.transform.GetChild(index).name;

                // Add currently indexed card to the list of colours for this zone (To be used for comparisons)
                CPU_ScoredCards_GuardBreak_Colour.Add(CurrentIndex_CardColour);
            }
        }
        
    }

    // ----------------

    // Adds the scored cards name (Colour to a list)
    public void Player_ScoredCards_Attack()
    {
        //Clear the previosly stored scored cards (to prevent any errors)
        Player_ScoredCards_Attack_Colour.Clear();

        int Player_ScoredAttackCards_ChildCount = Player_ScoredCards_Attack_Zone.transform.childCount;
        if (Player_ScoredAttackCards_ChildCount != 0)
        {
            for (int index = 0; index < Player_ScoredAttackCards_ChildCount; index++)
            {
                //Get the name (Card Colour of the currently indexed card).
                string CurrentIndex_CardColour = Player_ScoredCards_Attack_Zone.transform.GetChild(index).name;

                // Add currently indexed card to the list of colours for this zone (To be used for comparisons)
                Player_ScoredCards_Attack_Colour.Add(CurrentIndex_CardColour);
            }
        }

    }

    // Adds the scored cards name (Colour to a list)
    public void Player_ScoredCards_Defend()
    {
        //Clear the previosly stored scored cards (to prevent any errors)
        Player_ScoredCards_Defence_Colour.Clear();

        int Player_ScoredDefendCards_ChildCount = Player_ScoredCards_Defence_Zone.transform.childCount;
        if (Player_ScoredDefendCards_ChildCount != 0)
        {
            for (int index = 0; index < Player_ScoredDefendCards_ChildCount; index++)
            {
                //Get the name (Card Colour of the currently indexed card).
                string CurrentIndex_CardColour = Player_ScoredCards_Defence_Zone.transform.GetChild(index).name;

                // Add currently indexed card to the list of colours for this zone (To be used for comparisons)
                Player_ScoredCards_Defence_Colour.Add(CurrentIndex_CardColour);
            }
        }
    }

    // Adds the scored cards name (Colour to a list)
    public void Player_ScoredCards_GuardBreak()
    {
        //Clear the previosly stored scored cards (to prevent any errors)
        Player_ScoredCards_GuardBreak_Colour.Clear();

        int Player_ScoredGuardBreakCards_ChildCount = Player_ScoredCards_GuardBreak_Zone.transform.childCount;
        if (Player_ScoredGuardBreakCards_ChildCount != 0)
        {
            for (int index = 0; index < Player_ScoredGuardBreakCards_ChildCount; index++)
            {
                //Get the name (Card Colour of the currently indexed card).
                string CurrentIndex_CardColour = Player_ScoredCards_GuardBreak_Zone.transform.GetChild(index).name;

                // Add currently indexed card to the list of colours for this zone (To be used for comparisons)
                Player_ScoredCards_GuardBreak_Colour.Add(CurrentIndex_CardColour);
            }
        }

    }

    // ---------------

    public void SingleCardType_WinCon_Check(int GivenCardType_ScoredCardZone_ChildCount, 
                                            List<string> CPU_ScoredCards_CardType_Colour,
                                            GameObject EnemySelection)
    {
        // Function checks to see if the AI has scored aleast 2 attack cards that are different colours
        // and picks a card from the hand that (if they win) will fulfill a Win Condition

        

        // Run IF, there at least 2, scored cards in the attack zone.
        if (GivenCardType_ScoredCardZone_ChildCount >= 2)
        {
            // Going through the scored Cards (first time)
            for (int index_1 = 0; index_1 < GivenCardType_ScoredCardZone_ChildCount; index_1++)
            {

                // Going through the scored Cards (second time)
                for (int index_2 = 0; index_2 < GivenCardType_ScoredCardZone_ChildCount; index_2++)
                {

                    //ALL USING THE SCORED CARDS NAME (A.K.A. The scored colour)
                    //If Scored_Card[index_1] and Scored_Card[index_2] are different
                    if (CPU_ScoredCards_CardType_Colour[index_1] != CPU_ScoredCards_CardType_Colour[index_2])
                    {
                        // Search through the CPU's cards in their hand
                        for (int index_3 = 0; index_3 < HandSize; index_3++)
                        {
                            // Row, Column
                            //if current card from hand is a different colour from BOTH of the currently active scored cards colour
                            if (CPU_CurrentHand_Matrix_Storage[index_3, 4] != CPU_ScoredCards_CardType_Colour[index_1] &&
                                CPU_CurrentHand_Matrix_Storage[index_3, 4] != CPU_ScoredCards_CardType_Colour[index_2])
                            {
                                AI_Behaviour.submitButton.subButtonClicked = false;

                                // choose current card (index_3) as card to play for the round
                                AI_Behaviour.EnemySelection = AI_Behaviour.deck.enemyHand[index_3];

                                //set the chosen card to the parent of the dropzone object
                                AI_Behaviour.EnemySelection.transform.SetParent(AI_Behaviour.EnemyDropSection.transform, false);
                                AI_Behaviour.deck.enemyHand.Remove(AI_Behaviour.EnemySelection); //Removes selected card from the list of cards in the CPU's hand

                                //end Function here if a valid card was chosen
                                AI_Behaviour.AIPlayed = true;

                                AI_Behaviour.deck.CardBack_ReduceSize();
                                return;
                            }
                        }
                    }
                }
            }
        }

    } // End of SingleCardType_WinCon_Check Function



    // A secondary function to house the Win Con checks that will check for 3 different colours
    // from each of the scored Card Types
    public void DoubleCardType_WinCon_Check(int FirstCardType_ScoredCardZone_ChildCount,
                                            List<string> FirstCardType_ScoredCards_CardType_Colour,
                                            int SecondCardType_ScoredCardZone_ChildCount,
                                            List<string> SecondCardType_ScoredCards_CardType_Colour,
                                            GameObject EnemySelection, 
                                            string DesiredCardType)
    {
        //string DesiredCardType = DesiredCardType_Check(FirstCardType_ScoredCards_CardType_Colour, SecondCardType_ScoredCards_CardType_Colour);

        // Run IF, there at least 1, scored cardc in the Attack and Defence scoring zones.
        if (FirstCardType_ScoredCardZone_ChildCount > 0 && SecondCardType_ScoredCardZone_ChildCount > 0)
        {
            // Going through the Attack scored Cards
            for (int First_index = 0; First_index < FirstCardType_ScoredCardZone_ChildCount; First_index++)
            {

                // Going through the Defence scored Cards
                for (int Second_index = 0; Second_index < SecondCardType_ScoredCardZone_ChildCount; Second_index++)
                {

                    //ALL USING THE SCORED CARDS NAME (A.K.A. The scored colour)
                    //If Scored_Card[Attack] and Scored_Card[Defence] are different
                    if (FirstCardType_ScoredCards_CardType_Colour[First_index] != SecondCardType_ScoredCards_CardType_Colour[Second_index])
                    {
                        // Search through the CPU's cards in their hand
                        for (int Hand_Index = 0; Hand_Index < HandSize; Hand_Index++)
                        {
                            // Row, Column
                            //if current card from CPU hand is the same as the DesiredCardType
                            // AND a different colour from BOTH of the currently active scored cards' colour
                            if ((CPU_CurrentHand_Matrix_Storage[Hand_Index, 0] == DesiredCardType)
                                &&
                                (CPU_CurrentHand_Matrix_Storage[Hand_Index, 4] != FirstCardType_ScoredCards_CardType_Colour[First_index] &&
                                 CPU_CurrentHand_Matrix_Storage[Hand_Index, 4] != SecondCardType_ScoredCards_CardType_Colour[Second_index]))
                            {
                                AI_Behaviour.submitButton.subButtonClicked = false;

                                // choose current card (index_3) as card to play for the round
                                AI_Behaviour.EnemySelection = AI_Behaviour.deck.enemyHand[Hand_Index];

                                //set the chosen card to the parent of the dropzone object
                                AI_Behaviour.EnemySelection.transform.SetParent(AI_Behaviour.EnemyDropSection.transform, false);
                                AI_Behaviour.deck.enemyHand.Remove(AI_Behaviour.EnemySelection); //Removes selected card from the list of cards in the CPU's hand

                                //end Function here if a valid card was chosen
                                AI_Behaviour.AIPlayed = true;

                                AI_Behaviour.deck.CardBack_ReduceSize();
                                return;
                            }


                        }
                    }
                }
            }
        }
    }


    // A secondary function to house the Win Con checker that will get the AI to play a card that will directly counter
    // the players ability to fulfill Win Condition
    public void Defensive_DoubleCardType_WinCon_Check(int FirstCardType_ScoredCardZone_ChildCount,
                                            List<string> FirstCardType_ScoredCards_CardType_Colour,
                                            int SecondCardType_ScoredCardZone_ChildCount,
                                            List<string> SecondCardType_ScoredCards_CardType_Colour,
                                            GameObject EnemySelection,
                                            string DesiredCardType)
    {
        //string DesiredCardType = DesiredCardType_Check(FirstCardType_ScoredCards_CardType_Colour, SecondCardType_ScoredCards_CardType_Colour);

        // Run IF, there at least 1, scored cardc in the Attack and Defence scoring zones.
        if (FirstCardType_ScoredCardZone_ChildCount > 0 && SecondCardType_ScoredCardZone_ChildCount > 0)
        {
            // Going through the Attack scored Cards
            for (int First_index = 0; First_index < FirstCardType_ScoredCardZone_ChildCount; First_index++)
            {

                // Going through the Defence scored Cards
                for (int Second_index = 0; Second_index < SecondCardType_ScoredCardZone_ChildCount; Second_index++)
                {

                    //ALL USING THE SCORED CARDS NAME (A.K.A. The scored colour)
                    //If Scored_Card[Attack] and Scored_Card[Defence] are different
                    if (FirstCardType_ScoredCards_CardType_Colour[First_index] != SecondCardType_ScoredCards_CardType_Colour[Second_index])
                    {
                        // Search through the CPU's cards in their hand
                        for (int Hand_Index = 0; Hand_Index < HandSize; Hand_Index++)
                        {
                            // Row, Column
                            //If current selected card from CPU's hand is of the Desired Card Type, then play said card
                            if (CPU_CurrentHand_Matrix_Storage[Hand_Index, 0] == DesiredCardType)
                            {
                                AI_Behaviour.submitButton.subButtonClicked = false;

                                // choose current card (index_3) as card to play for the round
                                AI_Behaviour.EnemySelection = AI_Behaviour.deck.enemyHand[Hand_Index];

                                //set the chosen card to the parent of the dropzone object
                                AI_Behaviour.EnemySelection.transform.SetParent(AI_Behaviour.EnemyDropSection.transform, false);
                                AI_Behaviour.deck.enemyHand.Remove(AI_Behaviour.EnemySelection); //Removes selected card from the list of cards in the CPU's hand

                                //end Function here if a valid card was chosen
                                AI_Behaviour.AIPlayed = true;

                                AI_Behaviour.deck.CardBack_ReduceSize();
                                return;
                            }


                        }
                    }
                }
            }
        }
    }

} // End of CPU_AI Class
