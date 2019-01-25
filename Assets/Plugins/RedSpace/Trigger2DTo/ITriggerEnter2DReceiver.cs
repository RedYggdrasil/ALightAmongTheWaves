using UnityEngine;

namespace RedSpace
{
    public interface ITriggerEnter2DReceiver
    {
        void OnTriggerEnter2DReceived(Collider2D other, ITriggerEnter2DTo trigger2DToReceiver);
    }
}
