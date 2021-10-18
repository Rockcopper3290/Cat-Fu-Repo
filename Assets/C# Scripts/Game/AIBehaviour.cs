using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class AIBehaviour : MonoBehaviour
{
    public GameObject EnemyDropSection;



    static public GameObject EnemySelection;



    public bool AIPlayed = false; 
    public Submit_Button submitButton;
    public Deck deck;
    //public Game game;
    // Update is called once per frame
    public void Update()
    {

            // check if the player has pressed the submit button, 
            if (submitButton.subButtonClicked == true)
            {
                // if so then play the random card

                int randomCard;
                randomCard = Random.Range(0, deck.enemyHand.Count);

                EnemySelection = deck.enemyHand[randomCard];
                Debug.Log("Random Card Selected");
                EnemySelection.transform.SetParent(EnemyDropSection.transform, false); // set the card to the parent of the dropzone object
                                                                                       //EnemySelection = GameObject.Find(gameObject.name); 
                submitButton.subButtonClicked = false;

                //deck.enemyHand.Remove(EnemySelection);
                deck.enemyHand.RemoveAt(randomCard);

                
                
                GameObject CPU_CardInPlay = EnemySelection;
                if (CPU_CardInPlay)
                {
                    //CPU_CardInPlay.name += "(Clone)";
                    //Destroy(CPU_CardInPlay.gameObject);

                    Debug.Log(name + "has been destroyed.");
                }

                
                Debug.Log("Random Card Deleted in list");

            }

        // when played allow the player to pick a new card to play 

    }
}
