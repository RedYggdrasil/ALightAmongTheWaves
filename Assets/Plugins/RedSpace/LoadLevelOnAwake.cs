using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadLevelOnAwake : MonoBehaviour
{
    [SerializeField] public bool loadOnStart = false;

    [SerializeField] public int loadLevel;
    [SerializeField]public string[] sceneName;
    protected virtual void Awake()
    {
#if UNITY_EDITOR
        SwitchWorkingToPlayingScene.hasBeenOnStartScene = true;
#endif
        if (loadOnStart)
        {
            SceneManager.LoadScene(sceneName[loadLevel]);
        }
    }

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(sceneName[index]);
    }
}
