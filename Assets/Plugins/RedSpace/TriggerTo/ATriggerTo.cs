using UnityEngine;

namespace RedSpace
{
    public abstract class ATriggerTo : MonoBehaviour
    {
        [SerializeField] protected MonoBehaviour _receiver;
    }
}

