using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacementManager : MonoBehaviour
{
    [SerializeField] GridManager gridManager;
    GameObject objectIsPlacing;
    private static BuildingPlacementManager _instance;

    public static BuildingPlacementManager Instance { get { return _instance; } }

    public GameObject ObjectIsPlacing { get => objectIsPlacing; set => objectIsPlacing = value; }

    int i = 0;
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    private void Update()
    {
        PlaceBuilding();
        RotateBuilding();
    }
    void RotateBuilding()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            i += 90;
            if (i > 270) i = 0;
            objectIsPlacing.transform.rotation = TurnObj();
        }
    }
    void PlaceBuilding()
    {
        if (objectIsPlacing != null  && !UIManager.Instance.MouseIsOverUI())
        {
            Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hitInfo, Mathf.Infinity);
            if (hitInfo.collider != null)
            {
                GridCell cell = gridManager.GetClosestCell(hitInfo.collider.gameObject.transform.position);
                cell.Hide();
                StartCoroutine(cell.ShowAfter());
                objectIsPlacing.transform.position = cell.WorldPosition;
                Structure structure = objectIsPlacing.GetComponent<Structure>();
                if (Input.GetMouseButton(0) && CityManager.Instance.CurrentMoney + CityManager.Instance.AcceptableDebtBeforeLoss >= structure.PlaceCost)
                {
                    cell.CellType = objectIsPlacing.tag;
                    GameObject temp = Instantiate(objectIsPlacing);
                    temp.transform.position = cell.WorldPosition;
                    temp.transform.rotation = objectIsPlacing.transform.rotation;
                    if (cell.CellObject != null) Destroy(cell.CellObject);
                    cell.CellObject = temp;
                    MaterialTools.AssignMaterial(AssetManager.Instance.TileTextures[0], temp);
                    cell.directionIsFacing = SetFacingDirection();
                    temp.GetComponent<Structure>().Place();
                }
                if (Input.GetMouseButtonUp(0))
                {
                    gridManager.MainGridUpdated();
                }
                if (Input.GetMouseButtonDown(1))
                {
                    Destroy(objectIsPlacing);
                    objectIsPlacing = null;
                    i = 0;
                    SelectionManager.Instance.CansSelect = true;
                }
            }
        }
    }
    GridCell.Direction SetFacingDirection()
    {
        if (i == 90) return GridCell.Direction.left;
        else if (i == 180) return GridCell.Direction.back;
        else if (i == 270) return GridCell.Direction.right;
        else return GridCell.Direction.forwards;
    }
    Quaternion TurnObj()
    {
        if (i == 90) return Quaternion.Euler(objectIsPlacing.transform.rotation.x, 90, objectIsPlacing.transform.rotation.z);
        else if (i == 180) return Quaternion.Euler(objectIsPlacing.transform.rotation.x, 180, objectIsPlacing.transform.rotation.z);
        else if (i == 270) return Quaternion.Euler(objectIsPlacing.transform.rotation.x, 270, objectIsPlacing.transform.rotation.z);
        else return Quaternion.Euler(objectIsPlacing.transform.rotation.x, 0, objectIsPlacing.transform.rotation.z);
    }
}
