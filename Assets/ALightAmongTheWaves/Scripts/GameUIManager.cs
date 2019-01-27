using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RedSpace;
using TMPro;

public class GameUIManager : Singleton<GameUIManager>
{
    [SerializeField] protected TextMeshProUGUI wood;
    [SerializeField] protected TextMeshProUGUI food;
    [SerializeField] protected TextMeshProUGUI population;
    [SerializeField] protected TextMeshProUGUI inactivePopulation;
    public void OnOptionCliked ()
    {

    }
    public void OnConstructionClicked()
    {

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
