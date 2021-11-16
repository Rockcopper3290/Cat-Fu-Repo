using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class AIBehaviour : MonoBehaviour
{
    public GameObject EnemyDropSection;
    public GameObject EnemySelection;


     
    public bool isSmartAI_Enabled;
    public bool AIPlayed = false;

    public CPU_AI cpu_AI;
    public Submit_Button submitButton;
    public Deck deck;
    


    //public Game game;
    // Update is called once per frame
    public void Start()
    {
        // Will set the bool
        // True - AI function is used
        // False - A random card will be picked
        isSmartAI_Enabled = ModePicked.smartAIEnabled;
    }
    public void Update()
    {
        // check if the player has pressed the submit button, 
        if (submitButton.subButtonClicked == true)
        {
            // if Smart AI IS enabled
            // A.K.A. Hard AI mode
            if (isSmartAI_Enabled && (deck.enemyHand.Count == 5))
            {
                //run CpuAI_Main
                cpu_AI.CpuAI_Main();
                



                if (AIPlayed == false)
                {
                    PickRandomCard();
                    AIPlayed = true;

                }
            }

            // if Smart AI NOT enabled
            // A.K.A easy AI Mode
            else if (!isSmartAI_Enabled && !AIPlayed)
            {
                PickRandomCard();
                AIPlayed = true;


            }



        }
    } // END Update Function

    // Will pick a random card from the Cpu's hand to be played
    public void PickRandomCard()
    {
        // if so then play the random card from the hand.

        submitButton.subButtonClicked = false;

        int randomCard;
        //generates a random number
        randomCard = Random.Range(0, deck.enemyHand.Count);

        //The card that the CPU will play is the card that correlates to the random number
        EnemySelection = deck.enemyHand[randomCard];
        //Debug.Log("Random Card Selected");

        //set the chosen card to the parent of the dropzone object
        EnemySelection.transform.SetParent(EnemyDropSection.transform, false);
        deck.enemyHand.Remove(EnemySelection); //Removes selected card from the list of cards in the CPU's hand


        deck.CardBack_ReduceSize();
    }
}
