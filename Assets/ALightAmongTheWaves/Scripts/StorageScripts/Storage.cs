﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageManager
{
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
    }
    public Storage CreateAStartStorage()
    {
        Storage s = Storage.createNew();
        
        s.food.Amount = 15;
        s.food.MinAmount = 0;
        s.food.MaxAmount = 30;
        
        s.wood.Amount = 15;
        s.wood.MinAmount = 0;
        s.wood.MaxAmount = 30;
        
        s.population.Amount = 0;
        s.population.MinAmount = 0;
        s.population.MaxAmount = 10;
        return s;
    }
    public Storage GetStorageRefence()
    {
        return _storage;
    }
}
public class Storage
{
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
