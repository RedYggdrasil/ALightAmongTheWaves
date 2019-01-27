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
    [SerializeField] protected ScriptableEvent scriptableEvent;
    [SerializeField] [NaughtyAttributes.ReadOnly] protected List<EventSystem> listeEvenements;
    public System.Action<EventConsequence> ToCallOnEndEvent = null;
    private EventSystem eventSelected;
    private System.Action<EventConsequence> callbackTemp;
    public Button buttonChoisePrefab;
    private List<GameObject> buttons = new List<GameObject>();
    public Canvas canv;

    public Transform buttonsContainer;
    public TextMeshProUGUI textContainer;

    public EventSystem EventSelected { get => eventSelected; set => eventSelected = value; }

    protected override void Awake()
    {
        base.Awake();
        if (_instance != this) { return; }
        listeEvenements = scriptableEvent.GetDeepCopy();
    }

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
        canv.gameObject.SetActive(true);
        textContainer.text = eventSelected.about;
        for (int i = 0;  i < eventSelected.choice.Count; ++i)
        {
            GameObject buttonInstanciate = GameObject.Instantiate(buttonChoisePrefab.gameObject, buttonsContainer);
            buttonInstanciate.name = "" + i;
            buttonInstanciate.GetComponent<Button>().onClick.AddListener( () => { ChoiseActivate(Int32.Parse(buttonInstanciate.name)); } );
            buttonInstanciate.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = eventSelected.choice[i].text;
            buttons.Add(buttonInstanciate);

        }
        LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)buttonsContainer);
    }


    public void ChoiseActivate (int i)
    {
        StartCoroutine(ChooseActivateCoroutine(i));
    }
    private IEnumerator ChooseActivateCoroutine(int i)
    {
        yield return new WaitForEndOfFrame();
        for (int j = buttons.Count - 1; j >= 0; --j)
        {
            GameObject.Destroy(buttons[j]);
        }
        buttons.Clear();
        canv.gameObject.SetActive(false);
        callbackTemp(eventSelected.choice[i].eventConsequence);
    }




    public void GetEvenementParPoids(List<EventSystem> ess) 
    {
        EventSystem selectedEvenement = new EventSystem();
        int poidsRandom = UnityEngine.Random.Range(0, Poidtotal(ess));
        foreach (EventSystem eve in ess)
        {
            if (poidsRandom <= eve.weight)
            {
                 EventSelected = eve;
                return;
            }

            poidsRandom = poidsRandom - eve.weight;        
        }
        throw new System.Exception("error");

 
    }



    public int Poidtotal(List<EventSystem> ess)
    {
        int poids = 0;

        foreach(EventSystem eve in ess)
        {
            poids += eve.weight;
        }

        return poids;
    }

}  



