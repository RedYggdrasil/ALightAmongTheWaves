using UnityEngine;
using UnityEditor;

namespace RedSpace
{
    [CustomEditor(typeof(TriggerExit2DTo))]
    [CanEditMultipleObjects]
    public class TriggerExit2DToInspector : TemplateCallToInspector<ITriggerExit2DReceiver>
    {
    }

}