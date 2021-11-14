using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Deck : MonoBehaviour
{
    //

    // lists holding which type of cards there are 
    public List<GameObject> AttackCards;
    public List<GameObject> DefenceCards;
    public List<GameObject> GuardBCards;

    public GameObject PlayerOneHandSection;
    public GameObject PlayerOneDropZone;

    public GameObject ClickToDraw;
    public GameObject ClickToBoardWipe;

    public GameObject EnemyArea;
    public GameObject CardBack;
    public GameObject CardBackArea;
    public int HandSize = 0;

    const int MAX_HandSize = 5;

    List<GameObject> cards = new List<GameObject>();
    public List<GameObject> playerHand;
    public List<GameObject> enemyHand;
    public List<GameObject> enemyCardBackList;

    public AudioSource shuffleSounds; 

    Debugging Debug_Output;
    public EndScreen_Display Display_EndScreen;
    public NextTurn nxt_Turn;
    public Game game;
    public Bank bank;

    void Start()
    {
        //HandSize = PlayerOneSection.transform.childCount;

        // adds the type of cards to the cards list
        cards.AddRange(AttackCards);
        cards.AddRange(DefenceCards);
        cards.AddRange(GuardBCards);


    }

    private void Update()
    {
        HandSize = PlayerOneHandSection.transform.childCount;

        if (game.NextTurn_Ready == true)
        {
            if (bank.PlayerHasWon)
            {
                Display_EndScreen.DisplayWinScreen();
            }
            else if (bank.PlayerHasLost)
            {
                Display_EndScreen.DisplayLoseScreen();
            }

            ClickToBoardWipe.SetActive(true);
            ClickToDraw.SetActive(false);
        }
        else
        {
            ClickToBoardWipe.SetActive(false);
            ClickToDraw.SetActive(true);

        }
    }

    public void OnClick()
    {
        //resets the board
        if (game.NextTurn_Ready == true)
        {
            game.NextTurn_Ready = false;
            bank.DestroyCards();
        }
        shuffleSounds.Play(); 
        DrawCards();

    }

    public void DrawCards()
    {
        

        // 
        if (HandSize < MAX_HandSize && PlayerOneDropZone.transform.childCount == 0)
        {
            for (int i = HandSize; i < MAX_HandSize; i++)
            {
                GameObject playerCard = Instantiate(cards[Random.Range(0, cards.Count)], new Vector3(0, 0, 0), Quaternion.identity);
                playerCard.name = playerCard.name.Replace("(Clone)", "").Trim();
                playerCard.transform.SetParent(PlayerOneHandSection.transform, false);

                playerHand.Add(playerCard);


                GameObject enemyCard = Instantiate(cards[Random.Range(0, cards.Count)], new Vector3(0, 0, 0), Quaternion.identity);
                enemyCard.name = enemyCard.name.Replace("(Clone)", "").Trim();
                enemyCard.transform.SetParent(EnemyArea.transform, false);

                enemyHand.Add(enemyCard);


                GameObject enemyCardB = Instantiate(CardBack, new Vector3(0, 0, 0), Quaternion.identity);
                enemyCardB.transform.SetParent(CardBackArea.transform, false);

                enemyCardBackList.Add(enemyCardB);
            }

            // will allow the players to move their cards again
            nxt_Turn.StopBlocking();
        }



    }

    public void CardBack_ReduceSize()
    {
        GameObject.Destroy(enemyCardBackList[0]);
        enemyCardBackList.RemoveAt(0);
    }


}
