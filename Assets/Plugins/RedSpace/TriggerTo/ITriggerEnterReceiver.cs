using UnityEngine;

namespace RedSpace
{
    public interface ITriggerEnterReceiver
    {
        void OnTriggerEnterReceived(Collider other, ITriggerEnterTo triggerToReceiver);
    }
}
