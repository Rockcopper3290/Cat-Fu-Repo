using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Debugging : MonoBehaviour
{
    //public string MyText;

    private int PlayerHandSize;
    private int CPUHandSize;

    public GameObject Player_HandCount;
    public GameObject CPU_HandCount;

    public Deck deck;
    public Game game;

    private TextMeshProUGUI PlayerText;
    private TextMeshProUGUI CPUText;

    private void Start()
    {
        PlayerHandSize = deck.playerHand.Count;
        CPUHandSize = deck.enemyHand.Count;

    }

    private void Update()
    {
        if (this.gameObject.name == "Debug_O_PlayerHandSize")
        {
            Update_Player_HandSize();
        }
        if (this.gameObject.name == "Debug_O_CPUHandSize")
        {
            Update_CPU_HandSize();
        }

        if (this.gameObject.name == "Debug_O_PlayerCardName")
        {
            Update_Player_CardName();
        }
        if (this.gameObject.name == "Debug_O_CPUCardName")
        {
            Update_CPU_CardName();
        }



    }

    private void Update_Player_HandSize()
    {
        PlayerHandSize = deck.playerHand.Count;


        PlayerText = GetComponent<TextMeshProUGUI>();

        //MyText = PlayerHandSize.ToString();

        PlayerText.SetText("Player Hand Size: " + PlayerHandSize.ToString());
    }
    private void Update_Player_CardName()
    {

        PlayerText = GetComponent<TextMeshProUGUI>();
        PlayerText.SetText("Player Card Name: " + game.Player_Card); 
    }

    private void Update_CPU_HandSize()
    {
        CPUHandSize = deck.enemyHand.Count;

        CPUText = GetComponent<TextMeshProUGUI>();

        //MyText = PlayerHandSize.ToString();

        CPUText.SetText("CPU Hand Size: " + CPUHandSize.ToString());
    }
    private void Update_CPU_CardName()
    {
        PlayerText = GetComponent<TextMeshProUGUI>();
        PlayerText.SetText("CPU Card Name: " + game.CPU_Card);
 
    }
}
