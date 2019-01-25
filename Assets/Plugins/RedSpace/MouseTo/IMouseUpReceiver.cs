using UnityEngine;

namespace RedSpace
{
    public interface IMouseUpReceiver
    {
        void OnMouseUpReceived(IMouseUpTo mouseToReceiver);
    }
}
