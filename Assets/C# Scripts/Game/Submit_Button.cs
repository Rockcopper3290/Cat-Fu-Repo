using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Submit_Button : MonoBehaviour
{

    // Check if there are any cards in the playspace
    // if there is make sure that there is only one card ( if < 1 stop player from submitting the card)
    public GameObject PlayerBoard;
    public GameObject BlockPlayerPlay;

    public GameObject PlayerSelection;
    public GameObject PlayerDropSection;

    public Deck deck;
    public Game game;
    public NextTurn nxt_Turn;


    //public AIBehaviour AI_Behaviour;
    //public DragDrop dragDrop;

    //used as a flag to make sure that the program knows that the player has taken their turn
    public bool subButtonClicked;

    public AudioSource wrongAmountSound; 
    private Card CurrentCard;


    public void OnClick_PlayerSubmitCard ()
    {
        //Here we are checking to see if the players have wiped the board.
        //code for board wipe can be found in GAME but is used/reset in DECK
        if (game.NextTurn_Ready == false)
        {
            // if the player has pressed the submit button but either has more 
            // then 1 cards in the play space or 0 cards in the play space
            if (PlayerBoard.transform.childCount > 1 || PlayerBoard.transform.childCount < 1)
            {
                //TODO: output error message to the board so that the players can see it
                //Debug.Log("!! Please enter the correct amount of cards !!");
                wrongAmountSound.Play(); 
            }
            else
            {
                //TODO: lock player from interfering with their cards
                //Debug.Log("!! Please wait till the CPU has made their turn !!");

                PlayerSelection = PlayerBoard.transform.GetChild(0).gameObject;

                deck.playerHand.Remove(PlayerSelection);


                //BlockPlayerPlay.SetActive(true);
                //AI_Behaviour.Update();
                //playerHand.playerHand.Remove()

                nxt_Turn.StartBlocking();

                //used as a flag to make sure that the program knows that the player has taken their turn
                subButtonClicked = true;
            }
        }
        
    }
}
