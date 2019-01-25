using UnityEngine;

namespace RedSpace
{
    public interface IMouseEnterReceiver
    {
        void OnMouseEnterReceived(IMouseEnterTo mouseToReceiver);
    }
}
