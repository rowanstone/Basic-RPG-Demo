using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurnSystem : MonoBehaviour
{
    private List<UnitStats> charStats;

    [SerializeField]
    private GameObject ActionsMenu;
    [SerializeField]
    private GameObject EnemyUnitsMenu;

    GameObject playerParty;
    public GameObject enemyEncounter;

    // Start is called before the first frame update
    void Start()
    {
        playerParty = GameObject.Find("PlayerParty"); // NullException Issue is here. 
        enemyEncounter = GameObject.Find("EnemyEncounter");

        charStats = new List<UnitStats>();

        GameObject[] playerUnits = GameObject.FindGameObjectsWithTag("PlayerUnit");
        foreach(GameObject playerUnit in playerUnits)
        {
            UnitStats currentCharStats = playerUnit.GetComponent<UnitStats>();
            currentCharStats.CalculateNextTurn(0);
            charStats.Add(currentCharStats);
        }

        GameObject[] enemyUnits = GameObject.FindGameObjectsWithTag("EnemyUnit");
        foreach (GameObject enemyUnit in enemyUnits)
        {
            UnitStats currentCharStats = enemyUnit.GetComponent<UnitStats>();
            currentCharStats.CalculateNextTurn(0);
            charStats.Add(currentCharStats);
        }

        charStats.Sort();
        ActionsMenu.SetActive(false);
        EnemyUnitsMenu.SetActive(false);

        NextTurn();
    }

    public void NextTurn()
    {
        GameObject enemyEncounter = GameObject.FindGameObjectWithTag("EnemyEncounter");
        Debug.Log("Starting Next Turn...");
        GameObject[] remainingEnemies = GameObject.FindGameObjectsWithTag("EnemyUnit");
        if(remainingEnemies.Length <= 0)
        {
            enemyEncounter.GetComponent<CollectReward>().CollectBattleReward();
            SceneManager.LoadScene("Wilderness");
        }
        GameObject[] remainingPlayers = GameObject.FindGameObjectsWithTag("PlayerUnit");
        if (remainingPlayers.Length <= 0)
        {
            SceneManager.LoadScene("Start");
        }
        //GameObject playerParty = GameObject.Find("PlayerParty"); // NullException Issue is here. 
        UnitStats currentStats = charStats[0];
        Debug.Log("currentStats: " + charStats[0].gameObject.tag);
        charStats.Remove(currentStats);

        if (!currentStats.IsDead())
        {
            GameObject currentUnit = currentStats.gameObject;
            currentStats.CalculateNextTurn(currentStats.nextActTurn);
            charStats.Add(currentStats);
            charStats.Sort();

            if (currentUnit.tag == "PlayerUnit")
            {
                Debug.Log("Player is acting");
                Debug.Log("PlayerParty Tag: " + playerParty.tag);
                playerParty.GetComponent<SelectUnit>().SelectCurrentUnit(currentUnit.gameObject);
            }
            else
            {
                Debug.Log("Enemy is acting");
                currentUnit.GetComponent<EnemyAction>().Act();
            }
        }
        else
        {
            NextTurn();
        }
    }
}
