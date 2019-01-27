using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RedSpace;
using TMPro;

public class GameUIManager : Singleton<GameUIManager>
{
    [SerializeField] protected TextMeshProUGUI wood;
    [SerializeField] protected TextMeshProUGUI food;
    [SerializeField] protected TextMeshProUGUI population;
    [SerializeField] protected TextMeshProUGUI inactivePopulation;
    [SerializeField] protected TextMeshProUGUI currentStep;
    [SerializeField] protected Button nextStepButton;
    public void OnOptionCliked ()
    {

    }
    public void OnConstructionClicked()
    {

    }
    public void OnNextStepClicked()
    {
        StepManager.Instance.OnNextStepClicked();
    }
    // Start is called before the first frame update
    void Start()
    {
        StorageManager.Instance.storage.onStorageUpdate += OnStorageUdpate;
        OnStorageUdpate();
    }
     protected void OnStorageUdpate()
    {
        wood.text = StorageManager.Instance.storage.wood.Amount + "/" + StorageManager.Instance.storage.wood.MaxAmount;
        food.text = StorageManager.Instance.storage.food.Amount + "/" + StorageManager.Instance.storage.food.MaxAmount;
        population.text = StorageManager.Instance.storage.population.Amount + "/" + StorageManager.Instance.storage.population.MaxAmount;
        inactivePopulation.text = "" + StorageManager.Instance.storage.population.freePopulation;
        currentStep.text = "Current turn : " + TurnContainer.Instance.turnCounter.turn;
    }

    public void OnEventPart()
    {
        nextStepButton.interactable = false;
    }
    public void OnConstructionPart()
    {
        nextStepButton.interactable = true;
    }
    public void OnEndStepPart()
    {
        nextStepButton.interactable = false;
    }

    protected void OnDestroy()
    {
        if (StorageManager.existInstance && StorageManager.Instance.storage != null)
        {
            StorageManager.Instance.storage.onStorageUpdate -= OnStorageUdpate;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
