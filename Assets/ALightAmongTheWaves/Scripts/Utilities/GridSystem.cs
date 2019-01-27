using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    public event System.Action newBuildableLineAddedEvent;

    public uint cellSize = 1;
    readonly public uint nbCellByLine = 17;
    public uint currentHeight { get; private set; } = 3;
    public uint currentBuildableHeight { get; private set; } = 3;

    [HideInInspector]
    public Vector2 gridOrigin = new Vector2(0, 0);

    public List<GameObject[]> grid = new List<GameObject[]>();
    public List<GameObject[]> gridOverlay = new List<GameObject[]>();

    public Transform moduleContainer, overlayContainer;

    public GameObject gridOverlaySprite;

    private void Awake()
    {
        gridOrigin = moduleContainer.position;

        if (grid.Count == 0)
            for (int i = 0; i < currentHeight; ++i)
            {
                grid.Add(new GameObject[nbCellByLine]);
                AddOverlayLine();
            }
    }

    public bool isInGrid(Vector2 position)
    {
        return position.y >= gridOrigin.y && position.y < gridOrigin.y + cellSize * (currentHeight)
            && position.x >= gridOrigin.x && position.x < gridOrigin.x + cellSize * (nbCellByLine);
    }

    public bool isInGrid(Vector2Int cellIndex)
    {
        return cellIndex.x >= 0 && cellIndex.x < nbCellByLine && cellIndex.y >= 0 && cellIndex.y < currentHeight;
    }

    void AddALine()
    {
        currentHeight++;
        grid.Add(new GameObject[nbCellByLine]);
    }

    void AddBuildableLine()
    {
        if (currentBuildableHeight == currentHeight)
            AddALine();

        currentBuildableHeight++;
        AddOverlayLine();

        newBuildableLineAddedEvent?.Invoke();
    }

    public Vector2Int GetCellIndexFromPosition(Vector2 position)
    {
        if (!isInGrid(position))
            return new Vector2Int(-1,-1);
        
        return new Vector2Int((int)((position.x - gridOrigin.x) / cellSize), (int)((position.y - gridOrigin.y) / cellSize));
    }

    public Vector2 GetPositionForCellIndex(Vector2Int cellIndex)
    {
        if (!isInGrid(cellIndex))
            throw new System.IndexOutOfRangeException();

        return gridOrigin + new Vector2((0.5f + cellIndex.x) * cellSize, (0.5f + cellIndex.y ) * cellSize);
    }

    public void PutGameObjectInCellIndex(GameObject gameObject, Vector2Int cellIndex)
    {
        //if (!isInGrid(cellIndex))
        //    throw new System.IndexOutOfRangeException();

        gameObject.transform.SetParent(moduleContainer, false);
        gameObject.transform.localScale = Vector3.one;

        gameObject.transform.position = GetPositionForCellIndex(cellIndex);

        Vector2Int moduleSize = gameObject.GetComponent<ShipModule>().moduleSize;

        for (int j = 0; j < moduleSize.y; ++j)
        {
            if (!isInGrid(new Vector2Int(0, cellIndex.y + j)))
                AddALine();

            for (int i = 0; i < moduleSize.x; ++i)
            {
                grid[cellIndex.y + j][cellIndex.x + i] = gameObject;

                if (cellIndex.y + j < currentBuildableHeight)
                    gridOverlay[cellIndex.y + j][cellIndex.x + i].SetActive(false);
            }
        }

        if (CanAddBuildableLine())
        {
            AddBuildableLine();
        }

    }

    public void PutGameObjectOnPosition(GameObject gameObject, Vector2 position)
    {
        PutGameObjectInCellIndex(gameObject, GetCellIndexFromPosition(position));

    }

    public void RemoveGameObjectOnPosition(Vector2 position)
    {
        RemoveGameObjectOnCellIndex(GetCellIndexFromPosition(position));
    }

    public void RemoveGameObjectOnCellIndex(Vector2Int cellIndex)
    {
        GameObject cellGameObject = GetGameObjectFormCellIndex(cellIndex);

        Vector2Int cellGameObjectPositionIndex = GetCellIndexFromPosition(cellGameObject.transform.position);

        Vector2Int moduleSize = cellGameObject.GetComponent<ShipModule>().moduleSize;

        for (int j = 0; j < moduleSize.y; ++j)
        {
            for (int i = 0; i < moduleSize.x; ++i)
            {
                grid[cellIndex.y + j][cellIndex.x + i] = null;

                if (cellIndex.y + j < currentBuildableHeight)
                    gridOverlay[cellIndex.y + j][cellIndex.x + i].SetActive(true);
            }
        }
    }

    public GameObject GetGameObjectFormCellIndex(Vector2Int cellIndex)
    {
        if (!isInGrid(cellIndex))
            return null;

        return grid[cellIndex.y][cellIndex.x];
    }

    public bool CanPLaceModule(Vector2Int modulePosition, Vector2Int moduleSize)
    {
        if (modulePosition.y >= currentBuildableHeight)
            return false;

        for (int i = 0; i < moduleSize.x; ++i)
            for (int j = 0; j < moduleSize.y; ++j)
            {
                if (!IsInBoat( new Vector2Int(modulePosition.x + i, modulePosition.y)))
                    return false;
                    
                if (GetGameObjectFormCellIndex(new Vector2Int(modulePosition.x + i, modulePosition.y + j)) != null)
                    return false;
            }

        return true;
    }

    public bool CanAddBuildableLine()
    {
        bool lineFull = true;

        Vector2Int boatArea = BoatAreaInLine(currentBuildableHeight - 1);

        for (int i = boatArea.x; i <= boatArea.y; ++i)
        {
            if (GetGameObjectFormCellIndex(new Vector2Int(i, (int)currentBuildableHeight - 1)) == null)
                return false;
        }

        return true;
    }

    //-------------------------------------------------------------------------------//

    public uint NbBoatCellInLineByHeight(uint heightLine)
    {
        if (heightLine == 0)
            return 5;

        uint nbCellOnLine = 5 + (uint)(Mathf.Log(heightLine * 2f) * 1.65f) * 2;

        if (nbCellOnLine > nbCellByLine)
            return nbCellByLine;
        else
            return nbCellOnLine;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="height"></param>
    /// <returns>Vector2.x = min; Vector2.y = max</returns>
    public Vector2Int BoatAreaInLine(uint height)
    {
        if (height >= currentHeight)
            return Vector2Int.zero;

        uint nbBoatCell = NbBoatCellInLineByHeight(height);

        return new Vector2Int((int)(nbCellByLine * 0.5f) - (int)(nbBoatCell * 0.5f), (int)(nbCellByLine * 0.5f) + (int)(nbBoatCell * 0.5f));
    }

    public bool IsInBoat(Vector2 position)
    {
        if (!isInGrid(position))
            return false;

        Vector2Int index = GetCellIndexFromPosition(position);

        Vector2Int boatArea = BoatAreaInLine((uint)index.y);

        return index.x >= boatArea.x && index.x <= boatArea.y;
    }

    public bool IsInBoat(Vector2Int cellIndex)
    {
        if (!isInGrid(cellIndex))
            return false;

        Vector2Int boatArea = BoatAreaInLine((uint)cellIndex.y);

        return cellIndex.x >= boatArea.x && cellIndex.x <= boatArea.y;
    }

    //---------------------------------------------------------------------------------//

    void AddOverlayLine()
    {
        gridOverlay.Add(new GameObject[nbCellByLine]);

        uint height = (uint)gridOverlay.Count - 1;

        uint nbBoatCell = NbBoatCellInLineByHeight(height);

        int minArea = (int)(nbCellByLine * 0.5f) - (int)(nbBoatCell * 0.5f);
        int maxArea = (int)(nbCellByLine * 0.5f) + (int)(nbBoatCell * 0.5f);

        for (int j = minArea; j <= maxArea; ++j)
        {
            gridOverlay[(int)height][j] = GameObject.Instantiate(gridOverlaySprite, overlayContainer);
            gridOverlay[(int)height][j].transform.localScale = Vector3.one;

            gridOverlay[(int)height][j].transform.position = GetPositionForCellIndex(new Vector2Int(j, (int)height));

            if (GetGameObjectFormCellIndex(new Vector2Int(j, (int)height)) != null )
                gridOverlay[(int)height][j].SetActive(false);
        }
    }
}
