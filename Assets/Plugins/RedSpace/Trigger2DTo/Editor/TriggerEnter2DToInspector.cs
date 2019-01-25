using UnityEngine;
using UnityEditor;

namespace RedSpace
{
    [CustomEditor(typeof(TriggerEnter2DTo))]
    [CanEditMultipleObjects]
    public class TriggerEnter2DToInspector : TemplateCallToInspector<ITriggerEnter2DReceiver>
    {
    }

}