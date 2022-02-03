using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CustomMeshEditor : EditorWindow
{
    public Transform meshRoot;
    private MeshCreator meshCreator;

    [MenuItem("Tool/Mesh Creator")]
    public static void ShowWindow()
    {
        //Show existing window instance. If one doesn't exist, make one.
        GetWindow(typeof(CustomMeshEditor));
    }

    void OnGUI()
    {
        SerializedObject obj = new SerializedObject(this);
        EditorGUILayout.PropertyField(obj.FindProperty("meshRoot"));
        EditorGUILayout.BeginVertical();
        if (!meshRoot)
        {
            EditorGUILayout.HelpBox("Root transform must be selected!", MessageType.Warning);
        }
        else
        {
            meshCreator = meshRoot.GetComponent<MeshCreator>();
            //meshCreator.UpdateMesh();

            GUILayout.Label("Create Vertex", EditorStyles.boldLabel);
            if (GUILayout.Button("Create Vertex"))
            {
                meshCreator.CreateVertex();
            }
            GUILayout.Label("Update Vertex", EditorStyles.boldLabel);
            if (GUILayout.Button("Update Vertex"))
            {
                meshCreator.UpdateMesh();
            }
            GUILayout.Label("Add Vertex", EditorStyles.boldLabel);
            if (GUILayout.Button("Add Vertex"))
            {
                meshCreator.AddVertex();
            }
            GUILayout.Label("Clear All Vertices", EditorStyles.boldLabel);
            if (GUILayout.Button("Clear All Vertices"))
            {
                meshCreator.ClearAllVertices();
            }
            GUILayout.Label("Clear Mesh", EditorStyles.boldLabel);
            if (GUILayout.Button("Clear Mesh"))
            {
                meshCreator.ClearMesh();
            }
            EditorGUILayout.EndHorizontal();
        }
        obj.ApplyModifiedProperties(); 
    }
}
