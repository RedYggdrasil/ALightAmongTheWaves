using UnityEngine;

namespace RedSpace
{
    public class TriggerEnter2DTo : TTrigger2DTo<ITriggerEnter2DReceiver>, ITriggerEnter2DTo
    {
        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            Receiver.OnTriggerEnter2DReceived(other, this);
        }
    }
}
