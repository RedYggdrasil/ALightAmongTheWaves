using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.ALightAmongTheWaves.Scripts.Events
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ScriptableEvent", order = 1)]
    public class ScriptableEvent : ScriptableObject
    {
        public List<EventSystem> events;
        public List<EventSystem> GetDeepCopy()
        {
            List<EventSystem> eventSystems = new List<EventSystem>();
            for (int i = 0; i < events.Count; ++i)
            {
                eventSystems[i] = new EventSystem();
                eventSystems[i].about = events[i].about;
                eventSystems[i].id = events[i].id;
                eventSystems[i].name = events[i].name;
                eventSystems[i].weight = events[i].weight;
                eventSystems[i].tag = events[i].tag;
                eventSystems[i].choice = new List<Choice>();
                for (int j = 0; j < events[i].choice.Count; ++j)
                {
                    EventConsequence ec = new EventConsequence();
                    ec.foodChange = events[i].choice[j].eventConsequence.foodChange;
                    ec.woodChange = events[i].choice[j].eventConsequence.woodChange;
                    ec.populationChange = events[i].choice[j].eventConsequence.populationChange;
                    ec.tagChanges = new List<TagChange>();
                    for (int k = 0; k < events[i].choice[j].eventConsequence.tagChanges.Count; ++k)
                    {
                        ec.tagChanges[k] = new TagChange();
                        ec.tagChanges[k].isAnAddition = events[i].choice[j].eventConsequence.tagChanges[k].isAnAddition;
                        ec.tagChanges[k].tag = events[i].choice[j].eventConsequence.tagChanges[k].tag;
                    }
                    eventSystems[i].choice[j] = new Choice(events[i].choice[j].text, ec);
                }
            }
            return eventSystems;
        }

    }


}
