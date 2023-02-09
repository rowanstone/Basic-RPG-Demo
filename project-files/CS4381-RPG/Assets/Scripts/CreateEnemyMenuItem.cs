using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateEnemyMenuItem : MonoBehaviour
{
    public GameObject targetEnemyUnitPrefab;
    public Sprite menuEnemySprite;
    public Vector2 initialPosition;
    public Vector2 enemyDimensions;
    public KillEnemy killEnemyScript;
    // Start is called before the first frame update
    void Awake()
    {
        GameObject enemyUnitsMenu = GameObject.Find("EnemyUnitsMenu");  //Refer to the EnemyUnitsMenu object in the current scene.
        GameObject[] existingEnemies = GameObject.FindGameObjectsWithTag("TargetEnemyUnit");  // Array of references to TargetEnemyUnit objects in scene.
        Vector2 nextPosition = new Vector2(initialPosition.x + (existingEnemies.Length * enemyDimensions.x), initialPosition.y);

        //GameObject targetEnemyUnit = InstantiateTargetEnemyUnit(enemyUnitsMenu);
        GameObject targetEnemyUnit = Instantiate(targetEnemyUnitPrefab, enemyUnitsMenu.transform) as GameObject;
        targetEnemyUnit.name = "Target" + gameObject.name;
        targetEnemyUnit.transform.localPosition = nextPosition;
        targetEnemyUnit.transform.localScale = new Vector2(0.7f, 0.7f);
        targetEnemyUnit.GetComponent<Button>().onClick.AddListener(() => SelectEnemy());
        targetEnemyUnit.GetComponent<Image>().sprite = menuEnemySprite;

        killEnemyScript.menuEnemy = targetEnemyUnit; //*****
    }

    //private GameObject InstantiateTargetEnemyUnit(GameObject enemyUnitsMenu)
    //{
    //    return Instantiate(targetEnemyUnitPrefab, enemyUnitsMenu.transform) as GameObject;
        //***
    //}

    public void SelectEnemy()
    {
        GameObject partyData = GameObject.Find("PlayerParty");
        partyData.GetComponent<SelectUnit>().AttackEnemyTarget(gameObject);
    }
}
