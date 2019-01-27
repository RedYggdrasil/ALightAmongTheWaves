using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class Choice
{
    public string text;
    public EventConsequence eventConsequence;

    public Choice(string txt, EventConsequence e)
    {
        eventConsequence = e;
        text = txt;
    }
    private Choice()
    {

    }
    public Choice GetDeepCopy()
    {
        Choice c = new Choice();
        c.text = text;
        c.eventConsequence = eventConsequence.GetDeepCopy();
        return c;
    }

}
[System.Serializable]
public class EventConsequence
{
    public List<TagChange> tagChanges;
    public int foodChange;
    public int woodChange;
    public int populationChange;

    public EventConsequence GetDeepCopy()
    {
        EventConsequence ec = new EventConsequence();
        ec.foodChange = foodChange;
        ec.woodChange = woodChange;
        ec.populationChange = populationChange;
        ec.tagChanges = new List<TagChange>();
        for (int i = 0; i < tagChanges.Count; ++i)
        {
            ec.tagChanges[i] = tagChanges[i].GetDeepCopy();
        }
        return ec;
    }
}
[System.Serializable]
public class TagChange
{
    public bool isAnAddition;
    public Consequence tag;
    public TagChange GetDeepCopy()
    {
        TagChange tc = new TagChange();
        tc.isAnAddition = isAnAddition;
        tc.tag = tag;
        return tc;
    }
}