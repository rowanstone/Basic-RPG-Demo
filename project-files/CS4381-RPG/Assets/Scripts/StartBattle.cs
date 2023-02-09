using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartBattle : MonoBehaviour
{
    public static GameObject playerParty;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        playerParty = this.gameObject;
        SceneManager.sceneLoaded += OnSceneLoaded;
        this.gameObject.SetActive(false);
    }
    
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "Start")
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            Destroy(this.gameObject);
        }
        else
        {
            this.gameObject.SetActive(scene.name == "Battle");
        }
    }
}
