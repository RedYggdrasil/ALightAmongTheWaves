using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResourceType { Unset = 0, Food = 1, Wood = 2, Population = 3 }
[System.Serializable]
public static class ResourceTool
{
    static Dictionary<ResourceType, string> ResourceName = new Dictionary<ResourceType, string>
    {
        {ResourceType.Unset, "Unset"},
        {ResourceType.Food, "Food"},
        {ResourceType.Wood, "Wood"},
        {ResourceType.Population, "Population"}
    };
}
public interface IResource
{
    ResourceType ResourceType
    {
        get;
    }
    int MinAmount
    {
        get;
        set;
    }
    int MaxAmount
    {
        get;
        set;
    }
    int Amount
    {
        get;
        set;
    }
    void SetResourceUpdateCallback(System.Action callback);
}
[System.Serializable]
public abstract class AResource : IResource
{
    protected System.Action _onStorageUpdate;
    public abstract ResourceType ResourceType { get; }
    public abstract int Amount { get; set; }
    [SerializeField] protected int _minAmount;
    [SerializeField] protected int _maxAmount;
    public virtual int MinAmount { get { return _minAmount; } set { _minAmount = Mathf.Clamp(value, 0, int.MaxValue); EnforceAmountBoudaries(); } }
    public virtual int MaxAmount { get { return _maxAmount; } set { /*Debug.Log(value);*/ _maxAmount = Mathf.Clamp(value, 0, int.MaxValue); EnforceAmountBoudaries(); } }

    protected virtual void EnforceAmountBoudaries()
    {
        Amount = Mathf.Clamp(Amount, MinAmount, MaxAmount);
    }
    public virtual void SetResourceUpdateCallback(System.Action callback)
    {
        _onStorageUpdate = callback;
    }
}
[System.Serializable]
public abstract class IntBasedResource : AResource
{
    [SerializeField] protected int _amount;
    public override int Amount
    {
        get
        {
            return _amount;
        }
        set
        {
            _amount = Mathf.Clamp(value,MinAmount,MaxAmount);
            _onStorageUpdate?.Invoke();
        }
    }

}
[System.Serializable]
public abstract class ListBasedResource<T> : AResource where T : new()
{
    [SerializeField] protected List<T> elements = new List<T>();

    public override int Amount
    {
        get
        {
            return elements.Count;
        }
        set
        {
            value = Mathf.Clamp(value, MinAmount, MaxAmount);
            if (elements.Count > value)
            {
                do
                {
                    elements.RemoveAt(Random.Range(0, elements.Count));
                }
                while (elements.Count > value);
            }
            else if (elements.Count < value)
            {
                do
                {
                    elements.Add( new T());
                }

                while (elements.Count < value);
            }
            _onStorageUpdate?.Invoke();
        }
    }
}
[System.Serializable]
public class Wood : IntBasedResource
{
    public override ResourceType ResourceType { get { return ResourceType.Wood; } }
    public override int Amount
    {
        get => base.Amount;
        set
        {
            base.Amount = value;
            if (_onStorageUpdate != null)
            {
                if (Amount <= 0)
                {
                    GameManager.Instance.GameOver();
                }
            }
        }
    }
}
[System.Serializable]
public class Food : IntBasedResource
{
    public override ResourceType ResourceType { get { return ResourceType.Food; } }
}
[System.Serializable]
public class Population : ListBasedResource<Human>
{
    public override ResourceType ResourceType { get { return ResourceType.Population; } }
    [SerializeField]public int occupedPopulation;
    public int freePopulation
    {
        get
        {
            return Amount - occupedPopulation;
        }
    }
}
[System.Serializable]
public class Human
{

}
