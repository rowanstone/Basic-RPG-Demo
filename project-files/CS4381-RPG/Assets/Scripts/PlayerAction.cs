using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAction : MonoBehaviour
{

    [SerializeField]
    private GameObject physicalAttack;

    [SerializeField]
    private GameObject magicalAttack;

    private GameObject currentAttack;

    [SerializeField]
    private Sprite faceSprite;

    void Awake()
    {
        physicalAttack = Instantiate(physicalAttack, transform) as GameObject;
        magicalAttack = Instantiate(magicalAttack, transform) as GameObject;

        physicalAttack.GetComponent<AttackTarget>().owner = gameObject;
        magicalAttack.GetComponent<AttackTarget>().owner = gameObject;

        currentAttack = physicalAttack;
    }

    public void Act(GameObject target)
    {
        currentAttack.GetComponent<AttackTarget>().Hit(target);
    }

    public void SelectAttack(bool physical)
    {
        currentAttack = (physical) ? physicalAttack : magicalAttack;
    }

    public void UpdateHUD()
    {
        GameObject playerUnitFace = GameObject.Find("PlayerUnitFace") as GameObject;
        playerUnitFace.GetComponent<Image>().sprite = faceSprite;

        GameObject playerUnitHealthBar = GameObject.Find("PlayerUnitHealthBar") as GameObject;
        playerUnitHealthBar.GetComponent<ShowUnitHealth>().changeUnit(gameObject);

        GameObject playerUnitEnergyBar = GameObject.Find("PlayerUnitEnergyBar") as GameObject;
        playerUnitEnergyBar.GetComponent<ShowUnitEnergy>().changeUnit(gameObject);
    }
}