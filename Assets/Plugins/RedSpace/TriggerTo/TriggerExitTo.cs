using UnityEngine;

namespace RedSpace
{
    public class TriggerExitTo : TTriggerTo<ITriggerExitReceiver>, ITriggerExitTo
    {
        protected virtual void OnTriggerExit(Collider other)
        {
            Receiver.OnTriggerExitReceived(other, this);
        }
    }
}
