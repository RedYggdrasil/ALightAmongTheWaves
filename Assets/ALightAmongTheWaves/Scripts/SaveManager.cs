using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RedSpace;

public class SaveManager : PersistentSingleton<SaveManager>
{
    public static readonly string playerPrefKey;

    protected bool _haveAValidSave = false;

    protected SaveData _saveData = null;
    public bool haveAValidSave
    {
        get
        {
            return _haveAValidSave;
        }
    }
    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        if(_instance!= this) { return; }
        TryLoadSaveFromPlayerPref();

    }

    protected void TryLoadSaveFromPlayerPref()
    {
        string saveString = PlayerPrefs.GetString(playerPrefKey);
        SaveData sd = null;
        if (saveString != null && saveString != "")
        {
            sd = JsonUtility.FromJson<SaveData>(saveString);
            if (CheckSaveValidity(sd))
            {

            }
            else
            {
                sd = null;
            }
        }
        _haveAValidSave = ((_saveData = sd) != null);
    }
    protected void ApplySaveToGame()
    {

    }
    protected void CreateNewSave()
    {
        _saveData = new SaveData();
        _saveData.storage = StorageManager.Instance.CreateAStartStorage();
    }
    protected bool CheckSaveValidity(string aSave)
    {
        if (aSave != null && aSave != "")
        {
            SaveData sd = JsonUtility.FromJson<SaveData>(aSave);
            if (sd != null)
            {
                return CheckSaveValidity(sd);
            }
        }
        return false;
    }
    protected bool CheckSaveValidity(SaveData aSave)
    {
        if (aSave != null)
        {
            if(aSave.storage != null)
            {
                if (aSave.storage.food != null && aSave.storage.wood != null && aSave.storage.population != null)
                {
                    return true;
                }
            }
        }
        return false;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
[System.Serializable]
public class SaveData
{
    public Storage storage;

}
