﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipModule : MonoBehaviour
{
    public string moduleName = "";

    public Consequence unlockCondition;

    public Vector2Int moduleSize = new Vector2Int(1,1);

    public enum ShipModuleAction { kPopulationMax, kFoodIncome, kFoodMax, kWoodIncome, kWoodMax, kProductionBonus}

    [Serializable]
    public struct ModuleAction
    {
        public ShipModuleAction moduleAction;
        public int actionValue;
    }

    public ModuleAction[] moduleActions = new ModuleAction[0];
    
    [Serializable]
    public struct Cost
    {
        public int woodCost;
        public int foodCost;
        public int freePeopleCost;
    }

    public Cost cost;

    Ship _ship;

    private void OnDestroy()
    {
        DeactivateModule();
    }

    public bool IsUnlock(List<Consequence> consequences)
    {
        if (unlockCondition == Consequence.NOTHING)
            return true;

        foreach (Consequence consequence in consequences)
            if (consequence == unlockCondition)
                return true;

        return false;
    }

    public bool IsPurchable(Storage storage)
    {
        if (storage.wood.Amount >= cost.woodCost && storage.population.freePopulation >= cost.freePeopleCost)
            return true;

        return false;
    }

    public void ActivateModule()
    {
        _ship = Ship.Instance;

        StorageManager.Instance.GetStorageRefence().population.occupedPopulation += cost.freePeopleCost;

        foreach (ModuleAction action in moduleActions)
        {
            switch (action.moduleAction)
            {
                case ShipModuleAction.kPopulationMax:
                    StorageManager.Instance.GetStorageRefence().population.MaxAmount += action.actionValue;
                    break;

                case ShipModuleAction.kFoodIncome:
                    _ship.shipEconomyIncome.foodIncome += action.actionValue;
                    break;

                case ShipModuleAction.kFoodMax:
                    StorageManager.Instance.GetStorageRefence().food.MaxAmount += action.actionValue;
                    break;

                case ShipModuleAction.kWoodIncome:
                    _ship.shipEconomyIncome.woodIncome += action.actionValue;
                    break;

                case ShipModuleAction.kWoodMax:
                    StorageManager.Instance.GetStorageRefence().wood.MaxAmount += action.actionValue;
                    break;

                case ShipModuleAction.kProductionBonus:
                    _ship.boostModule(action.actionValue);
                    break;
            }
        }
    }

    public void DeactivateModule()
    {
        if (_ship == null)
            return;

        StorageManager.Instance.GetStorageRefence().population.occupedPopulation -= cost.freePeopleCost;

        foreach (ModuleAction action in moduleActions)
        {
            switch (action.moduleAction)
            {
                case ShipModuleAction.kPopulationMax:
                    StorageManager.Instance.GetStorageRefence().population.MaxAmount -= action.actionValue;
                    
                    break;

                case ShipModuleAction.kFoodIncome:
                    _ship.shipEconomyIncome.foodIncome -= action.actionValue;
                    break;

                case ShipModuleAction.kFoodMax:
                    StorageManager.Instance.GetStorageRefence().food.MaxAmount -= action.actionValue;
                    break;

                case ShipModuleAction.kWoodIncome:
                    _ship.shipEconomyIncome.woodIncome -= action.actionValue;
                    break;

                case ShipModuleAction.kWoodMax:
                    StorageManager.Instance.GetStorageRefence().wood.MaxAmount -= action.actionValue;
                    break;

                case ShipModuleAction.kProductionBonus:
                    _ship.boostModule(-action.actionValue);
                    break;
            }
        }
    }

    public void Boost(int actionValueBoost)
    {
        for(int i= moduleActions.Length-1; i>= 0; --i )
        {
            switch (moduleActions[i].moduleAction)
            {
                case ShipModuleAction.kFoodIncome:
                    _ship.shipEconomyIncome.foodIncome += actionValueBoost;
                    moduleActions[i].actionValue += actionValueBoost;
                    break;

                case ShipModuleAction.kWoodIncome:
                    _ship.shipEconomyIncome.woodIncome += actionValueBoost;
                    moduleActions[i].actionValue += actionValueBoost;
                    break;
            }
        }
    }
}
