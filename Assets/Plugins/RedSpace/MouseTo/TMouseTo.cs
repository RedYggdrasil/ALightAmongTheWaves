using UnityEngine;

namespace RedSpace
{
    public class TMouseTo<T> : AMouseTo where T : class
    {
        public T Receiver
        {
            get { return _receiver as T; }
        }

        public AMouseTo GetAsComponent()
        {
            return this;
        }
    }
}
