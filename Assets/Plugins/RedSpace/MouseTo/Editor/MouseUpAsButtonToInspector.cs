using UnityEngine;
using UnityEditor;

namespace RedSpace
{
    [CustomEditor(typeof(MouseUpAsButtonTo))]
    [CanEditMultipleObjects]
    public class MouseUpAsButtonToInspector : TemplateCallToInspector<IMouseUpAsButtonReceiver>
    {
    }

}