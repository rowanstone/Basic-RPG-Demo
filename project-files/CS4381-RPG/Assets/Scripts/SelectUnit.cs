using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectUnit : MonoBehaviour
{
    private GameObject currentUnit;

    private GameObject actionsMenu, enemyUnitsMenu;

    void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Battle")
        {
            actionsMenu = GameObject.Find("ActionsMenu");
            enemyUnitsMenu = GameObject.Find("EnemyUnitsMenu");
        }
    }

    public void SelectCurrentUnit(GameObject unit)
    {
        currentUnit = unit;
        Debug.Log("currentUnit Tag: " + currentUnit.tag);

        actionsMenu.SetActive(true);

        currentUnit.GetComponent<PlayerAction>().UpdateHUD();
    }

    public void SelectAttack(bool physical)
    {
        currentUnit.GetComponent<PlayerAction>().SelectAttack(physical);

        actionsMenu.SetActive(false);
        enemyUnitsMenu.SetActive(true);
    }

    public void AttackEnemyTarget(GameObject target)
    {
        Debug.Log("attackEnemyTarget: " + target.tag);
        actionsMenu.SetActive(false);
        enemyUnitsMenu.SetActive(false);

        currentUnit.GetComponent<PlayerAction>().Act(target);
        GameObject.Find("TurnSystem").GetComponent<TurnSystem>().NextTurn();
    }
}
