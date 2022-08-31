#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RandomizePosition))]
[CanEditMultipleObjects]
public partial class RandomizePositionEditor : Editor
{

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        RandomizePosition currentObject = (RandomizePosition)target;

        if (GUILayout.Button("Set current position as root"))
        {
            currentObject.RootPosition = currentObject.transform.position;
        }
    }
}

#endif
