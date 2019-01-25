using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWorkingToPlayingScene : MonoBehaviour
{
#if UNITY_EDITOR
    private static bool _hasBeenOnStartScene = false;
    public static bool hasBeenOnStartScene
    {
        set
        {
            _hasBeenOnStartScene = value;
        }
    }
    public static bool canStartScene
    {
        get
        {
            return _hasBeenOnStartScene;
        }
    }
    public string scene;
    public bool onlyIfNotAdditive = false;
    private void Awake()
    {
        if (_hasBeenOnStartScene) { return; }
        if (!onlyIfNotAdditive || UnityEngine.SceneManagement.SceneManager.sceneCount < 2)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
            //hasBeenOnStartScene = true;
        }
    }
#endif
}
