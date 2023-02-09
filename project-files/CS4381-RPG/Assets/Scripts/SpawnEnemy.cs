using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnEnemy : MonoBehaviour
{   
    public GameObject enemyEncounter;

    private bool spawning = false;


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject); // Persist this game object into the Battle scene to spawn enemy units

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "Battle")
        {
            if (this.spawning)  // If the player has collided with the enemy spawner and current scene is the "Battle" scene
            {
                Instantiate(enemyEncounter);    // Instantiate enemyEncounter 
            }
            SceneManager.sceneLoaded -= OnSceneLoaded;
            Destroy(this.gameObject);   // Destroy this enemy spawner when Battle scene loads to prevent too many instantiations of enemyEncounter
        }
    }

    private void OnTriggerEnter2D(Collider2D other)    // Function to detect if the player object has collided with the enemy spawner
    {
        if(other.gameObject.tag == "Player")
        {
            spawning = true;       
            SceneManager.LoadScene("Battle");       // If collision with player detected, transition to the Battle scene.
        }
    }
}
