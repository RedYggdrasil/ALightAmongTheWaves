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

    }


