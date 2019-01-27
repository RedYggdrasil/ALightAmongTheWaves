using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]
public class EventSystem
{
    public int id;
    public string name;
    [TextArea]
    public string about;
    public List<Choice> choice;
    public int weight;
    public Consequence tag;
    public EventSystem GetDeepCopy()
    {
        EventSystem es = new EventSystem();
        es.about = about;
        es.id = id;
        es.name = name;
        es.weight = weight;
        es.tag = tag;

        es.choice = new List<Choice>();
        for (int i = 0; i < choice.Count; ++i)
        {
            es.choice.Add(choice[i].GetDeepCopy());
        }
        return es;
    }
}


