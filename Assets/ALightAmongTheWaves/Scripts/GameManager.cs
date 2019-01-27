using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : RedSpace.PersistentSingleton<GameManager>
{
    public static readonly string menuName = "MainMenu";
    public static readonly string shipLevel = "ShipLevel";
    public enum Scenes { Unknown = 0, Menu = 1, Game = 2 }


    protected override void Awake()
    {
        base.Awake();
        if (_instance != this){ return; }
        //Menu
        //  Continue / New Game / Option / Quit

        // Tour 1 (Tutoriel)
        //  Base Resource
        //  Evenement scripté (4 gars)
        //  Update resources (post évenement)
        //  Gestion de la base (Tutoriel guidé)
        //  Resource en Prévision (Panel Résumé)
        //  Save

        //  Tour 2 (mid Tutorial)
        //  Update resources (pré prise en compte de l'évenement)
        //  Evenement scripté ( à  définir)
        //  End Of Tutorial, game continue as set by systems
        //  Gestion de la base
        //  Resource en Prévision (Panel Résumé)


        //Tour par tour 

        //un tour :
        //  Update resources (pré prise en cmpte de l'évenement)
        //  Evenement
        //  Update resources (post évenement)
        //  Gestion de la base
        //  Resource en Prévision (Panel Résumé)
        //  Save


    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    public void LoadScene(GameManager.Scenes sceneToLoad)
    {
        SceneManager.LoadScene(((sceneToLoad == Scenes.Menu) ? menuName : shipLevel),LoadSceneMode.Single);

    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded");
        if (scene.name == shipLevel)
        {
            OnShipLevelLoaded();
        }
        else if (scene.name == menuName)
        {
            OnMenuLevelLoaded();
        }
    }
    protected void OnShipLevelLoaded()
    {
        Debug.Log("OnShipLevelLoaded");
        SaveManager.Instance.ApplySaveToGame();
        StepManager.Instance.StartSteps();
    }
    protected void OnMenuLevelLoaded()
    {

    }
}
[System.Serializable]
public class TagContainer
{

    protected static TagContainer _instance;
    public static TagContainer Instance
    {
        get
        {
            return ((_instance != null) ? _instance : (_instance = new TagContainer()));
        }
    }
    protected List<Consequence> _tags;
    public List<Consequence> tags
    {
        get
        {
            return _tags;
        }
        set
        {
            _tags = value;
        }
    }
    private TagContainer()
    {

    }
    public void SetTags(List<Consequence> aTagList)
    {
        _tags = aTagList;
    }
    public List<Consequence> CreateAStartTagList()
    {
        List<Consequence> aTags = new List<Consequence>();
        return aTags;
    }
    public List<Consequence> GetTagListRefence()
    {
        return _tags;
    }
}
