using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Run : MonoBehaviour
{
    [SerializeField]
    private float runChance;

    public void AttemptRun()
    {
        float randomNum = Random.value;

        if(randomNum < runChance)
        {
            SceneManager.LoadScene("Wilderness");
        }
        else
        {
            GameObject.Find("TurnSystem").GetComponent<TurnSystem>().NextTurn();
        }
    }
}
