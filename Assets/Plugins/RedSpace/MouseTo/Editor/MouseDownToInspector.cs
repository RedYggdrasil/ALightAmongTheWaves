using UnityEngine;
using UnityEditor;

namespace RedSpace
{
    [CustomEditor(typeof(MouseDownTo))]
    [CanEditMultipleObjects]
    public class MouseDownToInspector : TemplateCallToInspector<IMouseDownReceiver>
    {
    }

}