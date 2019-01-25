using UnityEngine;

namespace RedSpace
{
    public class TriggerStay2DTo : TTrigger2DTo<ITriggerStay2DReceiver>, ITriggerStay2DTo
    {
        protected virtual void OnTriggerStay2D(Collider2D other)
        {
            Receiver.OnTriggerStay2DReceived(other, this);
        }
    }
}
