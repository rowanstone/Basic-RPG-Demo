using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitStats : MonoBehaviour, IComparable
{
    public float powerLevel;
    public float health;
    public float energy;
    public float attack;
    public float defense;
    public float speed;
    public float currentExperience;
    public bool questAcquired;
    public bool questCompleted;

    public int nextActTurn;

    private bool dead = false;

    [SerializeField]
    private GameObject damageText;

    public void CalculateNextTurn(int currentTurn)
    {
        nextActTurn = currentTurn + (int)Math.Ceiling(100.0f / speed);
    }
    public int CompareTo(object otherStats)
    {
        return nextActTurn.CompareTo(((UnitStats)otherStats).nextActTurn);
    }
    public bool IsDead()
    {
        return dead;
    }
    public void ReceiveDamage(float damage)
    {
        Debug.Log("Health at start of turn: " + health);
        health -= damage;
        Debug.Log("Damage done: " + damage);
        Debug.Log("Health at end of turn: " + health);
        //animator.Play("Hit");

        GameObject HUDCanvas = GameObject.Find("HUDCanvas");
        //damageText = Instantiate(damageText, HUDCanvas.transform) as GameObject;
        damageText.GetComponent<Text>().text = "" + damage;
        damageText.transform.localPosition = damageText.gameObject.transform.position;
        damageText.transform.localScale = new Vector2(1.0f, 1.0f);

        if (health <= 0)
        {
            dead = true;
            Debug.Log(gameObject.tag + " is now dead.");
            gameObject.tag = "DeadUnit";
            Destroy(gameObject);
        }
    }
    public void AllocateExperience(float exp)
    {
        currentExperience += exp;
    }
}

