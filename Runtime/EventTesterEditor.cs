using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
namespace BilliotGames
{
    [CustomEditor(typeof(EventTester))]
    public class EventTesterEditor : Editor
    {
        SerializedProperty testEventKey;
        SerializedProperty parameterType;
        SerializedProperty testInt;
        SerializedProperty testString;

        void OnEnable() {
            testEventKey = serializedObject.FindProperty("testEventKey");
            parameterType = serializedObject.FindProperty("parameterType");
            testInt = serializedObject.FindProperty("testInt");
            testString = serializedObject.FindProperty("testString");
        }

        public override void OnInspectorGUI() {
            serializedObject.Update();

            EditorGUILayout.PropertyField(testEventKey);
            EditorGUILayout.PropertyField(parameterType);

            switch ((EventTester.ParameterType)parameterType.enumValueIndex) {
                case EventTester.ParameterType.Int:
                    EditorGUILayout.PropertyField(testInt);
                    break;
                case EventTester.ParameterType.String:
                    EditorGUILayout.PropertyField(testString);
                    break;
            }

            serializedObject.ApplyModifiedProperties();

            EditorGUILayout.Space();

            var _script = (EventTester)target;
            if (GUILayout.Button("Register Test Event")) _script.RegisterNewEvent();
            if (GUILayout.Button("Invoke Test Event")) _script.InvokeEvent();
        }
    }
}
#endif