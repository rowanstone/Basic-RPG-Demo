using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShowUnitStat : MonoBehaviour
{
    [SerializeField]
    protected GameObject unit;

    [SerializeField]
    private float maxValue;

    private Vector2 initialScale;

    // Start is called before the first frame update
    void Start()
    {
        initialScale = gameObject.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (unit)
        {
            float newValue = NewStatValue();
            float newScale = (initialScale.x * newValue) / maxValue;
            gameObject.transform.localScale = new Vector2(newScale, initialScale.y);
        }
    }

    public void changeUnit(GameObject newUnit)
    {
        unit = newUnit;
    }

    abstract protected float NewStatValue();
}

