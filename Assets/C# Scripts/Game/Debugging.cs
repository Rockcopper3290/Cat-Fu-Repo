using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugging : MonoBehaviour
{
    public string MyText;

    public int PlayerHandSize;

    Deck deck;

    public void Update()
    {
        PlayerHandSize = deck.HandSize;

        MyText = PlayerHandSize.ToString();


        Debug.Log(MyText);
    }

}
