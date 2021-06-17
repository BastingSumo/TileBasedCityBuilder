using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GridManager : MonoBehaviour
{
    [SerializeField] int mainGridWidth = 100;
    [SerializeField] int mainGridLength = 100;
    [SerializeField] float cellWidth = 1;
    [SerializeField] float cellLength = 1;

    Grid mainGrid;
    private void Awake()
    {
        Application.targetFrameRate = 144;
    }
    private void Start()
    {
        mainGrid = new Grid(mainGridWidth, mainGridLength, cellWidth, cellLength);
        mainGrid.Create();
    }
    public GridCell GetClosestCell(Vector3 position)
    {
        float closestDistance = float.MaxValue;
        GridCell closestObject = null;
        for (int i = 0; i < mainGrid.GridCell.GetLength(0); i++)
        {
            for (int k = 0; k < mainGrid.GridCell.GetLength(1); k++)
            {
                float tempDistance = Vector3.Distance(mainGrid.GridCell[i, k].WorldPosition, position);
                if (closestDistance > tempDistance)
                {
                    closestDistance = tempDistance;
                    closestObject = mainGrid.GridCell[i, k];
                }
            }
        }
        return closestObject;
    }
    public void MainGridUpdated()
    {
        mainGrid.GridUpdated();
    }
}
