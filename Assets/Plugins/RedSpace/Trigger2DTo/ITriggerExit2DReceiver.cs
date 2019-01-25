using UnityEngine;

namespace RedSpace
{
    public interface ITriggerExit2DReceiver
    {
        void OnTriggerExit2DReceived(Collider2D other, ITriggerExit2DTo trigger2DToReceiver);
    }
}

