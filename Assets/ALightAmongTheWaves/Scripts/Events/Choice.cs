using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.ALightAmongTheWaves.Scripts.Events
{
    [Serializable]
    public class Choice
    {
        public string text;
        //protected int food;
        //protected int survivor;
        //protected int wood;
        public int dataConsequence;      
        public Consequence consequence;

        public Choice(int d,string txt, Consequence c)
        {
            dataConsequence = d;
            consequence = c;
            text = txt;
        }

        public Choice()
        {

        }

    }
}
