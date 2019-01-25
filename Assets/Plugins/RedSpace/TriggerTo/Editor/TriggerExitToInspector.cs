using UnityEngine;
using UnityEditor;

namespace RedSpace
{
    [CustomEditor(typeof(TriggerExitTo))]
    [CanEditMultipleObjects]
    public class TriggerExitToInspector : TemplateCallToInspector<ITriggerExitReceiver>
    {
    }

}