using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    //card class holds the element/type, value/power and a colour


    //holds the different card elements/types
    public

    //holds the different card categories/colours
    public enum cardColour
    {
        RED,
        ORANGE,
        YELLOW,
        GREEN,
        BLUE,
        PURPLE
    }

    static string[] elements = { "fire", "water", "snow" };
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
}

