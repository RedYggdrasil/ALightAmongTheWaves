using UnityEngine;
using UnityEditor;


namespace RedSpace
{
    [CustomEditor(typeof(TriggerTo))]
    [CanEditMultipleObjects]
    public class TriggerToInspector : Editor
    {
        //[SerializeField] private ITriggerParent parent;
        public override void OnInspectorGUI()
        {
            bool somethingChanged = false;
            SerializedProperty parentPropety = serializedObject.FindProperty("_receiver");

            UnityEngine.Object old = parentPropety.objectReferenceValue;
            ITriggerEnterReceiver oldAsEnterInterface = old as ITriggerEnterReceiver;
            ITriggerStayReceiver oldAsStayInterface = old as ITriggerStayReceiver;
            ITriggerExitReceiver oldAsExitInterface = old as ITriggerExitReceiver;
            if ((oldAsEnterInterface == null  || oldAsStayInterface == null || oldAsExitInterface == null) && old != null) { somethingChanged = true; }

            EditorGUILayout.ObjectField(parentPropety, new GUIContent(parentPropety.displayName + " (ITrigger[Enter&Stay&Exit]Receiver)", "use monobehavior implementing these interfaces : ITriggerEnterReceiver, ITriggerStayReceiver, ITriggerExitReceiver"));
            UnityEngine.Object newVal = parentPropety.objectReferenceValue;
            if (newVal == null && oldAsEnterInterface != null)  { oldAsEnterInterface   = null; somethingChanged = true; }
            if (newVal == null && oldAsStayInterface != null)   { oldAsStayInterface    = null; somethingChanged = true; }
            if (newVal == null && oldAsExitInterface != null)   { oldAsExitInterface    = null; somethingChanged = true; }

            ITriggerEnterReceiver newValCastAsEnter = newVal as ITriggerEnterReceiver;
            ITriggerStayReceiver newValCastAsStay = newVal as ITriggerStayReceiver;
            ITriggerExitReceiver newValCastAsExit = newVal as ITriggerExitReceiver;

            if (newVal != null && (newValCastAsEnter == null || newValCastAsStay == null || newValCastAsExit == null))
            {
            }
            else { oldAsEnterInterface = newValCastAsEnter; somethingChanged = true; }

            if (somethingChanged) { parentPropety.objectReferenceValue = oldAsEnterInterface as UnityEngine.Object; serializedObject.ApplyModifiedProperties(); }
        }

    }
}