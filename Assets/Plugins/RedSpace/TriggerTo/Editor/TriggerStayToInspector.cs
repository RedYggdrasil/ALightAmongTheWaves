using UnityEngine;
using UnityEditor;

namespace RedSpace
{
    [CustomEditor(typeof(TriggerStayTo))]
    [CanEditMultipleObjects]
    public class TriggerStayToInspector : TemplateCallToInspector<ITriggerStayReceiver>
    {
    }

}