using UnityEngine;
using UnityEditor;
using UnityEngine.AI;

using System.Collections.Generic;


#if UNITY_EDITOR
public class OffMeshLinkWindow : EditorWindow
{
    public List<OffMeshLink> OffMeshLinks;
    public Transform WaypointRoot;

    public SerializedObject SerializedObject;

    public OffMeshLink FirstLink = null;
    public OffMeshLink SecondLink = null;

    [MenuItem("Ruinum/OffMeshLink Window")]
    public static void Open()
    {      
        GetWindow<OffMeshLinkWindow>($"OffMeshLink Window");
    }

    private void OnGUI()
    {
        SerializedObject = new SerializedObject(this);

        EditorGUILayout.PropertyField(SerializedObject.FindProperty("WaypointRoot"));

        if (WaypointRoot == null)
        {
            EditorGUILayout.HelpBox("Waypoint root must be selected", MessageType.Warning);
        }
        else
        {
            EditorGUILayout.BeginVertical("box");

            DrawTargets();
            DrawButtons();
            DrawList();

            EditorGUILayout.EndVertical();
        }

        SerializedObject.ApplyModifiedProperties();
    }

    private void DrawButtons()
    {
        EditorGUILayout.BeginVertical("box");

        if (GUILayout.Button("Create OffMeshLink"))
        {
            CreateOffMeshLink();
        }

        if (GUILayout.Button("Set Link"))
        {
            SetLinks();
        }

        EditorGUILayout.EndVertical();
    }

    private void CreateOffMeshLink()
    {
        GameObject offMeshLinkObject = new GameObject("OffMeshLink" + WaypointRoot.childCount, typeof(OffMeshLink));

        offMeshLinkObject.transform.SetParent(WaypointRoot, false);

        OffMeshLink offMeshLink = offMeshLinkObject.GetComponent<OffMeshLink>();

        OffMeshLinks.Add(offMeshLink);
    }

    private void SetLinks()
    {
        if (FirstLink && SecondLink)
        {
            FirstLink.startTransform = FirstLink.transform;
            FirstLink.endTransform = SecondLink.transform;
        }
    }

    private void DrawTargets()
    {
        EditorGUILayout.BeginHorizontal("box");

        EditorGUILayout.PropertyField(SerializedObject.FindProperty("FirstLink"));
        EditorGUILayout.PropertyField(SerializedObject.FindProperty("SecondLink"));

        EditorGUILayout.EndHorizontal();
    }

    private void DrawList()
    {
        foreach (var offMeshLink in OffMeshLinks)
        {
            EditorGUILayout.BeginHorizontal("box");

            EditorGUILayout.ObjectField($"{offMeshLink.name}", offMeshLink, typeof(OffMeshLink));

            if (GUILayout.Button("Select as first"))
            {
                FirstLink = offMeshLink;
            }

            if (GUILayout.Button("Select as second"))
            {
                SecondLink = offMeshLink;
            }

            EditorGUILayout.EndHorizontal();
        }
    }
}
#endif
