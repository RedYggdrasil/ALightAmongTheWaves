using UnityEngine;

namespace RedSpace
{
    public class TriggerExit2DTo : TTrigger2DTo<ITriggerExit2DReceiver>, ITriggerExit2DTo
    {
        protected virtual void OnTriggerExit2D(Collider2D other)
        {
            Receiver.OnTriggerExit2DReceived(other, this);
        }
    }
}
