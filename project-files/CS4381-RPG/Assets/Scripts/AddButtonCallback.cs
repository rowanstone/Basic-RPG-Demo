﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddButtonCallback : MonoBehaviour
{

    [SerializeField]
    private bool physical;

    // Use this for initialization
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => addCallback());
    }

    private void addCallback()
    {
        GameObject playerParty = GameObject.Find("PlayerParty");
        playerParty.GetComponent<SelectUnit>().SelectAttack(physical);
    }

}