using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipModule : MonoBehaviour
{
    public Vector2Int moduleSize = new Vector2Int(1,1);

    public enum ShipModuleAction { kPopulationMax, kPopulation, kFoodIncome, kFoodMax, kWoodIncome, kWoodMax, kProductionBonus}

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
        public int freePoepleCost;
    }

    public Cost cost;

    Ship _ship;

    private void OnDestroy()
    {
        DeactivateModule();
    }

    public void ActivateModule()
    {
        _ship = Ship.Instance;

        _ship.shipEconomy.freePoeple -= cost.freePoepleCost;

        foreach(ModuleAction action in moduleActions)
        {
            switch (action.moduleAction)
            {
                case ShipModuleAction.kPopulationMax:
                    _ship.shipEconomy.maxPopulation += action.actionValue;
                    break;

                case ShipModuleAction.kPopulation:
                    _ship.shipEconomy.freePoeple += action.actionValue;
                    break;

                case ShipModuleAction.kFoodIncome:
                    _ship.shipEconomy.foodIncome += action.actionValue;
                    break;

                case ShipModuleAction.kFoodMax:
                    _ship.shipEconomy.foodMax += action.actionValue;
                    break;

                case ShipModuleAction.kWoodIncome:
                    _ship.shipEconomy.woodIncome += action.actionValue;
                    break;

                case ShipModuleAction.kWoodMax:
                    _ship.shipEconomy.woodMax += action.actionValue;
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

        _ship.shipEconomy.freePoeple += cost.freePoepleCost;

        foreach (ModuleAction action in moduleActions)
        {
            switch (action.moduleAction)
            {
                case ShipModuleAction.kPopulationMax:
                    _ship.shipEconomy.maxPopulation -= action.actionValue;
                    _ship.shipEconomy.freePoeple -= action.actionValue;
                    break;

                case ShipModuleAction.kPopulation:
                    _ship.shipEconomy.freePoeple -= action.actionValue;
                    break;

                case ShipModuleAction.kFoodIncome:
                    _ship.shipEconomy.foodIncome -= action.actionValue;
                    break;

                case ShipModuleAction.kFoodMax:
                    _ship.shipEconomy.foodMax -= action.actionValue;
                    break;

                case ShipModuleAction.kWoodIncome:
                    _ship.shipEconomy.woodIncome -= action.actionValue;
                    break;

                case ShipModuleAction.kWoodMax:
                    _ship.shipEconomy.woodMax -= action.actionValue;
                    break;

                case ShipModuleAction.kProductionBonus:
                    _ship.boostModule(-action.actionValue);
                    break;
            }
        }
    }

    internal void Boost(int actionValueBoost)
    {
        for(int i= moduleActions.Length-1; i>= 0; --i )
        {
            switch (moduleActions[i].moduleAction)
            {
                case ShipModuleAction.kFoodIncome:
                    _ship.shipEconomy.foodIncome += actionValueBoost;
                    moduleActions[i].actionValue += actionValueBoost;
                    break;

                case ShipModuleAction.kWoodIncome:
                    _ship.shipEconomy.woodIncome += actionValueBoost;
                    moduleActions[i].actionValue += actionValueBoost;
                    break;
            }
        }
    }
}
