﻿using System.Collections.Generic;

using UnityEditor.UIElements;
using UnityEngine.UIElements;
using UnityEditor;


public class SpellEditorWindow : EditorWindow
{
    private static List<SpellNodeData> _nodes;
    private static List<GroupData> _groupes;
    private static SpellGraphView _graphView;

    private readonly string _fileName = "Default File Name";

    public static void Open(List<SpellNodeData> nodes, List<GroupData> groupes)
    {
        _nodes = nodes;
        _groupes = groupes;

        GetWindow<SpellEditorWindow>($"Spell Graph Window");
    }

    public void OnEnable()
    {
        AddGraphView();
        AddToolbar();
    }

    private void AddGraphView()
    {
        _graphView = new SpellGraphView(this, _nodes, _groupes);

        _graphView.StretchToParentSize();

        rootVisualElement.Add(_graphView);
    }

    private void AddToolbar()
    {
        Toolbar toolbar = new Toolbar();

        Button saveButton = NodeElementsUtility.CreateButton("Save", () =>
        {
            _graphView.Save();
        });

        toolbar.Add(saveButton);

        rootVisualElement.Add(toolbar);
    }
}