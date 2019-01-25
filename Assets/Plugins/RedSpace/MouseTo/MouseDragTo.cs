using UnityEngine;

namespace RedSpace
{
    public class MouseDragTo : TMouseTo<IMouseDragReceiver>, IMouseDragTo
    {
        protected virtual void OnMouseDrag()
        {
            Receiver.OnMouseDragReceived(this);
        }
    }
}