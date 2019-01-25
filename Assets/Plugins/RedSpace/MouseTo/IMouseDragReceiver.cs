using UnityEngine;

namespace RedSpace
{
    public interface IMouseDragReceiver
    {
        void OnMouseDragReceived(IMouseDragTo mouseToReceiver);
    }
}
