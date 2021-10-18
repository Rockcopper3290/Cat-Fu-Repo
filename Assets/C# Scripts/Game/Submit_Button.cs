using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Submit_Button : MonoBehaviour
{

    // Check if there are any cards in the playspace
    // if there is make sure that there is only one card ( if < 1 stop player from submitting the card)
    public GameObject PlayerBoard;
    public GameObject BlockPlayerPlay;
    
    //public AIBehaviour AI_Behaviour;
    //public DragDrop dragDrop;

    public bool subButtonClicked;
    private Card CurrentCard;
    // Hand playerHand; 

    public void OnClick_PlayerSubmitCard ()
    {
        // if the player has pressed the submit button but either has more 
        // then 1 cards in the play space or 0 cards in the play space
        if (PlayerBoard.transform.childCount > 1 || PlayerBoard.transform.childCount < 1)
        {
            //TODO: output error message to the board
            Debug.Log("!! Please enter the correct amount of cards !!");
            
        }
        else
        {
            //TODO: lock player from interfering with their cards
            Debug.Log("!! Please wait till the CPU has made their turn !!");

            GameObject PlayerSelection = PlayerBoard.transform.GetChild(0).gameObject;
            BlockPlayerPlay.SetActive(true); 
            //AI_Behaviour.Update();
            //playerHand.playerHand.Remove()
            subButtonClicked = true; 
        }
    }
}
