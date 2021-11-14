using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Banks all the scored cards from both players
public class Bank : MonoBehaviour
{
    public bool PlayerHasWon;
    public bool PlayerHasLost;

    public List<GameObject> AttackIcons;
    public List<GameObject> DefenceIcons;
    public List<GameObject> GuardBreakIcons;

    List<GameObject> Player_Attack_ScoredCards = new List<GameObject>();
    List<GameObject> Player_Defend_ScoredCards = new List<GameObject>();
    List<GameObject> Player_GuardBreak_ScoredCards = new List<GameObject>();

    public GameObject Player_AttackIcons_Location;
    public GameObject Player_DefenceIcons_Location;
    public GameObject Player_GuardBreakIcons_Location;

    public GameObject CPU_AttackIcons_Location;
    public GameObject CPU_DefenceIcons_Location;
    public GameObject CPU_GuardBreakIcons_Location;


    List<GameObject> CPU_Attack_ScoredCards = new List<GameObject>();
    List<GameObject> CPU_Defend_ScoredCards = new List<GameObject>();
    List<GameObject> CPU_GuardBreak_ScoredCards = new List<GameObject>();

    public Game game;
    public void ScoreCards(string CardType, string CardColour, bool DidPlayerWin)
    {
        Get_CardColour(CardType, CardColour, DidPlayerWin);
    }
    public void GameTied()
    {
        // What happens here...
        // NOTHING because I can't be bothered to put in a special message for
        // when the cpu and player tie
    }
    public void DestroyCards()
    {
        Destroy(game.submitButton.PlayerSelection);
        Destroy(game.AI_Behaviour.EnemySelection);
    }
    public void Get_CardColour(string CardType, string CardColour, bool DidPlayerWin)
    {
        int CardColour_Index;

        if (CardColour == "Blue")
        {
            CardColour_Index = 0;
            Get_CardType(CardType, CardColour_Index, DidPlayerWin);
        }
        else if (CardColour == "Green")
        {
            CardColour_Index = 1;
            Get_CardType(CardType, CardColour_Index, DidPlayerWin);
        }
        else if (CardColour == "Orange")
        {
            CardColour_Index = 2;
            Get_CardType(CardType, CardColour_Index, DidPlayerWin);
        }
        else if (CardColour == "Purple")
        {
            CardColour_Index = 3;
            Get_CardType(CardType, CardColour_Index, DidPlayerWin);
        }
        else if (CardColour == "Red")
        {
            CardColour_Index = 4;
            Get_CardType(CardType, CardColour_Index, DidPlayerWin);
        }
        else if (CardColour == "Yellow")
        {
            CardColour_Index = 5;
            Get_CardType(CardType, CardColour_Index, DidPlayerWin);
        }
    }
    public void Get_CardType(string CardType, int CardColour_Index, bool DidPlayerWin) 
    {
        if (DidPlayerWin)
        {
            if (CardType == "Attack")
            {
                GameObject CardIcon = Instantiate(AttackIcons[CardColour_Index], new Vector3(0, 0, 0), Quaternion.identity);
                CardIcon.name = CardIcon.name.Replace("(Clone)", "").Trim();
                CardIcon.name = CardIcon.name.Replace("IconA", "").Trim();
                CardIcon.transform.SetParent(Player_AttackIcons_Location.transform, false);

                Player_Attack_ScoredCards.Add(CardIcon);
            }
            else if (CardType == "Defend")
            {
                GameObject CardIcon = Instantiate(DefenceIcons[CardColour_Index], new Vector3(0, 0, 0), Quaternion.identity);
                CardIcon.name = CardIcon.name.Replace("(Clone)", "").Trim();
                CardIcon.name = CardIcon.name.Replace("IconD", "").Trim();
                CardIcon.transform.SetParent(Player_DefenceIcons_Location.transform, false);

                Player_Defend_ScoredCards.Add(CardIcon);
            }
            else if (CardType == "Guard Break")
            {
                GameObject CardIcon = Instantiate(GuardBreakIcons[CardColour_Index], new Vector3(0, 0, 0), Quaternion.identity);
                CardIcon.name = CardIcon.name.Replace("(Clone)", "").Trim();
                CardIcon.name = CardIcon.name.Replace("IconGB", "").Trim();
                CardIcon.transform.SetParent(Player_GuardBreakIcons_Location.transform, false);

                Player_GuardBreak_ScoredCards.Add(CardIcon);
            }
            // Checks if the player meets a win con after every time they score a card
            WinCondition_Check_Player();
        }
        else if (!DidPlayerWin)
        {
            if (CardType == "Attack")
            {
                GameObject CardIcon = Instantiate(AttackIcons[CardColour_Index], new Vector3(0, 0, 0), Quaternion.identity);
                CardIcon.name = CardIcon.name.Replace("(Clone)", "").Trim();
                CardIcon.name = CardIcon.name.Replace("IconA", "").Trim();
                CardIcon.transform.SetParent(CPU_AttackIcons_Location.transform, false);

                CPU_Attack_ScoredCards.Add(CardIcon);
            }
            else if (CardType == "Defend")
            {
                GameObject CardIcon = Instantiate(DefenceIcons[CardColour_Index], new Vector3(0, 0, 0), Quaternion.identity);
                CardIcon.name = CardIcon.name.Replace("(Clone)", "").Trim();
                CardIcon.name = CardIcon.name.Replace("IconD", "").Trim();
                CardIcon.transform.SetParent(CPU_DefenceIcons_Location.transform, false);

                CPU_Defend_ScoredCards.Add(CardIcon);
            }
            else if (CardType == "Guard Break")
            {
                GameObject CardIcon = Instantiate(GuardBreakIcons[CardColour_Index], new Vector3(0, 0, 0), Quaternion.identity);
                CardIcon.name = CardIcon.name.Replace("(Clone)", "").Trim();
                CardIcon.name = CardIcon.name.Replace("IconGB", "").Trim();
                CardIcon.transform.SetParent(CPU_GuardBreakIcons_Location.transform, false);

                CPU_GuardBreak_ScoredCards.Add(CardIcon);
            }

            // Checks if the CPU meets a win con after every time they score a card
            WinCondition_Check_CPU();
        }
        
    }
    public void WinCondition_Check_Player()
    {
        bool WasWinConditionFulfilled = false;
        // check if there is at least one colour of each card type
        for (int i = 0; i < Player_Attack_ScoredCards.Count; i++)
        {
            string AttackCardName = Player_Attack_ScoredCards[i].name;

            for (int j = 0; j < Player_Defend_ScoredCards.Count; j++)
            {
            string DefenceCardName = Player_Defend_ScoredCards[j].name;

                for (int k = 0; k < Player_GuardBreak_ScoredCards.Count; k++)
                {
                    string GuardBreakCardName = Player_GuardBreak_ScoredCards[k].name;

                    if (AttackCardName != DefenceCardName && DefenceCardName != GuardBreakCardName && GuardBreakCardName != AttackCardName)
                    {
                        WasWinConditionFulfilled = true;
                    }
                }
            }
        }

        //will check each card from the same type for 3 different colours
        if (!WasWinConditionFulfilled)
        {
            if (Player_Attack_ScoredCards.Count >= 3)
            {
                for (int i = 0; i < Player_Attack_ScoredCards.Count; i++)
                {
                    string FirstCard = Player_Attack_ScoredCards[i].name;

                    for (int j = 0; j < Player_Attack_ScoredCards.Count; j++)
                    {
                        string SecondCard = Player_Attack_ScoredCards[j].name;

                        for (int k = 0; k < Player_Attack_ScoredCards.Count; k++)
                        {
                            string ThirdCard = Player_Attack_ScoredCards[k].name;

                            if (FirstCard != SecondCard && SecondCard != ThirdCard && ThirdCard != FirstCard)
                            {
                                WasWinConditionFulfilled = true;
                            }
                        }
                    }
                }
            }
            if (Player_Defend_ScoredCards.Count >= 3)
            {
                for (int i = 0; i < Player_Defend_ScoredCards.Count; i++)
                {
                    string FirstCard = Player_Defend_ScoredCards[i].name;

                    for (int j = 0; j < Player_Defend_ScoredCards.Count; j++)
                    {
                        string SecondCard = Player_Defend_ScoredCards[j].name;

                        for (int k = 0; k < Player_Defend_ScoredCards.Count; k++)
                        {
                            string ThirdCard = Player_Defend_ScoredCards[k].name;

                            if (FirstCard != SecondCard && SecondCard != ThirdCard && ThirdCard != FirstCard)
                            {
                                WasWinConditionFulfilled = true;
                            }
                        }
                    }
                }
            }
            if (Player_GuardBreak_ScoredCards.Count >= 3)
            {
                for (int i = 0; i < Player_GuardBreak_ScoredCards.Count; i++)
                {
                    string FirstCard = Player_GuardBreak_ScoredCards[i].name;

                    for (int j = 0; j < Player_GuardBreak_ScoredCards.Count; j++)
                    {
                        string SecondCard = Player_GuardBreak_ScoredCards[j].name;

                        for (int k = 0; k < Player_GuardBreak_ScoredCards.Count; k++)
                        {
                            string ThirdCard = Player_GuardBreak_ScoredCards[k].name;

                            if (FirstCard != SecondCard && SecondCard != ThirdCard && ThirdCard != FirstCard)
                            {
                                WasWinConditionFulfilled = true;
                            }
                        }
                    }
                }
            }
        }

        if (WasWinConditionFulfilled)
        {
            PlayerHasWon = true;
            Debug.Log("PLAYER WON THE GAME");
        }
        
    }
    public void WinCondition_Check_CPU()
    {
        bool WasWinConditionFulfilled = false;
        // check if there is at least one colour of each card type
        for (int i = 0; i < CPU_Attack_ScoredCards.Count; i++)
        {
            string AttackCardName = CPU_Attack_ScoredCards[i].name;

            for (int j = 0; j < CPU_Defend_ScoredCards.Count; j++)
            {
                string DefenceCardName = CPU_Defend_ScoredCards[j].name;

                for (int k = 0; k < CPU_GuardBreak_ScoredCards.Count; k++)
                {
                    string GuardBreakCardName = CPU_GuardBreak_ScoredCards[k].name;

                    if (AttackCardName != DefenceCardName && DefenceCardName != GuardBreakCardName && GuardBreakCardName != AttackCardName)
                    {
                        WasWinConditionFulfilled = true;
                    }
                }
            }
        }

        //will check each card from the same type for 3 different colours
        if (!WasWinConditionFulfilled)
        {
            if (CPU_Attack_ScoredCards.Count >= 3)
            {
                for (int i = 0; i < CPU_Attack_ScoredCards.Count; i++)
                {
                    string FirstCard = CPU_Attack_ScoredCards[i].name;

                    for (int j = 0; j < CPU_Attack_ScoredCards.Count; j++)
                    {
                        string SecondCard = CPU_Attack_ScoredCards[j].name;

                        for (int k = 0; k < CPU_Attack_ScoredCards.Count; k++)
                        {
                            string ThirdCard = CPU_Attack_ScoredCards[k].name;

                            if (FirstCard != SecondCard && SecondCard != ThirdCard && ThirdCard != FirstCard)
                            {
                                WasWinConditionFulfilled = true;
                            }
                        }
                    }
                }
            }
            if (CPU_Defend_ScoredCards.Count >= 3)
            {
                for (int i = 0; i < CPU_Defend_ScoredCards.Count; i++)
                {
                    string FirstCard = CPU_Defend_ScoredCards[i].name;

                    for (int j = 0; j < CPU_Defend_ScoredCards.Count; j++)
                    {
                        string SecondCard = CPU_Defend_ScoredCards[j].name;

                        for (int k = 0; k < CPU_Defend_ScoredCards.Count; k++)
                        {
                            string ThirdCard = CPU_Defend_ScoredCards[k].name;

                            if (FirstCard != SecondCard && SecondCard != ThirdCard && ThirdCard != FirstCard)
                            {
                                WasWinConditionFulfilled = true;
                            }
                        }
                    }
                }
            }
            if (CPU_GuardBreak_ScoredCards.Count >= 3)
            {
                for (int i = 0; i < CPU_GuardBreak_ScoredCards.Count; i++)
                {
                    string FirstCard = CPU_GuardBreak_ScoredCards[i].name;

                    for (int j = 0; j < CPU_GuardBreak_ScoredCards.Count; j++)
                    {
                        string SecondCard = CPU_GuardBreak_ScoredCards[j].name;

                        for (int k = 0; k < CPU_GuardBreak_ScoredCards.Count; k++)
                        {
                            string ThirdCard = CPU_GuardBreak_ScoredCards[k].name;

                            if (FirstCard != SecondCard && SecondCard != ThirdCard && ThirdCard != FirstCard)
                            {
                                WasWinConditionFulfilled = true;
                            }
                        }
                    }
                }
            }
        }

        if (WasWinConditionFulfilled)
        {
            PlayerHasLost = true;
            Debug.Log("CPU WON THE GAME");
        }
    }


}
