using UnityEngine;

namespace RedSpace
{
    public interface ITriggerStay2DReceiver
    {
        void OnTriggerStay2DReceived(Collider2D other, ITriggerStay2DTo trigger2DToReceiver);
    }
}


