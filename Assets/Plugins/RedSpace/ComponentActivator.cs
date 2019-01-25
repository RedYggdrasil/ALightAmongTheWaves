using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedSpace
{
    public class ComponentActivator : ObjActivator
    {

        [SerializeField] private List<ComponentActive> components;

        public override void Active(System.Action callback = null)
        {
            _areActiveComponents = ActiveState.Active;
            foreach (ComponentActive ca in components)
            {
                ca.enableComponent(true);
            }
            if (callback != null)
            {
                callback();
            }
        }

        public override void Desactive(System.Action callback = null)
        {
            _areActiveComponents = ActiveState.Inactive;
            foreach (ComponentActive ca in components)
            {
                ca.enableComponent(false);
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
    public class ComponentActive
    {
        public Component component;
        public bool reverser;
        public static void enableComponent(Component c, bool val)
        {
            if (c is Behaviour)
            {
                (c as Behaviour).enabled = val;
            }
            else if (c is Collider)
            {
                (c as Collider).enabled = val;
            }
            else if (c is Renderer)
            {
                (c as Renderer).enabled = val;
            }
        }
        public void enableComponent(bool val)
        {
            if (component is Behaviour)
            {
                (component as Behaviour).enabled = reverser ^ val;
            }
            else if (component is Collider)
            {
                (component as Collider).enabled = reverser ^ val;
            }
            else if (component is Renderer)
            {
                (component as Renderer).enabled = reverser ^ val;
            }
        }
    }
}
