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
    public static int RED = 0;
    public static int ORANGE = 1;
    public static int YELLOW = 2;
    public static int GREEN = 3;
    public static int BLUE = 4;
    public static int PURPLE = 5;


    static string[] elements = { "attack", "defend", "guardbreak" };
    static string[] colors = { "red", "orange", "yellow", "green", "blue", "purple" };

    int element;
    int value;
    int color;

    public Card(int element, int value, int color)
    {
        this.element = element;
        this.value = value;
        this.color = color;
    }

    

    public int getElement()
    {
        return element;
    }

    public int getValue()
    {
        return value;
    }

    public int getColor()
    {
        return color;
    }
    public string getElementAsString()
    {
        return elements[element];
    }

    public string getValueAsString()
    {
        return value.ToString();
    }

    public string getColorAsString()
    {
        return colors[color];
    }

    public string getArticle()
    {
        if (color == ORANGE)
        {
            return "an";
        }
        return "a";
    }

    public string outputAsString()
    {
        return getColorAsString() + " " + getElementAsString() + " card of value " + getValueAsString();
    }
    
}

