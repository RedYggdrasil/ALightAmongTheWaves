using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedSpace
{
    public class QuitOnEsc : PersistentHumbleSingleton<QuitOnEsc>
    {
	
	    // Update is called once per frame
	    void Update () {
		    if(Input.GetKeyUp(KeyCode.Escape))
            {
    #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
    #else
                Application.Quit();
    #endif
            }
        }
    }
}
