using UnityEngine;
using UnityEditor;

namespace RedSpace
{
    public class TemplateCallToInspector<T> : Editor where T : class
    {
        //[SerializeField] private ITriggerParent parent;
        public override void OnInspectorGUI()
        {
            bool somethingChanged = false;
            SerializedProperty serializedPropety = serializedObject.FindProperty("_receiver");

            UnityEngine.Object old = serializedPropety.objectReferenceValue;
            T oldAsInterface = old as T;
            if (oldAsInterface == null && old != null) { somethingChanged = true; }

            EditorGUILayout.ObjectField(serializedPropety, new GUIContent(serializedPropety.displayName + " (" + typeof(T).Name + ")", "use monobehavior implementing the interface : " + typeof(T).Name));
            UnityEngine.Object newVal = serializedPropety.objectReferenceValue;
            if (newVal == null && oldAsInterface != null) { oldAsInterface = null; somethingChanged = true; }
            T newValCast = newVal as T;
            if (newVal != null && newValCast == null)
            {
            }
            else { oldAsInterface = newValCast; somethingChanged = true; }
            if (somethingChanged) { serializedPropety.objectReferenceValue = oldAsInterface as UnityEngine.Object; serializedObject.ApplyModifiedProperties(); }
        }

    }

}