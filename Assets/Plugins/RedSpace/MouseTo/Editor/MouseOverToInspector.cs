using UnityEngine;
using UnityEditor;

namespace RedSpace
{
    [CustomEditor(typeof(MouseOverTo))]
    [CanEditMultipleObjects]
    public class MouseOverToInspector : TemplateCallToInspector<IMouseOverReceiver>
    {
    }

}