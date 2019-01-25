using UnityEngine;
using UnityEditor;

namespace RedSpace
{
    [CustomEditor(typeof(TriggerEnterTo))]
    [CanEditMultipleObjects]
    public class TriggerEnterToInspector : TemplateCallToInspector<ITriggerEnterReceiver>
    {
    }

}