using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Map))]
public class MapEditorView : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        
        Map map = (Map)target;
        if(GUILayout.Button("Create Map"))
        {
            map.GenerateMap();
        }

        if(GUILayout.Button("Clear"))
        {
            map.ClearMap();
        }
    }
}
