using UnityEngine;
using System.Collections;

public class GridOverlay : MonoBehaviour
{
    public GridSystem gridSystem;

    [Space]

    public GameObject gridOverlaySprite;

    void Start()
    {
        for (int i = (int)gridSystem.currentHeight - 1; i >= 0; --i)
        {
            uint nbBoatCell = gridSystem.NbBoatCellInLineByHeight((uint)i);

            int minArea = (int)(gridSystem.nbCellByLine * 0.5f) - (int)(nbBoatCell * 0.5f);
            int maxArea = (int)(gridSystem.nbCellByLine * 0.5f) + (int)(nbBoatCell * 0.5f);

            for (int j = maxArea; j >= minArea; --j)
            {
                gridSystem.PutGameObjectInCellIndex(GameObject.Instantiate(gridOverlaySprite), (uint)i * gridSystem.nbCellByLine + (uint)j);
            }
        }
    }
}