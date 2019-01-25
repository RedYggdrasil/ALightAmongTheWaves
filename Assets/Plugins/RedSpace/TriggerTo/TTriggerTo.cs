using UnityEngine;

namespace RedSpace
{
    public class TTriggerTo<T> : ATriggerTo where T : class
    {
        public T Receiver
        {
            get { return _receiver as T; }
        }

        public ATriggerTo GetAsComponent()
        {
            return this;
        }
    }
}
