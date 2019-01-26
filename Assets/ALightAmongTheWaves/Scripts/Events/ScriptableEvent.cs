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
        public List<Event> events;

    }


}
