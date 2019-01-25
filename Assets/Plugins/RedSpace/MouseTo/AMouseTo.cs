using UnityEngine;

namespace RedSpace
{
    public abstract class AMouseTo : MonoBehaviour
    {
        [SerializeField] protected MonoBehaviour _receiver;
    }
}