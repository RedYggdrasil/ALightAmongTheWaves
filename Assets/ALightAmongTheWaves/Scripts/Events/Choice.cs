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

    }
    [System.Serializable]
    public class EventConsequence
    {
        public List<TagChange> tagChanges;
        public int foodChange;
        public int woodChange;
        public int populationChange;
    }
    [System.Serializable]
    public class TagChange
    {
        public bool isAnAddition;
        public Consequence tag;
    }