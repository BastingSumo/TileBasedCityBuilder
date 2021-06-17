using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour
{
    [SerializeField] int income = 100;
    [SerializeField] int maintenance = 0;
    [SerializeField] int placeCost = 100;

    public int Income { get => income; }
    public int PlaceCost { get => placeCost;}

    bool hasBeenAdded = false;
    public virtual void Place()
    {
        if (hasBeenAdded == false)
        {
            CityManager.Instance.PotenialIncome += income;
            CityManager.Instance.Expense += maintenance;
            CityManager.Instance.CurrentMoney -= placeCost;
            hasBeenAdded = true;
        }
    }
    public virtual void HasRoad()
    {

    }
    public virtual void NoRoad()
    {

    }
    public virtual void OnDestroy()
    {
        if (hasBeenAdded == true)
        {
            CityManager.Instance.CurrentMoney += placeCost;
            CityManager.Instance.Expense -= maintenance;
            CityManager.Instance.PotenialIncome -= income;
        }
    }
}
