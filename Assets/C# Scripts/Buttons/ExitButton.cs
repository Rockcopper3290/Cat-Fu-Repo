// Layla Darwiche 
// GPR103 
// Assessment 4 - Game Project
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// --------- QUITTING THE GAME ----------

public class ExitButton : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game was exited"); // for checking
    }
}
