using UnityEngine;

namespace RedSpace
{
    public class TriggerTo : ATriggerTo, ITriggerEnterTo, ITriggerStayTo, ITriggerExitTo
    {
        public ITriggerEnterReceiver GetReceiverAsEnterReceiver()
        {
            return _receiver as ITriggerEnterReceiver;
        }
        public ITriggerExitReceiver GetReceiverAsExitReceiver()
        {
            return _receiver as ITriggerExitReceiver;
        }
        public ITriggerStayReceiver GetReceiverAsStayReceiver()
        {
            return _receiver as ITriggerStayReceiver;
        }

        public ATriggerTo GetAsComponent()
        {
            return this;
        }
        protected virtual void OnTriggerEnter(Collider other)
        {
            GetReceiverAsEnterReceiver().OnTriggerEnterReceived(other, this);
        }
        protected virtual void OnTriggerStay(Collider other)
        {
            GetReceiverAsStayReceiver().OnTriggerStayReceived(other, this);
        }
        protected virtual void OnTriggerExit(Collider other)
        {
            GetReceiverAsExitReceiver().OnTriggerExitReceived(other, this);
        }

    }
}