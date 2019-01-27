using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RedSpace;
using Assets.ALightAmongTheWaves.Scripts.Events;
using UnityEngine.UI;
using TMPro;
using System;

public class EvenementHandler : Singleton<EvenementHandler>
{

    public List<EventSystem> listeEvenements;
    public System.Action<EventConsequence> ToCallOnEndEvent = null;
    private EventSystem eventSelected;
    private System.Action<EventConsequence> callbackTemp;
    public Button buttonChoisePrefab;
    private List<GameObject> buttons = new List<GameObject>();
    public Canvas canv;

    public Transform buttonsContainer;
    public Transform textContainer;

    public EventSystem EventSelected { get => eventSelected; set => eventSelected = value; }

    public void StartEvent(int turn, List<Consequence> tags, System.Action<EventConsequence> callback)
    {
        callbackTemp = callback;
        List<EventSystem> temps = new List<EventSystem>();
        //populate temps
        for (int i = 0; i < listeEvenements.Count; i++)
        {
            if (listeEvenements[i].tag == null || listeEvenements[i].tag == Consequence.NOTHING)
            {
                temps.Add(listeEvenements[i]);
            }
            else
            {
                for (int y = 0; y < tags.Count; ++y)
                {
                    if (listeEvenements[i].tag == tags[y])
                    {
                        temps.Add(listeEvenements[i]);
                        break;
                    }
                }
            }
        }
        GetEvenementParPoids(temps);
        StartEventNow();

    }


    public void StartEventNow()
    {
        for(int i = 0;  i < eventSelected.choice.Count; ++i)
        {
            GameObject buttonInstanciate = GameObject.Instantiate(buttonChoisePrefab.gameObject);
            buttonInstanciate.GetComponent<Button>().onClick.AddListener( () => { ChoiseActivate(i); } );
            buttonInstanciate.GetComponent<TextMeshProUGUI>().text = eventSelected.choice[i].text;
            buttons.Add(buttonInstanciate);
        }
    }


    public void ChoiseActivate (int i)
    {
        for(int j = buttons.Count-1;  j>=0; --j)
        {
            GameObject.Destroy(buttons[j]);
        }
        buttons.Clear();

        GameObject.Destroy(canv);
        callbackTemp(eventSelected.choice[i].eventConsequence);
    }




    public void GetEvenementParPoids(List<EventSystem> ess) 
    {
        EventSystem selectedEvenement = new EventSystem();
        int poidsRandom = UnityEngine.Random.Range(0, Poidtotal());
        foreach (EventSystem eve in ess)
        {
            if (poidsRandom <= eve.weight)
            {
                 EventSelected = eve;
            }

            poidsRandom = poidsRandom - eve.weight;        
        }
        throw new System.Exception("error");

 
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



