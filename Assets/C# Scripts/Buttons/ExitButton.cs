// Layla Darwiche 
// GPR103 
// Assessment 4 - Game Project
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// --------- QUITTING THE GAME ----------

public class ExitButton : MonoBehaviour
{
    public AudioSource buttonClickSound;

    public void ExitGame()
    {
        buttonClickSound.Play();
        Application.Quit();
        Debug.Log("Game was exited"); // for checking
    }
}
