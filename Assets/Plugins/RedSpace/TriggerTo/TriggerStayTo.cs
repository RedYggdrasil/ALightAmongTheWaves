using UnityEngine;

namespace RedSpace
{
    public class TriggerStayTo : TTriggerTo<ITriggerStayReceiver>, ITriggerStayTo
    {
        protected virtual void OnTriggerStay(Collider other)
        {
            Receiver.OnTriggerStayReceived(other, this);
        }
    }
}
