using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RedSpace;
using Assets.ALightAmongTheWaves.Scripts.Events;

public class EvenementHandler : Singleton<EvenementHandler>
{

    public List<EventSystem> listeEvenements;
    public System.Action<EvenmentConsequence> ToCallOnEndEvent = null;
    private EventSystem eveneSelected;

    public EventSystem EveneSelected { get => eveneSelected; set => eveneSelected = value; }

    /* public void StartEvent(int turn, List<string> tags, System.Action<EvenmentConsequence> callback)
     {
         ToCallOnEndEvent = callback;
         List<Event> temps = new List<Event>();
         //populate temps
         for (int i = 0; i < listeEvenements.Count; i++)
         {
             /*if (listeEvenements[i].neededTag == null || listeEvenements[i].neededTag == "")
             {
                 temps.Add(listeEvenements[i]);
             }
             else
             {
                 for (int y = 0; y < tags.Count; ++y)
                 {
                     if (listeEvenements[i].neededTag == tags[y])
                     {
                         temps.Add(listeEvenements[i]);
                         break;
                     }
                 }
             }
     }

     }*/


    public void StartEvent(int idchoix )
    {

    }


    [System.Serializable]
    public class EvenmentConsequence
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


    public void GetEvenementParPoids() 
    {
        EventSystem selectedEvenement = new EventSystem();
        int poidsRandom = Random.Range(0, Poidtotal());
        foreach (EventSystem eve in listeEvenements)
        {
            if (poidsRandom <= eve.weight)
            {
                this.eveneSelected = eve;
            }

            poidsRandom = poidsRandom - eve.weight;        
        }

    }



    public int Poidtotal()
    {
        int poids = 0;

        foreach(EventSystem eve in listeEvenements)
        {
            poids += eve.weight;
        }

        return poids;
    }

}  



