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

    public GameObject Card_A_12_RED;
    public GameObject Card_A_11_RED;
    public GameObject PlayerOneSection;
    public GameObject EnemyArea;
    public int HandSize = 0;
    const int MAX_HandSize = 5;

    List<GameObject> cards = new List<GameObject>();

    void Start()
    {
        cards.Add(Card_A_12_RED);
        cards.Add(Card_A_11_RED);
    }
    public void OnClick()
    {
        while (HandSize < MAX_HandSize)
        {
            GameObject playerCard = Instantiate(cards[Random.Range(0, cards.Count)], new Vector3(0, 0, 0), Quaternion.identity);
            playerCard.transform.SetParent(PlayerOneSection.transform, false);

            GameObject enemyCard = Instantiate(cards[Random.Range(0, cards.Count)], new Vector3(0, 0, 0), Quaternion.identity);
            enemyCard.transform.SetParent(EnemyArea.transform, false);

            HandSize++;
        }

    }

   



    /*
        public Deck()
        {
            deck = new List<Card>();
            CreateCards();
        }
        public void CreateCards()
        {
            Card card;
            for (int value = 2; value <= 12; value++)
            {
                for (int element = FIRE; element <= SNOW; element++)
                {
                    for (int color = RED; color <= PURPLE; color++)
                    {
                        //int color = rand.nextInt(PURPLE + 1);
                        card = new Card(element, value, color);

                        //will print out a complete list of all possiable card combinations
                        //Debug.Log(card.outputAsString());
                        deck.Add(card);
                        //Debug.Log();
                    }
                }
            }


            //shuffle();
        }
        public List<Card> GetCards()
        {
            return deck;
        }
        public Card Deal()
        {
            Card card = deck[0];
            deck.RemoveAt(0);
            //if deck is empty
            if (deck.Count == 0)
            {
                CreateCards();
            }
            return card;
        }
      */
}
