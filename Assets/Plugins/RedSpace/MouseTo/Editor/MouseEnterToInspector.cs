using UnityEngine;
using UnityEditor;

namespace RedSpace
{
    [CustomEditor(typeof(MouseEnterTo))]
    [CanEditMultipleObjects]
    public class MouseEnterToInspector : TemplateCallToInspector<IMouseEnterReceiver>
    {
    }

}