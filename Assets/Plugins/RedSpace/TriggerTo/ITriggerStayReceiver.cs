using UnityEngine;

namespace RedSpace
{
    public interface ITriggerStayReceiver
    {
        void OnTriggerStayReceived(Collider other, ITriggerStayTo triggerToReceiver);
    }
}


