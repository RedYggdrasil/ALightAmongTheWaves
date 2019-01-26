using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedSpace
{
    public static class QuitTool
    {
        public static void Quit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
        }
    }
    public class QuitOnEsc : PersistentHumbleSingleton<QuitOnEsc>
    {
	    
	    // Update is called once per frame
	    void Update () {
		    if(Input.GetKeyUp(KeyCode.Escape))
            {
                QuitTool.Quit();
            }
        }
    }
}
