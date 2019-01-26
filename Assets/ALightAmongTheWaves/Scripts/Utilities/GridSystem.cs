using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    public uint cellSize = 1;
    readonly public uint nbCellByLine = 13;
    public uint currentHeight { get; private set; } = 3;

    [HideInInspector]
    public Vector2 gridOrigin = new Vector2(0, 0);

    public List<GameObject> grid = new List<GameObject>();

    public uint NbBoatCellInLineByHeight(uint HeightLine)
    {
        if (HeightLine == 0)
            return 5;
        return 5 + (uint)(Mathf.Log(HeightLine * 2f) * 1.65f)*2;
    }

    private void Awake()
    {
        if (grid.Count == 0)
            for (int i = 0; i < (nbCellByLine-1) * currentHeight; ++i)
                grid.Add(null);

        gridOrigin = transform.position;
    }

    public bool isInGrid(Vector2 position)
    {
        if (position.y < gridOrigin.y || position.x < gridOrigin.x || position.x > gridOrigin.x + cellSize * (nbCellByLine))
            return false;

        return position.y <= gridOrigin.y + cellSize * (currentHeight);
    }

    public void AddALine()
    {
        for (int i = 0; i < nbCellByLine; ++i) grid.Add(null);
    }

    public int GetCellIndexFromPosition(Vector2 position)
    {
        if (position.y < gridOrigin.y || position.x < gridOrigin.x || position.x > gridOrigin.x + cellSize * (nbCellByLine))
            return -1;

        int line = (int)((position.y - gridOrigin.y) / cellSize);
        int column = (int)((position.x - gridOrigin.x) / cellSize);

        return column + (line * (int)nbCellByLine) ;
    }

    public Vector2 GetPositionForCellIndex(uint cellIndex)
    {
        return gridOrigin + new Vector2((0.5f + cellIndex % nbCellByLine) * cellSize, (0.5f + cellIndex / nbCellByLine ) * cellSize);
    }

    public void PutGameObjectInCellIndex(GameObject gameObject, uint cellIndex)
    {
        if (cellIndex > grid.Count)
            throw new System.IndexOutOfRangeException();

        gameObject.transform.SetParent(this.transform, false);
        gameObject.transform.localScale = Vector3.one;

        gameObject.transform.position = GetPositionForCellIndex(cellIndex);

        grid[(int)cellIndex] = gameObject;
    }

    public void PutGameObjectOnPosition(GameObject gameObject, Vector2 position)
    {
        int cellIndex = GetCellIndexFromPosition(position);

        if (cellIndex == -1)
            return;

        if (cellIndex > grid.Count)
            throw new System.IndexOutOfRangeException();

        gameObject.transform.SetParent(this.transform, false);
        gameObject.transform.localScale = Vector3.one;

        gameObject.transform.position = GetPositionForCellIndex((uint)cellIndex);

        grid[(int)cellIndex] = gameObject;
    }

    public GameObject GetGameObjectFormCellIndex(uint cellIndex)
    {
        if (cellIndex > grid.Count)
            throw new System.IndexOutOfRangeException();

        return grid[(int)cellIndex];
    }
}
