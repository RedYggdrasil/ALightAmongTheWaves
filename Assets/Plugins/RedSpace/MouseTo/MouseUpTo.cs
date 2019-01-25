using UnityEngine;

namespace RedSpace
{
    public class MouseUpTo : TMouseTo<IMouseUpReceiver>, IMouseUpTo
    {
        protected virtual void OnMouseUp()
        {
            Receiver.OnMouseUpReceived(this);
        }
    }
}