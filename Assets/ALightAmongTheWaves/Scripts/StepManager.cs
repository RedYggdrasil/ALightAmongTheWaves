using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RedSpace;

public class StepManager : Singleton<StepManager>
{
    public SpriteRenderer[] backgrounds;
    protected EventConsequence _eventConsequence = null;
    protected bool _waitingForNextStepClick = false;
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
        while (true)
        {
            int selectedBackGround = Random.Range(0, backgrounds.Length);
            for (int i = 0; i < backgrounds.Length; ++i)
            {
                backgrounds[i].gameObject.SetActive(i == selectedBackGround);
            }

            //  Evenement

            GameUIManager.Instance.OnEventPart();
            _eventConsequence = null;
            EvenementHandler.Instance.StartEvent(TurnContainer.Instance.turnCounter.turn, TagContainer.Instance.tags, OnEventEnded);
            while (_eventConsequence == null)
            {
                yield return new WaitForEndOfFrame();
            }

            Debug.Log("UpdateIncome");
            UpdateIncome();
            Debug.Log(_eventConsequence);
            EventConsequence(_eventConsequence);
            _eventConsequence = null;

            _waitingForNextStepClick = true;
            GameUIManager.Instance.OnConstructionPart();
            //  Gestion de la base

            while (_waitingForNextStepClick)
            {
                yield return new WaitForEndOfFrame();
            }

            GameUIManager.Instance.OnEndStepPart();
            ++TurnContainer.Instance.turnCounter.turn;
            SaveManager.Instance.Save();
        }
    }

    protected void UpdateIncome()
    {
        StorageManager.Instance.storage.food.Amount += Ship.Instance.shipEconomyIncome.foodIncome;
        StorageManager.Instance.storage.wood.Amount += Ship.Instance.shipEconomyIncome.woodIncome;
    }
    protected void EventConsequence(EventConsequence ec)
    {
        StorageManager.Instance.storage.food.Amount += ec.foodChange;
        StorageManager.Instance.storage.wood.Amount += ec.woodChange;
        StorageManager.Instance.storage.population.Amount += ec.populationChange;
        for (int i = 0; i < ec.tagChanges.Count; ++i)
        {
            if (ec.tagChanges[i].isAnAddition)
            {
                bool alreadyExist = false;
                for(int j = 0; j < TagContainer.Instance.tags.Count; ++j)
                {
                    if (TagContainer.Instance.tags[j] == ec.tagChanges[i].tag)
                    {
                        alreadyExist = true;
                        break;
                    }
                }
                if (!alreadyExist)
                {
                    TagContainer.Instance.tags.Add(ec.tagChanges[i].tag);
                }
                
            }
            else
            {
                for (int j = 0; j < TagContainer.Instance.tags.Count; ++j)
                {
                    if (TagContainer.Instance.tags[j] == ec.tagChanges[i].tag)
                    {
                        TagContainer.Instance.tags.RemoveAt(j);
                        break;
                    }
                }
            }
        }
    }
    protected void OnEventEnded(EventConsequence ec)
    {
        _eventConsequence = ec;
    }
    public void OnNextStepClicked()
    {
        _waitingForNextStepClick = false;
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