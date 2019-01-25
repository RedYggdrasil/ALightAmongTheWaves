using UnityEngine;

namespace RedSpace
{
    public class MouseExitTo : TMouseTo<IMouseExitReceiver>, IMouseExitTo
    {
        protected virtual void OnMouseExit()
        {
            Receiver.OnMouseExitReceived(this);
        }
    }
}