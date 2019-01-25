using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedSpace
{
    public abstract class ObjActivator : MonoBehaviour
    {
        public enum ActiveState { Inactive = 0, Active = 1, Undetermind = 2 }
        //[SerializeField] protected float progressionComportmentChange; // use this if you have a progression float value in a singleton somewhere
        [SerializeField] protected ActiveState _areActiveComponents = ActiveState.Undetermind;

        public ActiveState objsActiveState { get { return _areActiveComponents; } }
        /// <summary>
        /// /!\ Undetermind states will return inactive by default !
        /// </summary>
        public bool areActiveComponents { get { return (_areActiveComponents == ActiveState.Active); } }
        /// <summary>
        /// /!\ Undetermind states will return active by default !
        /// </summary>
        public bool areInactiveComponents { get { return (_areActiveComponents == ActiveState.Inactive); } }

        public abstract void Active(System.Action callback = null);
        public abstract void Desactive(System.Action callback = null);

        /*
        public abstract void ActiveIfSuperiorProgression(System.Action callback = null);
        public abstract void ActiveIfInferiorProgression(System.Action callback = null);
        public abstract void DesactiveIfSuperiorProgression(System.Action callback = null);
        public abstract void DesactiveIfInferiorProgression(System.Action callback = null);
        */
    }
}
