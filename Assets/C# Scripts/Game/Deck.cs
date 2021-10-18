using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Deck : MonoBehaviour
{
    /* 
     //holds the different card elements/types
     public static int FIRE = 0;
     public static int WATER = 1;
     public static int SNOW = 2;

     //holds the different card categories/colours

     public static int RED = 0;
     public static int ORANGE = 1;
     public static int YELLOW = 2;
     public static int GREEN = 3;
     public static int BLUE = 4;
     public static int PURPLE = 5;

     //private List<Card> deck;
     //public int rand;
     ////rand = new Random.State();

     ////int rand = new Random();
     */

    /*
    public GameObject Card_A_12_
    public GameObject Card_A_11_
    public GameObject Card_A_10_
    public GameObject Card_A_9_
    public GameObject Card_A_8_
    public GameObject Card_A_7_
    public GameObject Card_A_6_
    public GameObject Card_A_5_
    public GameObject Card_A_4_
    public GameObject Card_A_3_
    public GameObject Card_A_2_
    */

    // lists holding which type of cards there are 
    public List<GameObject> AttackCards;
    public List<GameObject> DefenceCards;
    public List<GameObject> GuardBCards;

    //public List<GameObject> AttackBlueCards;
    //public List<GameObject> AttackGreenCards;
    //public List<GameObject> AttackOrangeCards;
    //public List<GameObject> AttackPurpleCards;
    //public List<GameObject> AttackRedCards;
    //public List<GameObject> AttackYellowCards;

    //public List<GameObject> DefenceBlueCards;
    //public List<GameObject> DefenceGreenCards;
    //public List<GameObject> DefenceOrangeCards;
    //public List<GameObject> DefencePurpleCards;   
    //public List<GameObject> DefenceRedCards;
    //public List<GameObject> DefenceYellowCards;

    //public List<GameObject> GuardBBlueCards;
    //public List<GameObject> GuardBGreenCards;
    //public List<GameObject> GuardBOrangeCards;
    //public List<GameObject> GuardBPurpleCards;
    //public List<GameObject> GuardBRedCards;
    //public List<GameObject> GuardBYellowCards;

    //public GameObject Card_A_12_BLUE;
    //public GameObject Card_A_11_BLUE;
    //public GameObject Card_A_10_BLUE;
    //public GameObject Card_A_9_BLUE;
    //public GameObject Card_A_8_BLUE;
    //public GameObject Card_A_7_BLUE;
    //public GameObject Card_A_6_BLUE;
    //public GameObject Card_A_5_BLUE;
    //public GameObject Card_A_4_BLUE;
    //public GameObject Card_A_3_BLUE;
    //public GameObject Card_A_2_BLUE;

    //public GameObject Card_A_12_GREEN;
    //public GameObject Card_A_11_GREEN;
    //public GameObject Card_A_10_GREEN;
    //public GameObject Card_A_9_GREEN;
    //public GameObject Card_A_8_GREEN;
    //public GameObject Card_A_7_GREEN;
    //public GameObject Card_A_6_GREEN;
    //public GameObject Card_A_5_GREEN;
    //public GameObject Card_A_4_GREEN;
    //public GameObject Card_A_3_GREEN;
    //public GameObject Card_A_2_GREEN;

    //public GameObject Card_A_12_ORANGE;
    //public GameObject Card_A_11_ORANGE;
    //public GameObject Card_A_10_ORANGE;
    //public GameObject Card_A_9_ORANGE;
    //public GameObject Card_A_8_ORANGE;
    //public GameObject Card_A_7_ORANGE;
    //public GameObject Card_A_6_ORANGE;
    //public GameObject Card_A_5_ORANGE;
    //public GameObject Card_A_4_ORANGE;
    //public GameObject Card_A_3_ORANGE;
    //public GameObject Card_A_2_ORANGE;

    //public GameObject Card_A_12_PURPLE;
    //public GameObject Card_A_11_PURPLE;
    //public GameObject Card_A_10_PURPLE;
    //public GameObject Card_A_9_PURPLE;
    //public GameObject Card_A_8_PURPLE;
    //public GameObject Card_A_7_PURPLE;
    //public GameObject Card_A_6_PURPLE;
    //public GameObject Card_A_5_PURPLE;
    //public GameObject Card_A_4_PURPLE;
    //public GameObject Card_A_3_PURPLE;
    //public GameObject Card_A_2_PURPLE;

    //public GameObject Card_A_12_RED;
    //public GameObject Card_A_11_RED;
    //public GameObject Card_A_10_RED;
    //public GameObject Card_A_9_RED;
    //public GameObject Card_A_8_RED;
    //public GameObject Card_A_7_RED;
    //public GameObject Card_A_6_RED;
    //public GameObject Card_A_5_RED;
    //public GameObject Card_A_4_RED;
    //public GameObject Card_A_3_RED;
    //public GameObject Card_A_2_RED;

    //public GameObject Card_A_12_YELLOW;
    //public GameObject Card_A_11_YELLOW;
    //public GameObject Card_A_10_YELLOW;
    //public GameObject Card_A_9_YELLOW;
    //public GameObject Card_A_8_YELLOW;
    //public GameObject Card_A_7_YELLOW;
    //public GameObject Card_A_6_YELLOW;
    //public GameObject Card_A_5_YELLOW;
    //public GameObject Card_A_4_YELLOW;
    //public GameObject Card_A_3_YELLOW;
    //public GameObject Card_A_2_YELLOW;

    public GameObject PlayerOneSection;
    public GameObject EnemyArea;
    public int HandSize = 0;
    const int MAX_HandSize = 5;

    List<GameObject> cards = new List<GameObject>();
    public List<GameObject> playerHand;
    public List<GameObject> enemyHand; 

    void Start()
    {

        // adds the type of cards to the cards list
        cards.AddRange(AttackCards);
        cards.AddRange(DefenceCards);
        cards.AddRange(GuardBCards);

    }


    public void OnClick()
    {
        while (HandSize < MAX_HandSize)
        {
            GameObject playerCard = Instantiate(cards[Random.Range(0, cards.Count)], new Vector3(0, 0, 0), Quaternion.identity);
            playerCard.transform.SetParent(PlayerOneSection.transform, false);

            playerHand.Add(playerCard);

            GameObject enemyCard = Instantiate(cards[Random.Range(0, cards.Count)], new Vector3(0, 0, 0), Quaternion.identity);
            enemyCard.transform.SetParent(EnemyArea.transform, false);

            enemyHand.Add(enemyCard);

            HandSize++;
        }

    }
}
