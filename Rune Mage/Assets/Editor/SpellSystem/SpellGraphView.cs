using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using UnityEngine;

using System.Collections.Generic;
using System;


public class SpellGraphView : GraphView
{
    private SpellEditorWindow _editorWindow;
    private static List<SpellNodeData> _savedNodes;
    private static List<SpellNodeBase> _currentNodes;

    public SpellGraphView(SpellEditorWindow editorWindow, List<SpellNodeData> nodes)
    {
        _editorWindow = editorWindow;
        _savedNodes = nodes;

        CreateGridView();
        CreateManipulators();

        if(!LoadGraph())
            CreateStartNodes();

        AddStyleSheet();
        AddMinimap();

        OnGraphViewChanged();
    }

    #region GraphView Methods
    public override List<Port> GetCompatiblePorts(Port startPort, NodeAdapter nodeAdapter)
    {
        List<Port> compatiblePorts = new List<Port>();

        ports.ForEach(port =>
        {
            if (startPort == port)
            {
                return;
            }

            if (startPort.node == port.node)
            {
                return;
            }

            if (startPort.direction == port.direction)
            {
                return;
            }

            compatiblePorts.Add(port);
        });

        return compatiblePorts;
    }

    private void OnGraphViewChanged()
    {
        graphViewChanged = (changes) =>
        {
            if (changes.edgesToCreate != null)
            {
                foreach (var edge in changes.edgesToCreate)
                {
                    SpellNodeBase outputNode = (SpellNodeBase)edge.output.node;
                    SpellNodeBase inputNode = (SpellNodeBase)edge.input.node;

                    outputNode.AddInputNode(inputNode);
                }
            }           

            return changes;
        };
    }
    #endregion

    #region Create Methods
    private void CreateGridView()
    {
        GridBackground gridBackground = new GridBackground();

        gridBackground.StretchToParentWidth();

        Insert(0, gridBackground);
    }

    private void CreateManipulators()
    {
        this.AddManipulator(new ContentDragger());
        this.AddManipulator(new ContentZoomer());
        this.AddManipulator(new SelectionDragger());
        this.AddManipulator(new RectangleSelector());

        this.AddManipulator(CreateNodeContextMenu("Add Wait Time Node", SpellNodeType.WaitTime));
        this.AddManipulator(CreateNodeContextMenu("Add Spawn Point Node", SpellNodeType.SpawnPoint));
        this.AddManipulator(CreateGroupContextMenu());
    }

    private void CreateStartNodes()
    {
        AddElement(CreateNode(SpellNodeType.Start, new Vector2(500, 500)));
        AddElement(CreateNode(SpellNodeType.End, new Vector2(1000, 500)));
    }

    private IManipulator CreateGroupContextMenu()
    {
        ContextualMenuManipulator contextualMenuManipulator = new ContextualMenuManipulator
        (
            menuEvent => menuEvent.menu.AppendAction("Add Group", actionEvent => CreateGroup("Dialogue Group", GetLocalMousePosition(actionEvent.eventInfo.localMousePosition)))
        );

        return contextualMenuManipulator;
    }

    public GraphElement CreateGroup(string title, Vector2 localMousePosition)
    {
        Group group = new GraphGroup(title, localMousePosition);

        this.AddElement(group);

        foreach (GraphElement selectedItem in selection)
        {
            if (!(selectedItem is SpellNodeBase))
            {
                continue;
            }

            SpellNodeBase node = (SpellNodeBase)selectedItem;

            group.AddElement(node);
        }

        return group;
    }

    public SpellNodeBase CreateNode(SpellNodeType spellType, Vector2 positon)
    {
        Type nodeType = Type.GetType($"{spellType}Node");

        SpellNodeBase node = (SpellNodeBase)Activator.CreateInstance(nodeType);

        node.Initialize(positon, true);
        node.SetGraphView(this);

        node.Draw();

        node.RefreshExpandedState();
        node.RefreshPorts();

        return node;
    }

    private void CreateNodeIfCan(SpellNodeType spellType, DropdownMenuAction actionEvent)
    {
        var node = CreateNode(spellType, GetLocalMousePosition(actionEvent.eventInfo.localMousePosition));
        if (node != null)
        {
            AddElement(node);
        }
    }

    private IManipulator CreateNodeContextMenu(string actionTitle, SpellNodeType spellType)
    {
        ContextualMenuManipulator contextualMenuManipulator = new ContextualMenuManipulator
        (
            menuEvent => menuEvent.menu.AppendAction(actionTitle, actionEvent => CreateNodeIfCan(spellType, actionEvent))
        );

        return contextualMenuManipulator;
    }
    #endregion

    #region Add Methods
    private void AddMinimap()
    {
        MiniMap miniMap = new MiniMap { anchored = true };
        miniMap.SetPosition(new Rect(10, 30, 200, 140));
        Add(miniMap);
    }

    private void AddStyleSheet()
    {
        this.AddStyleSheets
        (
            "GraphViewStyle.uss",
            "NodeViewStyle.uss"
        );
    }
    #endregion

    #region Save & Load Methods
    public void Save()
    {
        var allElements = graphElements.ToList();
        Debug.Log("Graph save");
        _savedNodes.Clear();

        foreach (var element in allElements)
        {
            if (element is SpellNodeBase)
            {
                var spellNode = (SpellNodeBase)element;

                var nodeData = spellNode.SaveNode();
                var nodePorts = spellNode.SavePorts();

                nodeData.Ports = new List<NodePortData>();
                for (int i = 0; i < nodePorts.Count; i++)
                {
                    var port = nodePorts[i];
                    nodeData.Ports.Add(port);
                }

                _savedNodes.Add(nodeData);
            }
        }
    }

    public bool LoadGraph()
    {
        if (_savedNodes.Count == 0) return false;

        Debug.Log("Loading Graph");

        _currentNodes = new List<SpellNodeBase>();
        for (int i = 0; i < _savedNodes.Count; i++)
        {
            var nodeData = _savedNodes[i];
            var node = CreateNode(nodeData.Type, nodeData.Position);

            _currentNodes.Add(node);

            node.Load(nodeData);
            node.Initialize(nodeData.Position, false);

            AddElement(node);
        }

        for (int i = 0; i < _currentNodes.Count; i++)
        {
            var currentNode = _currentNodes[i];
            var nodeData = _savedNodes[i];

            currentNode.LoadPorts(nodeData);
        }

        return true;
    }
    #endregion

    #region Utilities
    public Vector2 GetLocalMousePosition(Vector2 mousePosition, bool isSearchWindow = false)
    {
        Vector2 worldMousePosition = mousePosition;

        if (isSearchWindow)
        {
            worldMousePosition -= _editorWindow.position.position;
        }

        Vector2 localMousePosition = contentViewContainer.WorldToLocal(worldMousePosition);

        return localMousePosition;
    }

    public SpellNodeBase GetNodeByID(string Id)
    {
        foreach (var node in _currentNodes)
        {
            if (node.ID == Id)
            {
                return node;
            }
        }

        return null;
    }
    #endregion
}
