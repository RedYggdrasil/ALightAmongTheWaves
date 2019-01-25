using UnityEngine;

namespace RedSpace
{
    public class Trigger2DTo : ATrigger2DTo, ITriggerEnter2DTo, ITriggerStay2DTo, ITriggerExit2DTo
    {
        public ITriggerEnter2DReceiver GetReceiverAsEnterReceiver()
        {
            return _receiver as ITriggerEnter2DReceiver;
        }
        public ITriggerExit2DReceiver GetReceiverAsExitReceiver()
        {
            return _receiver as ITriggerExit2DReceiver;
        }
        public ITriggerStay2DReceiver GetReceiverAsStayReceiver()
        {
            return _receiver as ITriggerStay2DReceiver;
        }

        public ATrigger2DTo GetAsComponent()
        {
            return this;
        }
        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            GetReceiverAsEnterReceiver().OnTriggerEnter2DReceived(other, this);
        }
        protected virtual void OnTriggerStay2D(Collider2D other)
        {
            GetReceiverAsStayReceiver().OnTriggerStay2DReceived(other, this);
        }
        protected virtual void OnTriggerExit2D(Collider2D other)
        {
            GetReceiverAsExitReceiver().OnTriggerExit2DReceived(other, this);
        }

    }
}