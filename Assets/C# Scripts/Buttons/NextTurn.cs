using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NextTurn : MonoBehaviour
{
    public Submit_Button playerChose;
    public AIBehaviour AIChose;
    //public GameObject nextTurnButton;
    public GameObject playerBlocking;
    public GameObject DeckBlocker;


    private void Update()
    {
        if (playerChose.subButtonClicked == true && AIChose.AIPlayed == true)
        {
            playerBlocking.SetActive(true);
        }
        if (!playerChose.subButtonClicked && !AIChose.AIPlayed)
        {
            playerBlocking.SetActive(false);
        }

    }
}

    /*
     public void NextTurnButton()
    {
        // disable the player blocking 
        // destroy the previously played cards and get their score 
        playerBlocking.SetActive(false); 
        // let them draw new cards 
    }


    */