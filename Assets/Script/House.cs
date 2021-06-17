using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : Structure
{
    [SerializeField] int housing = 1;
    bool housingBeenAdded = false;

    public int Housing { get => housing; }

    public override void HasRoad()
    {
        base.HasRoad();
        if (!housingBeenAdded)
        {
            CityManager.Instance.Housing += housing;
            housingBeenAdded = true;
        }
    }
    public override void NoRoad()
    {
        base.NoRoad();
        if (housingBeenAdded) CityManager.Instance.Housing -= housing;
    }
    public override void OnDestroy()
    {
        base.OnDestroy();
        if (housingBeenAdded) CityManager.Instance.Housing -= housing;
    }
}
