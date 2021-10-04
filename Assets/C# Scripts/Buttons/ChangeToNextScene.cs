// Layla Darwiche 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// -------- SIMPLE SCENE CHANGE USED FOR BUTTONS --------

public class ChangeToNextScene : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName); // load the level name given
    }

}
