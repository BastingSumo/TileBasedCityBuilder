using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    float cellWidth = 1;
    float cellLength = 1;
    int length;
    int width;
    GridCell[,] gridCell;

    public GridCell[,] GridCell { get => gridCell; }

    public void Create()
    {
        gridCell = new GridCell[length, width];
        for (int i = 0; i < GridCell.GetLength(0); i++)
        {
            for (int k = 0; k < GridCell.GetLength(1); k++)
            {
                List<GameObject> tileTypes = AssetManager.Instance.Tiles;
                GridCell[i, k] = new GridCell(new Vector3(i * cellLength, 0, k * cellWidth), Quaternion.Euler(0, 0, 0));
                GridCell[i, k].Create(tileTypes[Random.Range(0, tileTypes.Count)]);
                GridCell[i, k].Grid = this;
                GridCell[i, k].GridPosition = new Vector2(i, k);
                MaterialTools.AssignMaterial(AssetManager.Instance.TileTextures[0], GridCell[i, k].CellObject);
            }
        }
    }
    public void GridUpdated()
    {
        for (int i = 0; i < GridCell.GetLength(0); i++)
        {
            for (int k = 0; k < GridCell.GetLength(1); k++)
            {
                GridCell[i, k].Check();
                
            }
        }
    }
    public bool CheckForTypeInDirection(string name, int gridX, int gridY, GridCell.Direction direction)
    {
        switch (direction)
        {
            case global::GridCell.Direction.left:
                if (GridCell[gridX - 1, gridY].CellType == name) return true;
                break;
            case global::GridCell.Direction.back:
                if (GridCell[gridX, gridY + 1].CellType == name) return true;
                break;
            case global::GridCell.Direction.right:
                if (GridCell[gridX + 1, gridY].CellType == name) return true;
                break;
            case global::GridCell.Direction.forwards:
                if (GridCell[gridX, gridY - 1].CellType == name) return true;
                break;
            default:
                break;
        }
        return false;
    }
    public Grid(int width, int length, float cellWidthScale, float cellLengthScale)
    {
        this.width = width;
        this.length = length;
        this.cellWidth = cellWidthScale;
        this.cellLength = cellLengthScale;
    }
}
