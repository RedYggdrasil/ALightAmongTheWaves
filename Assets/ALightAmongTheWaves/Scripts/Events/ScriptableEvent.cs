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
                eventSystems[i] = events[i].GetDeepCopy();
            }
            return eventSystems;
        }

    }


}
