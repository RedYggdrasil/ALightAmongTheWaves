using UnityEngine;

namespace RedSpace
{
    public class MouseOverTo : TMouseTo<IMouseOverReceiver>, IMouseOverTo
    {
        protected virtual void OnMouseOver()
        {
            Receiver.OnMouseOverReceived(this);
        }
    }
}