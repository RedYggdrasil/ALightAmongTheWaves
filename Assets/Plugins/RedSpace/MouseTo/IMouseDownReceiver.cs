using UnityEngine;

namespace RedSpace
{
    public interface IMouseDownReceiver
    {
        void OnMouseDownReceived(IMouseDownTo mouseToReceiver);
    }
}
