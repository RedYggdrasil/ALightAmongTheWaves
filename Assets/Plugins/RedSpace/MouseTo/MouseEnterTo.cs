using UnityEngine;

namespace RedSpace
{
    public class MouseEnterTo : TMouseTo<IMouseEnterReceiver>, IMouseEnterTo
    {
        protected virtual void OnMouseEnter()
        {
            Receiver.OnMouseEnterReceived(this);
        }
    }
}