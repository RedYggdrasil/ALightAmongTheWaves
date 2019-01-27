using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RedSpace;

public class StepManager : Singleton<StepManager>
{
    protected EventConsequence _eventConsequence = null;
    // Start is called before the first frame update

    public void StartSteps()
    {
        StartCoroutine(PlayStepsCoroutine());
    }
    protected IEnumerator PlayStepsCoroutine()
    {
        //  StartEvenement
        //  Update resources + Evenement Consequence (Same Frame) 
        //  Gestion de la base
        //  Resource en Prévision (Panel Résumé)
        //  Save
        Debug.Log("StatSteps !");
        while (true)
        {


            //  Evenement
            _eventConsequence = null;
            EvenementHandler.Instance.StartEvent(TurnContainer.Instance.turnCounter.turn, TagContainer.Instance.tags, OnEventEnded);
            while (_eventConsequence == null)
            {
                yield return new WaitForEndOfFrame();
            }

            //Update Resource

            //Evenement Consequence (Same Frame)

            //  Gestion de la base
            
            ++TurnContainer.Instance.turnCounter.turn;
            SaveManager.Instance.Save();
        }
    }

    protected void OnEventEnded(EventConsequence ec)
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
[System.Serializable]
public class TurnContainer
{
    public static bool existInstance
    {
        get
        {
            return (_instance != null);
        }
    }
    protected static TurnContainer _instance;
    public static TurnContainer Instance
    {
        get
        {
            return ((_instance != null) ? _instance : (_instance = new TurnContainer()));
        }
    }
    protected TurnCounter _turnCounter;
    public TurnCounter turnCounter
    {
        get
        {
            return _turnCounter;
        }
        set
        {
            _turnCounter = value;
        }
    }
    private TurnContainer()
    {

    }
    public void SetTurnCounter(TurnCounter aTurnContainer)
    {
        _turnCounter = aTurnContainer;
    }
    public TurnCounter CreateATurnCounter()
    {
        TurnCounter aTurnCounter = new TurnCounter();
        aTurnCounter.turn = 0;
        return aTurnCounter;
    }
    public TurnCounter GetTurnCounterRefence()
    {
        return _turnCounter;
    }
}
[System.Serializable]
public class TurnCounter
{
    public int turn;
}