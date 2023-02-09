using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class ChangeScene : MonoBehaviour
{ 
    public void LoadNextScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
