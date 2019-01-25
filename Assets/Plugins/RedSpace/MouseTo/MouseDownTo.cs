using UnityEngine;

namespace RedSpace
{
    public class MouseDownTo : TMouseTo<IMouseDownReceiver>, IMouseDownTo
    {
        protected virtual void OnMouseDown()
        {
            Receiver.OnMouseDownReceived(this);
        }
    }
}