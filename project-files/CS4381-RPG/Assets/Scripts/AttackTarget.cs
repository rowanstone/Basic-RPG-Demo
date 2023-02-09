using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackTarget : MonoBehaviour
{
    public GameObject owner;

    [SerializeField]
    private string attackAnimation;
    [SerializeField]
    private bool magicAttack;
    [SerializeField]
    private float energyCost;
    [SerializeField]
    private float minAttackMult;
    [SerializeField]
    private float maxAttackMult;
    [SerializeField]
    private float minDefenseMult;
    [SerializeField]
    private float maxDefenseMult;

    public void Hit(GameObject target)
    {
        UnitStats ownerStats = owner.GetComponent<UnitStats>();
        UnitStats targetStats = target.GetComponent<UnitStats>();
        if (ownerStats.energy >= energyCost)
        {
            float attackMult = (Random.value * (maxAttackMult - minAttackMult)) + minAttackMult;
            float damage = (magicAttack) ? attackMult * ownerStats.energy : attackMult * ownerStats.attack;

            float defenseMult = (Random.value * (maxDefenseMult - minDefenseMult)) + minDefenseMult;
            damage = Mathf.Max(0, damage - (defenseMult * targetStats.defense));

            //owner.GetComponent<Animator>().Play(attackAnimation);

            targetStats.ReceiveDamage(damage);

            ownerStats.energy -= energyCost;
        }
    }

}
