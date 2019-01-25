using UnityEngine;

namespace RedSpace
{
    public interface ITriggerExitReceiver
    {
        void OnTriggerExitReceived(Collider other, ITriggerExitTo triggerToReceiver);
    }
}

