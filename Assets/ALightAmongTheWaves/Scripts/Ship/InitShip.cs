using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitShip : MonoBehaviour
{
    public GridSystem gridShip;

    public GameObject shipModuleDormitoryPrefab, shipModuleHold5Prefab, shipModuleHold6Prefab;

    // Start is called before the first frame update
    void Start()
    {
        gridShip.PutGameObjectInCellIndex(GameObject.Instantiate(shipModuleHold5Prefab), new Vector2Int(6, 0));
        gridShip.PutGameObjectInCellIndex(GameObject.Instantiate(shipModuleHold6Prefab), new Vector2Int(5, 1));
        gridShip.PutGameObjectInCellIndex(GameObject.Instantiate(shipModuleDormitoryPrefab), new Vector2Int(4, 2));
    }
}
