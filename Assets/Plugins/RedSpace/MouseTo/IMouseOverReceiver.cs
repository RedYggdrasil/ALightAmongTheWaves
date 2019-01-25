using UnityEngine;

namespace RedSpace
{
    public interface IMouseOverReceiver
    {
        void OnMouseOverReceived(IMouseOverTo mouseToReceiver);
    }
}
