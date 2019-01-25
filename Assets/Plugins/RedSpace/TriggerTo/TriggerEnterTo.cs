using UnityEngine;

namespace RedSpace
{
    public class TriggerEnterTo : TTriggerTo<ITriggerEnterReceiver>, ITriggerEnterTo
    {
        protected virtual void OnTriggerEnter(Collider other)
        {
            Receiver.OnTriggerEnterReceived(other, this);
        }
    }
}
