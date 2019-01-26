using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.ALightAmongTheWaves.Scripts.Events
{
    [Serializable]
    public class EventSystem
    {
        public int id;
        public string name;
        [TextArea]
        public string about;
        public List<Choice> choice; 
        public int weight;


       /* public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }*/
    }
}
