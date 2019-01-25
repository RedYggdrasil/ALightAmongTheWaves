using UnityEngine;
using UnityEditor;

namespace RedSpace
{
    [CustomEditor(typeof(MouseDragTo))]
    [CanEditMultipleObjects]
    public class MouseDragToInspector : TemplateCallToInspector<IMouseDragReceiver>
    {
    }

}