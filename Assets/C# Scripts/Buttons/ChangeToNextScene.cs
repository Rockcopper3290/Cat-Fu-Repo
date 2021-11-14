// Layla Darwiche 
// & Matthew
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// -------- SIMPLE SCENE CHANGE USED FOR BUTTONS --------

public class ChangeToNextScene : MonoBehaviour
{
    public AudioSource buttonClickSound;

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName); // load the level name given
        buttonClickSound.Play(); 
    }

    public void PlayAgain (string sceneName)
    {
        SceneManager.LoadScene(sceneName); // load the level name given
        buttonClickSound.Play();
    }
    public void ReturnToMenu(string sceneName)
    {
        SceneManager.LoadScene(sceneName); // load the level name given
        buttonClickSound.Play();
    }
}
