using RedSpace;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]
//public class ShipDataContainer
//{

//    protected static ShipDataContainer _instance;
//    public static ShipDataContainer Instance
//    {
//        get
//        {
//            return ((_instance != null) ? _instance : (_instance = new ShipDataContainer()));
//        }
//    }
//    protected ShipData _shipData;
//    public ShipData shipData
//    {
//        get
//        {
//            return _shipData;
//        }
//        set
//        {
//            _shipData = value;
//        }
//    }
//    private ShipDataContainer()
//    {

//    }
//    public void SetShipData(ShipData aShipData)
//    {
//        _shipData = aShipData;
//    }
//    public ShipData CreateAShipData()
//    {
//        ShipData aShipData = new ShipData();

//        return aShipData;
//    }
//    public ShipData GetShipDataRefence()
//    {
//        return _shipData;
//    }
//}

//public class ShipData
//{
    
//}

public class Ship : Singleton<Ship>
{
    public GridSystem gridShip;

    public List<ShipModule> shipParts = new List<ShipModule>();
    public List<ShipModule> disableShipParts = new List<ShipModule>();

    public GameObject shipModuleDormitoryPrefab, shipModuleHold5Prefab, shipModuleHold6Prefab, shipModuleMattPrefab, shipModuleMattFireSpotPrefab;

    GameObject shipMattFireSpotGO;

    [Serializable]
    public class ShipIncomeProduction
    {
        public int foodIncome = 0;
        public int woodIncome = 0;
    }

    public ShipIncomeProduction shipEconomyIncome;

    Storage _storage;
    // Start is called before the first frame update
    void Start()
    {
        GameObject moduleGameObject = GameObject.Instantiate(shipModuleHold5Prefab);
        moduleGameObject.GetComponent<ShipModule>().ActivateModule();
        gridShip.PutGameObjectInCellIndex(moduleGameObject, new Vector2Int(6, 0));

        moduleGameObject = GameObject.Instantiate(shipModuleHold6Prefab);
        moduleGameObject.GetComponent<ShipModule>().ActivateModule();
        gridShip.PutGameObjectInCellIndex(moduleGameObject, new Vector2Int(5, 1));

        moduleGameObject = GameObject.Instantiate(shipModuleDormitoryPrefab);
        moduleGameObject.GetComponent<ShipModule>().ActivateModule();
        gridShip.PutGameObjectInCellIndex(moduleGameObject, new Vector2Int(4, 2));

        shipMattFireSpotGO = GameObject.Instantiate(shipModuleMattFireSpotPrefab);
        shipMattFireSpotGO.GetComponent<ShipModule>().ActivateModule();
        gridShip.PutGameObjectInCellIndex(shipMattFireSpotGO, new Vector2Int((int)(gridShip.nbCellByLine * 0.5f), 3));

        gridShip.newBuildableLineAddedEvent += ShipMattGrow;

        _storage = StorageManager.Instance.GetStorageRefence();
        _storage.onStorageUpdate += StorageUpdate;
    }

    private void OnDestroy()
    {
        gridShip.newBuildableLineAddedEvent -= ShipMattGrow;
    }

    private void StorageUpdate()
    {
        if(_storage.population.freePopulation < 0)
        {
            while (_storage.population.freePopulation < 0) //need to equilibrate
            {
                DeactivateRandomModule();
            }
        }
        else if(disableShipParts.Count > 0 && _storage.population.freePopulation > 0)
        {
            bool haveFullAShipPart = false;
            do
            {
                haveFullAShipPart = false;

                for (int i = disableShipParts.Count - 1; i >= 0; --i)
                {
                    if (disableShipParts[i].cost.freePeopleCost <= _storage.population.freePopulation)
                    {
                        disableShipParts[i].ActivateModule();
                        haveFullAShipPart = true;
                    }
                }
            }
            while (haveFullAShipPart && disableShipParts.Count > 0);
        }
    }

    void ShipMattGrow()
    {
        if (gridShip.currentBuildableHeight == 5)
        {
            TagContainer.Instance.tags.Add(Consequence.HEIGHT_5_REACH);
            TagContainer.Instance.TagUpdated();
        }

        gridShip.RemoveGameObjectOnPosition(shipMattFireSpotGO.transform.position);
        gridShip.PutGameObjectInCellIndex(GameObject.Instantiate(shipModuleMattPrefab), 
            new Vector2Int((int)(gridShip.nbCellByLine * 0.5f), (int)gridShip.currentBuildableHeight-2));

        gridShip.PutGameObjectInCellIndex(shipMattFireSpotGO,
            new Vector2Int((int)(gridShip.nbCellByLine * 0.5f), (int)gridShip.currentBuildableHeight-1));
    }

    public void boostModule(int actionValue)
    {
        foreach(ShipModule shipModule in shipParts)
        {
            shipModule.Boost(actionValue);
        }
    }

    public void DeactivateRandomModule()
    {
        ShipModule shipModule = shipParts[(int)UnityEngine.Random.Range(0, shipParts.Count - 0.01f)]; 
        shipModule.DeactivateModule();
        disableShipParts.Add(shipModule);
    }

    
}
