using UnityEngine;
using UnityEditor;

using System;
using System.Collections.Generic;


public class ScriptUsedByWindow : EditorWindow
{
    public SerializedObject SerializedObject;

    public List<GameObject> ObjectScriptUse = new List<GameObject>();

    private Vector2 _scrollPosition = Vector2.zero;
    private string _text;
    private bool _isSearched;

    [MenuItem("Ruinum/ScriptUsedBy Window")]
    public static void Open()
    {
        GetWindow<ScriptUsedByWindow>($"ScriptUsedBy Window"); 
    }

    private void OnGUI()
    {
        SerializedObject = new SerializedObject(this);

        _text = EditorGUILayout.TextField("", _text);

        _scrollPosition = GUILayout.BeginScrollView(_scrollPosition, false, true);
        if (_isSearched) DrawList();
        GUILayout.EndScrollView();

        if (GUILayout.Button("Find"))
        {
            ObjectScriptUse.Clear();

            //Find correct type
            Type type = null;
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                type = assembly.GetType(_text);
                if (type != null)
                    break;
            }

            var objects = Resources.LoadAll<GameObject>("");
            foreach (var @object in objects)
            {
                if (type == null) break;
                if (@object.GetComponent(type)) ObjectScriptUse.Add(@object);
            }

            if (type != null)
            {
                _isSearched = true;
            } else EditorGUILayout.HelpBox($"Wrong type", MessageType.Warning);

        }

        SerializedObject.ApplyModifiedProperties();
    }

    private void DrawList()
    {
        if (ObjectScriptUse.Count <= 0) EditorGUILayout.HelpBox($"None of the prefabs use {_text}", MessageType.Info);

        EditorGUILayout.BeginVertical("box");
        foreach (var gameObject in ObjectScriptUse)
        {
            EditorGUILayout.ObjectField($"{gameObject.name}", gameObject, typeof(GameObject), true);
        }
        EditorGUILayout.EndVertical();
    }
}
