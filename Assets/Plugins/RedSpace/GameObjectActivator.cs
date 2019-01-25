using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedSpace
{
    public class GameObjectActivator : ObjActivator
    {
        [SerializeField] private List<GameObjectActive> gameObjects;

        public override void Active(System.Action callback = null)
        {
            _areActiveComponents = ActiveState.Active;
            foreach (GameObjectActive ca in gameObjects)
            {
                ca.enableGameObject(true);
            }
            if (callback != null)
            {
                callback();
            }
        }
        public override void Desactive(System.Action callback = null)
        {
            _areActiveComponents = ActiveState.Inactive;
            foreach (GameObjectActive ca in gameObjects)
            {
                ca.enableGameObject(false);
            }
            if (callback != null)
            {
                callback();
            }
        }
        /*
        public override void ActiveIfSuperiorProgression(System.Action callback = null)
        {
            if (ObjectWithProgression.Instance.progression > progressionComportmentChange)
            { Active(callback); }
            else if (callback != null)
            { callback(); }
        }
        public override void ActiveIfInferiorProgression(System.Action callback = null)
        {
            if (ObjectWithProgression.Instance.progression < progressionComportmentChange)
            { Active(callback); }
            else if (callback != null)
            { callback(); }
        }
        public override void DesactiveIfSuperiorProgression(System.Action callback = null)
        {
            if (ObjectWithProgression.Instance.progression > progressionComportmentChange)
            { Desactive(callback); }
            else if (callback != null)
            { callback(); }
        }
        public override void DesactiveIfInferiorProgression(System.Action callback = null)
        {
            if (ObjectWithProgression.Instance.progression < progressionComportmentChange)
            { Desactive(callback); }
            else if (callback != null)
            { callback(); }
        }
        */
    }
    [System.Serializable]
    public class GameObjectActive
    {
        public GameObject gameObject;
        public bool reverser;
        public static void enableGameObject(GameObject g, bool val)
        {
            g.SetActive(val);
        }
        public void enableGameObject(bool val)
        {
            GameObjectActive.enableGameObject(gameObject, reverser ^ val);
        }
    }
}