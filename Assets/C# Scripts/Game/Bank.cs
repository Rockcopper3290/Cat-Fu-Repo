using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Banks all the scored cards from both players
public class Bank : MonoBehaviour
{
    public List<GameObject> AttackIcons;
    public List<GameObject> DefenceIcons;
    public List<GameObject> GuardBreakIcons;

    public List<GameObject> Player_AttackCards;
    public List<GameObject> Player_DefendCards;
    public List<GameObject> Player_GuardBreakCards;

    public List<GameObject> CPU_AttackCards;
    public List<GameObject> CPU_DefendCards;
    public List<GameObject> CPU_GuardBreakCards;

    public Game game;

    public void Player_ScoredCards(string CardType, string CardColour)
    {
        
    }
    public void CPU_ScoredCards(string CardType, string CardColour)
    {

    }
    public void GameTied()
    {

    }

    public void DestroyCards()
    {
        Destroy(game.submitButton.PlayerSelection);
        Destroy(game.AI_Behaviour.EnemySelection);
    }

    public void Get_CardType(string CardType, string CardColour) 
    {
        if (CardType == "Attack")
        {

        }
        else if (CardType == "Defend")
        {

        }
        else if (CardType == "Guard Break")
        {

        }
    }

    public void Get_CardColour(string CardColour)
    {
        if (CardColour == "Blue")
        {

        }
        else if (CardColour == "Green")
        {

        }
        else if (CardColour == "Orange")
        {

        }
        else if (CardColour == "Purple")
        {

        }
        else if (CardColour == "Red")
        {

        }
        else if (CardColour == "Yellow")
        {

        }
    }

}
