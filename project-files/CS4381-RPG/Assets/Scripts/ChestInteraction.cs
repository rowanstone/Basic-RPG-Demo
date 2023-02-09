using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteraction : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer spriteRenderer;

    [SerializeField]
    Sprite chestOpen, chestClosed;

    [SerializeField]
    public bool isChestOpen;

    public Animator animate;

    void DoSomething()
    {
        animate = GetComponent<Animator>();
        animate.Play("Chest_Open");
    }

    void Interact()
    {
        if (isChestOpen)
        {
            StopInteract();
        }
        else
        {
            isChestOpen = true;
            spriteRenderer.sprite = chestOpen;
        }
    }

    void StopInteract()
    {

    }
}
