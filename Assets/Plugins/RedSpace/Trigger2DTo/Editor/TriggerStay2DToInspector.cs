using UnityEngine;
using UnityEditor;

namespace RedSpace
{
    [CustomEditor(typeof(TriggerStay2DTo))]
    [CanEditMultipleObjects]
    public class TriggerStay2DToInspector : TemplateCallToInspector<ITriggerStay2DReceiver>
    {
    }

}