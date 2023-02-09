using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAction : MonoBehaviour
{

    [SerializeField]
    private GameObject attack;

    [SerializeField]
    private string targetsTag;

    void Awake()
    {
        attack = Instantiate(attack);

        attack.GetComponent<AttackTarget>().owner = gameObject;
    }

    GameObject findRandomTarget()
    {
        GameObject[] possibleTargets = GameObject.FindGameObjectsWithTag("PlayerUnit");

        if (possibleTargets.Length > 0)
        {
            int targetIndex = Random.Range(0, possibleTargets.Length);
            GameObject target = possibleTargets[targetIndex];

            return target;
        }

        return null;
    }

    public void Act()
    {
        GameObject target = findRandomTarget();
        attack.GetComponent<AttackTarget>().Hit(target);
        GameObject.Find("TurnSystem").GetComponent<TurnSystem>().NextTurn();
    }
}