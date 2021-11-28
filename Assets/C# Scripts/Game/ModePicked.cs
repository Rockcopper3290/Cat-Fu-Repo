using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModePicked : MonoBehaviour
{

    public static bool smartAIEnabled; 
  
    public void EasyMode(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        smartAIEnabled = false;
    }

    public void HardMode(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        smartAIEnabled = true;
    }

}
