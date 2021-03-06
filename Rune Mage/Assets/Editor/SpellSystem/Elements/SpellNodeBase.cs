using System.Collections.Generic;
using System;

using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using UnityEngine;


public class SpellNodeBase : Node
{
    protected SpellGraphView GraphView;
    protected VisualElement CustomDataContainer;
    protected SpellNodeData SpellNodeData = new SpellNodeData();

    protected List<NodePortData> PortsData = new List<NodePortData>();
    protected List<Port> Ports = new List<Port>();

    public SpellNodeType SpellNodeType;
    public string NodeName;
    public string ID;
    public string GroupID;

    public virtual void Initialize(Vector2 position, bool needGenerateGuid = true)
    {
        SetPosition(new Rect(position, Vector2.zero));

        NodeName = "Node";
        if (needGenerateGuid)
            GenerateGUID();

        mainContainer.AddToClassList("dg-node__main_container");
        extensionContainer.AddToClassList("dg-node__extension-container");
    }

    public virtual void Draw()
    {
        Label label = new Label(NodeName);

        titleContainer.Insert(0, label);

        label.AddClasses
        (
            "dg-node__textfield",
            "dg-node__filename-textfield",
            "dg-node__textfield__hidden"
        );

        CustomDataContainer = new VisualElement();
        CustomDataContainer.AddToClassList("dg-node__custom-data-container");

        extensionContainer.Add(CustomDataContainer);
    }

    public void AddInputNode(Port outputPort, SpellNodeBase inputNode)
    {
        PortsData.Add(new NodePortData(outputPort.portName, Guid.NewGuid().ToString(), Direction.Output, inputNode.ID));
    }

    public void SetGraphView(SpellGraphView graphView)
    {
        GraphView = graphView;
    }

    public void GenerateGUID()
    {
        ID = Guid.NewGuid().ToString();
    }

    #region Save & Load Methods
    public virtual SpellNodeData SaveNode()
    {
        SpellNodeData.Name = NodeName;
        SpellNodeData.ID = ID;
        SpellNodeData.Type = SpellNodeType;
        SpellNodeData.Position = this.GetPosition().position;
        SpellNodeData.GroupID = GroupID;

        return SpellNodeData;
    }

    public List<NodePortData> SavePorts()
    {
        for (int i = 0; i < Ports.Count; i++)
        {
            var port = Ports[i];

            if (port.direction == Direction.Input)
                PortsData.Add(new NodePortData("Input", Guid.NewGuid().ToString(), port.direction, ""));
        }

        return PortsData;
    }

    public virtual void Load(SpellNodeData spellNodeData)
    {
        NodeName = spellNodeData.Name;
        ID = spellNodeData.ID;
        SpellNodeType = spellNodeData.Type;
        GroupID = spellNodeData.GroupID;
    }

    public void LoadPorts(SpellNodeData spellNodeData)
    {
        List<NodePortData> outputPorts = new List<NodePortData>();

        foreach (var portData in spellNodeData.Ports)
        {
            if (portData.Direction == Direction.Output)
            {
                outputPorts.Add(portData);
            }
        }

        foreach (var port in Ports)
        {
            if (port.direction == Direction.Output)
            {
                foreach (var outputPort in outputPorts)
                {
                    if (port.portName == outputPort.Name)
                    {
                        var connectedNode = GraphView.GetNodeByID(outputPort.ConnectedNodeID);

                        foreach (var nodePort in connectedNode.Ports)
                        {
                            if (nodePort.direction == Direction.Input)
                            {
                                var edge = port.ConnectTo(nodePort);
                                GraphView.AddElement(edge);

                                AddInputNode(edge.output, connectedNode);

                                connectedNode.RefreshPorts();
                                port.node.RefreshPorts();
                            }
                        }
                    }
                }
            }
        }
    }
    #endregion
}