using System;
using System.Collections.Generic;

using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class SpellSearchWindow : ScriptableObject, ISearchWindowProvider
{
    private SpellGraphView _graphView;
    private Vector2 _localMousePosition;

    public void Initialize(SpellGraphView dGGraphView)
    {
        _graphView = dGGraphView;
    }

    public List<SearchTreeEntry> CreateSearchTree(SearchWindowContext context)
    {
        var searchTreeEntries = new List<SearchTreeEntry>();

        searchTreeEntries.Add(new SearchTreeGroupEntry(new GUIContent("Create Element"), 0));
        searchTreeEntries.Add(new SearchTreeGroupEntry(new GUIContent("Node"), 1));

        CreateLogicNodesEntry(searchTreeEntries);

        searchTreeEntries.Add(new SearchTreeGroupEntry(new GUIContent("Group"), 1));
        searchTreeEntries.Add(new SearchTreeEntry(new GUIContent("Group"))
        {
            level = 2,
            userData = new Group()
        });

        return searchTreeEntries;
    }

    public bool OnSelectEntry(SearchTreeEntry SearchTreeEntry, SearchWindowContext context)
    {
        _localMousePosition = _graphView.GetLocalMousePosition(context.screenMousePosition, true);

        if (SearchTreeEntry.userData.GetType() == typeof(Group))
        {
            Group group = (Group)_graphView.CreateGroup("Group", Guid.NewGuid().ToString(), _localMousePosition);

            return true;
        }
        else
        {
            CreateLogicNode(SearchTreeEntry.userData);
        }

        return true;
    }

    private SearchTreeEntry CreateLogicNodesEntry(List<SearchTreeEntry> searchTreeEntries)
    {
        SpellNodeType[] spellNodeTypeArray = (SpellNodeType[])Enum.GetValues(typeof(SpellNodeType));
        List<SpellNodeType> spellNodeTypesList = new List<SpellNodeType>(spellNodeTypeArray);

        for (int i = 0; i < spellNodeTypesList.Count; i++)
        {
            var spellNodeType = spellNodeTypesList[i];

            if (spellNodeType == SpellNodeType.None || spellNodeType == SpellNodeType.Start || spellNodeType == SpellNodeType.End)
            {
                continue;
            }

            var searchTreeEntry = new SearchTreeEntry(new GUIContent($"{spellNodeType} Node"))
            {
                level = 2,
                userData = spellNodeType
            };

            searchTreeEntries.Add(searchTreeEntry);
        }

        return null;
    }

    private bool CreateLogicNode(object userData)
    {
        if (userData.GetType() == typeof(SpellNodeType))
        {
            var spellType = (SpellNodeType)userData;
            var node = _graphView.CreateNode(spellType, _localMousePosition);

            _graphView.AddElement(node);

            return true;
        }

        return false;
    }
}