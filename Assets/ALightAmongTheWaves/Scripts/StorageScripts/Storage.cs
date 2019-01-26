using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public static class StorageManager
public static class Storage
{
    public static IResource[] resources;

    public static Food food;
    public static Wood wood;
    public static Population population;

    public static void Initialize()
    {
        resources = new IResource[3];
        food = new Food();
        resources[0] = food;
        wood = new Wood();
        resources[1] = wood;
        population = new Population();
        resources[2] = population;
    }
}
