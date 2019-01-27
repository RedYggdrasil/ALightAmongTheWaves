using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RedSpace;

public class SaveManager : PersistentSingleton<SaveManager>
{
#if UNITY_EDITOR
    [UnityEditor.MenuItem("ALATW/DeletePlayerPrefs")]
    static void DeletePlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
#endif
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
    public void ApplySaveToGame()
    {
        StorageManager.Instance.SetStorage(_saveData.storage);
        TagContainer.Instance.SetTags(_saveData.progressionTags);
        TurnContainer.Instance.SetTurnCounter(_saveData.turnCounter);
    }
    public void CreateNewSave()
    {
        _saveData = new SaveData();
        _saveData.storage = StorageManager.Instance.CreateAStartStorage();

        _saveData.progressionTags = TagContainer.Instance.CreateAStartTagList();

        _saveData.turnCounter = TurnContainer.Instance.CreateATurnCounter();
    }
    public void Save()
    {
        string json = JsonUtility.ToJson(_saveData);
        Debug.Log(json);
        PlayerPrefs.SetString(playerPrefKey, json);
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
        //Debug.Log("0");
        if (aSave != null)
        {
            //Debug.Log("1");
            if (aSave.storage != null)
            {
                //Debug.Log("2");
                if (aSave.storage.food != null && aSave.storage.wood != null && aSave.storage.population != null)
                {
                    //Debug.Log("3");
                    if (aSave.progressionTags != null)
                    {
                        //Debug.Log("4");
                        if (aSave.turnCounter != null)
                        {
                            //Debug.Log("return true");
                            return true;
                        }
                    }
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
    public List<Consequence> progressionTags;
    public TurnCounter turnCounter;

}
