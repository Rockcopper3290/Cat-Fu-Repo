
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// https://answers.unity.com/questions/1260393/make-music-continue-playing-through-scenes.html
// this forum helped with figure out how to make this happen for the first section of my game since
// I didnt want it to be choppy sounding when player clicks through the options in the menu extra. 

// ---------- CONTINOUS MUSIC FUNCTIONALITY -----------

public class ContinousMusic : MonoBehaviour
{ 
    // Audio source which has the music for the game 
    public AudioSource backgroundSound;
    // array to hold the game object with tag "Music"
    private GameObject[] other;
    // bool to make sure that if they go back onto a level it doesnt repeat its self
    private bool NotFirst = false; 
    
    void Awake()
    {
        other = GameObject.FindGameObjectsWithTag("Music");

        // the foreach and if are used when player goes back to a scene which already 
        // has the continous music object and destroys it so we dont hear double music playing 
        foreach(GameObject oneOther in other){
            
            if(oneOther.scene.buildIndex == -1)
            {
                NotFirst = true; 
            }
            
        }

        if(NotFirst == true)
        {
            Destroy(gameObject); 
        }
    
        DontDestroyOnLoad(transform.gameObject);
    }

    void Update()
    {
        // get the build index for the active scene
        int buildIndex = SceneManager.GetActiveScene().buildIndex;

       // stop the music playing when they go into levels since they have there own music manager
        if (buildIndex == 4) // index for GameScene
        {
            GameObject.FindGameObjectWithTag("Music").GetComponent<ContinousMusic>().StopMusic(); // stop the music since it starts playing its own, done so that the music pause button can work. 
            Destroy(gameObject); // makes sure it doesnt continue through the rest of the levels 
        }

        // if playing do nothing
        if (backgroundSound.isPlaying) return; 
        // call play sound 
        backgroundSound.Play();
    }

    // stops the music when called 
    public void StopMusic()
    {
        backgroundSound.Stop();
    }
}

