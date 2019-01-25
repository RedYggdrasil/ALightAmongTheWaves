using UnityEngine;
using UnityEditor;


namespace RedSpace
{
    [CustomEditor(typeof(Trigger2DTo))]
    [CanEditMultipleObjects]
    public class Trigger2DToInspector : Editor
    {
        //[SerializeField] private ITriggerParent parent;
        public override void OnInspectorGUI()
        {
            bool somethingChanged = false;
            SerializedProperty parentPropety = serializedObject.FindProperty("_receiver");

            UnityEngine.Object old = parentPropety.objectReferenceValue;
            ITriggerEnter2DReceiver oldAsEnterInterface = old as ITriggerEnter2DReceiver;
            ITriggerStay2DReceiver oldAsStayInterface = old as ITriggerStay2DReceiver;
            ITriggerExit2DReceiver oldAsExitInterface = old as ITriggerExit2DReceiver;
            if ((oldAsEnterInterface == null  || oldAsStayInterface == null || oldAsExitInterface == null) && old != null) { somethingChanged = true; }

            EditorGUILayout.ObjectField(parentPropety, new GUIContent(parentPropety.displayName + " (ITrigger[Enter&Stay&Exit]Receiver)", "use monobehavior implementing these interfaces : ITriggerEnter2DReceiver, ITriggerStay2DReceiver, ITriggerExit2DReceiver"));
            UnityEngine.Object newVal = parentPropety.objectReferenceValue;
            if (newVal == null && oldAsEnterInterface != null)  { oldAsEnterInterface   = null; somethingChanged = true; }
            if (newVal == null && oldAsStayInterface != null)   { oldAsStayInterface    = null; somethingChanged = true; }
            if (newVal == null && oldAsExitInterface != null)   { oldAsExitInterface    = null; somethingChanged = true; }

            ITriggerEnter2DReceiver newValCastAsEnter = newVal as ITriggerEnter2DReceiver;
            ITriggerStay2DReceiver newValCastAsStay = newVal as ITriggerStay2DReceiver;
            ITriggerExit2DReceiver newValCastAsExit = newVal as ITriggerExit2DReceiver;

            if (newVal != null && (newValCastAsEnter == null || newValCastAsStay == null || newValCastAsExit == null))
            {
            }
            else { oldAsEnterInterface = newValCastAsEnter; somethingChanged = true; }

            if (somethingChanged) { parentPropety.objectReferenceValue = oldAsEnterInterface as UnityEngine.Object; serializedObject.ApplyModifiedProperties(); }
        }

    }
}