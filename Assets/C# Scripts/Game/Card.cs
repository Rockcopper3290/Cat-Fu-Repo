using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    //card class holds the element/type, value/power and a colour

    //holds the different card elements/types
    public static int ATTACK = 0;
    public static int DEFEND = 1;
    public static int GUARDBREAK = 2;

    //holds the different card categories/colours
    public static int BLUE = 0;
    public static int GREEN = 1;
    public static int ORANGE = 2;
    public static int PURPLE = 3;
    public static int RED = 4;
    public static int YELLOW = 5;


    string CardType;
    static string[] elements = { "attack", "defend", "guardbreak" };
    static string[] colors = { "Blue", "Green", "Orange", "Purple", "Red", "Yellow" };

    int element;
    int value;
    int color;

    public List <int> GenerateNewCard(char element, int value, string color)
    {
        //List<int> cardValuesList;

        asignElement(element);
        
        return null;
    }

    public int getElement()
    {
        return element;
    }
    public string asignElement(char element)
    {
        if (element == 'A')
        {
            CardType = elements[0];
        }
        else if (element == 'D')
        {
            CardType = elements[1];
        }
        else if (element == 'G')
        {
            CardType = elements[2];
        }

        return CardType;
    }

    public int getValue()
    {
        return value;
    }

    public int getColor()
    {
        return color;
    }


    
}

