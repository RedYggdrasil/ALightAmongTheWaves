using UnityEngine;

namespace RedSpace
{
    public class TTrigger2DTo<T> : ATrigger2DTo where T : class
    {
        public T Receiver
        {
            get { return _receiver as T; }
        }

        public ATrigger2DTo GetAsComponent()
        {
            return this;
        }
    }
}
