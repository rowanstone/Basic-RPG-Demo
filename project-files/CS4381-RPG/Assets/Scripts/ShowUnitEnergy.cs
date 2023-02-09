using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUnitEnergy : ShowUnitStat
{

    override protected float NewStatValue()
    {
        return unit.GetComponent<UnitStats>().energy;
    }
}