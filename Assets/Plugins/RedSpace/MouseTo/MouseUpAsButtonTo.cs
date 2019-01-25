using UnityEngine;

namespace RedSpace
{
    public class MouseUpAsButtonTo : TMouseTo<IMouseUpAsButtonReceiver>, IMouseUpAsButtonTo
    {
        protected virtual void OnMouseUpAsButton()
        {
            Receiver.OnMouseUpAsButtonReceived(this);
        }
    }
}