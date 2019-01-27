using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageManager
{
    public static bool existInstance
    {
        get
        {
            return (_instance != null);
        }
    }
    protected static StorageManager _instance;
    public static StorageManager Instance
    {
        get
        {
            return ((_instance != null) ? _instance : (_instance = new StorageManager()));
        }
    }
    protected Storage _storage;
    public Storage storage
    {
        get
        {
            return _storage;
        }
        set
        {
            _storage = value;
        }
    }
    private StorageManager()
    {

    }
    public void SetStorage(Storage aStorage)
    {
        _storage = aStorage;
        //Debug.Log("SetStorage");
        for (int i = 0; i < _storage.resources.Length; ++i)
        {
            _storage.resources[i].SetResourceUpdateCallback(CallOnStorageUpdate);
        }
    }
    public void CallOnStorageUpdate()
    {
        _storage.onStorageUpdate?.Invoke();
    }
    public Storage CreateAStartStorage()
    {
        Storage s = Storage.createNew();
        
        s.food.MinAmount = 0;
        s.food.MaxAmount = 30;
        s.food.Amount = 15;

        s.wood.MinAmount = 0;
        s.wood.MaxAmount = 30;
        s.wood.Amount = 15;

        s.population.MinAmount = 0;
        s.population.MaxAmount = 10;
        s.population.Amount = 5;
        s.population.occupedPopulation = 0;
        return s;
    }
    public Storage GetStorageRefence()
    {
        return _storage;
    }
}
[System.Serializable]
public class Storage
{
    public delegate void OnStorageUpdate();
    public OnStorageUpdate onStorageUpdate;
    public IResource[] resources;

    public Food food;
    public Wood wood;
    public Population population;

    public static Storage createNew()
    {
        Storage s = new Storage();
        s.resources = new IResource[3];
        s.food = new Food();
        s.resources[0] = s.food;
        s.wood = new Wood();
        s.resources[1] = s.wood;
        s.population = new Population();
        s.resources[2] = s.population;
        return s;
    }
}
