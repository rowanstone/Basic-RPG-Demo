using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCInteraction : MonoBehaviour
{
    void StartDialogue()
    {
        SceneManager.LoadScene("DialogueScene1");
    }
}
