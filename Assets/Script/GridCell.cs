using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell
{
    Grid grid;
    Vector2 gridPosition;
    GameObject cellObject;
    string cellType;
    Vector3 worldPosition;
    Quaternion rotation;
    public enum Direction { forwards, left, back, right }
    public Direction directionIsFacing = Direction.forwards;

    GameObject NoRoadUi;

    public Vector3 WorldPosition { get => worldPosition; }
    public GameObject CellObject { get => cellObject; set => cellObject = value; }
    public string CellType { get => cellType; set => cellType = value; }
    public Grid Grid { get => grid; set => grid = value; }
    public Vector2 GridPosition { get => gridPosition; set => gridPosition = value; }

    public void Check()
    {
        if (cellType == "Building")
        { 
            if (!grid.CheckForTypeInDirection("Road", Mathf.RoundToInt(gridPosition.x), Mathf.RoundToInt(gridPosition.y), directionIsFacing))
            {
                cellObject.GetComponent<Structure>().NoRoad();
                if (NoRoadUi == null) NoRoadUi = GameObject.Instantiate(UIManager.Instance.NoRoadUi, new Vector3(cellObject.transform.position.x, cellObject.transform.position.y + 1, cellObject.transform.position.z), cellObject.transform.rotation, cellObject.transform);
                
            }
            else
            {
                cellObject.GetComponent<Structure>().HasRoad();
                GameObject.Destroy(NoRoadUi);
            }
        }
    }
    public void Create(GameObject cellType)
    {
        cellObject = GameObject.Instantiate(cellType, WorldPosition, rotation);
    }
    public GridCell(Vector3 position, Quaternion rotation)
    {
        this.worldPosition = position;
        this.rotation = rotation;
    }
    public void Hide()
    {
        cellObject.SetActive(false);
    }
    public IEnumerator ShowAfter()
    {
        yield return new WaitForEndOfFrame();
        cellObject.SetActive(true);
    }
}
