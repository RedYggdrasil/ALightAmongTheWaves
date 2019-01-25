using UnityEngine;
using UnityEditor;

namespace RedSpace
{
    [CustomEditor(typeof(MouseExitTo))]
    [CanEditMultipleObjects]
    public class MouseExitToInspector : TemplateCallToInspector<IMouseExitReceiver>
    {
    }

}