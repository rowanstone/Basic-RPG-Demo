using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteraction : MonoBehaviour
{

    public GameObject interactable = null;

    void Update()
    {
        if(Input.GetButtonDown("Interact") && interactable.tag == "Treasure")
        {
            interactable.SendMessage("DoSomething");
        }
        else if(Input.GetButtonDown("Interact") && interactable.tag == "NPC")
        {
            interactable.SendMessage("StartDialogue");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision Tag: " + collision.tag);
        if(collision.tag == "Treasure")
        {
            interactable = collision.gameObject;
        }
        else if(collision.tag == "NPC")
        {
            interactable = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(interactable != null)
        {
            interactable = null;
        }
    }
}
