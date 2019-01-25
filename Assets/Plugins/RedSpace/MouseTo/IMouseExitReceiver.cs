using UnityEngine;

namespace RedSpace
{
    public interface IMouseExitReceiver
    {
        void OnMouseExitReceived(IMouseExitTo mouseToReceiver);
    }
}
