using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkPlace : Structure
{
    [SerializeField] int jobs = 5;

    public int Jobs { get => jobs; }
    bool workPlaceBeenAdded = false;
    public override void HasRoad()
    {
        base.HasRoad();
        if (!workPlaceBeenAdded)
        {
            CityManager.Instance.Jobs += jobs;
            workPlaceBeenAdded = true;
        }
    }
    public override void NoRoad()
    {
        base.NoRoad();
        if (workPlaceBeenAdded) CityManager.Instance.Jobs -= jobs;
    }
    public override void OnDestroy()
    {
        base.OnDestroy();
        if (workPlaceBeenAdded) CityManager.Instance.Jobs -= jobs;
    }
}
