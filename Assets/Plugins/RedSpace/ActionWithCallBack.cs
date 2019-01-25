using UnityEngine;
using UnityEngine.Events;

namespace RedSpace
{
    [System.Serializable]
    public class NotifyWhenDone : UnityEvent<System.Action> { }

    [System.Serializable]
    public class ActionWithCallBack
    {
        [SerializeField] private NotifyWhenDone listeners;
        private System.Action onAllCallbackDone;

        public void CallLiseners(System.Action action)
        {
            if (listeners.GetPersistentEventCount() <= 0) { if (action != null) { action(); } return; }
            onAllCallbackDone = action;
            listeners.Invoke(OnCallback);
        }
        private int callbackCalled = 0;
        private void OnCallback()
        {
            ++callbackCalled;
            if (callbackCalled >= listeners.GetPersistentEventCount())
            {
                if (onAllCallbackDone != null)
                {
                    onAllCallbackDone();
                }
                onAllCallbackDone = null;
                callbackCalled = 0;
            }

        }
    }
}