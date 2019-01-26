using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResourceType { Unset = 0, Food = 1, Wood = 2, Population = 3 }
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
}
public abstract class AResource : IResource
{
    public abstract ResourceType ResourceType { get; }
    public abstract int Amount { get; set; }
    protected int _minAmount;
    protected int _maxAmount;
    public virtual int MinAmount { get { return _minAmount; } set { _minAmount = Mathf.Clamp(value, 0, int.MaxValue); EnforceAmountBoudaries(); } }
    public virtual int MaxAmount { get { return _maxAmount; } set { _maxAmount = Mathf.Clamp(value, 0, int.MaxValue); EnforceAmountBoudaries(); } }

    protected virtual void EnforceAmountBoudaries()
    {
        Amount = Mathf.Clamp(Amount, MinAmount, MaxAmount);
    }
}
public abstract class IntBasedResource : AResource
{
    protected int _amount;
    public override int Amount
    {
        get
        {
            return _amount;
        }
        set
        {
            _amount = value;
        }
    }

}
public abstract class ListBasedResource<T> : AResource where T : new()
{
    protected List<T> elements = new List<T>();

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

                while (elements.Count > value);
            }
        }
    }
}
public class Wood : IntBasedResource
{
    public override ResourceType ResourceType { get { return ResourceType.Wood; } }
}
public class Food : IntBasedResource
{
    public override ResourceType ResourceType { get { return ResourceType.Food; } }
}
public class Population : ListBasedResource<Human>
{
    public override ResourceType ResourceType { get { return ResourceType.Population; } }
}
public class Human
{

}
