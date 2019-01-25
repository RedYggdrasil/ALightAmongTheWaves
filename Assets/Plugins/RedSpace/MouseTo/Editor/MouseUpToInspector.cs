using System.Collections;
using UnityEngine;
using UnityEditor;

namespace RedSpace
{
    [CustomEditor(typeof(MouseUpTo))]
    [CanEditMultipleObjects]
    public class MouseUpToInspector : TemplateCallToInspector<IMouseUpReceiver>
    {
    }

}