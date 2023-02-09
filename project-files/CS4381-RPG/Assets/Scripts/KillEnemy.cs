using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    public GameObject menuEnemy;

    void OnDestroy()
    {
        Destroy(menuEnemy);
    }
}
