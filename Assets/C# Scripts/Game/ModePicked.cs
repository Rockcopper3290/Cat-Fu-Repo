using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModePicked : MonoBehaviour
{

    public static bool smartAIEnabled; 
  
    public void EasyMode(string sceneName)
    {
        smartAIEnabled = false;
        SceneManager.LoadScene(sceneName);
    }

    public void HardMode(string sceneName)
    {
        smartAIEnabled = true;
        SceneManager.LoadScene(sceneName);
    }

}
