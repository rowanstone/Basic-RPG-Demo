using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUnitHealth : ShowUnitStat
{

    override protected float NewStatValue()
    {
        return unit.GetComponent<UnitStats>().health;
    }
}