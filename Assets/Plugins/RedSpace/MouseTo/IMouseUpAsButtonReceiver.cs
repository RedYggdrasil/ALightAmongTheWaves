using UnityEngine;

namespace RedSpace
{
    public interface IMouseUpAsButtonReceiver
    {
        void OnMouseUpAsButtonReceived(IMouseUpAsButtonTo mouseToReceiver);
    }
}
