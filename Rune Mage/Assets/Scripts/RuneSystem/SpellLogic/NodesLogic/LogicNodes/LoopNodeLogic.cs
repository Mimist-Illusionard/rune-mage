using System;
using System.Collections.Generic;

using UnityEngine;


public class LoopNodeLogic : NodeLogic
{
    private List<SpellNodeData> _spellNodesData;
    private SpellNodeData _currentLoopNode;

    private float LoopAmount;
    private int LoopPortsAmount;


    public override void GenerateFields(SerilializedDictionary<string, string> fields)
    {
        string fieldResult = "";
        fields.TryGetValue("LoopAmount", out fieldResult);

        if (!float.TryParse(fieldResult, out LoopAmount))            
            Debug.LogError($"Can't parse <b>loopAmount</b>:{fieldResult} into <b>LoopAmount</b> in <b>Loop Node</b>");

        if(!int.TryParse(fieldResult, out LoopPortsAmount))
            Debug.LogError($"Can't parse <b>loopPortsAmount</b>:{fieldResult} into <b>LoopPortsAmount</b> in <b>LoopNodeLogic</b>");
    }

    public override void Logic(GameObject spell)
    {
        Debug.Log("LoopNodeLogic");

        //Find all output ports
        List<NodePortData> outputPorts = _currentLoopNode.GetAllOutputPorts();
        for (int i = 0; i < outputPorts.Count; i++)
        {
            var outputPort = outputPorts[i];
            if (outputPort.Name == "Output")
            {
                outputPorts.Remove(outputPort);
            }
        }

        List<SpellNodeData> loopNodesDatas = new List<SpellNodeData>();
        for (int i = 0; i < LoopPortsAmount; i++)
        {
            for (int j = 0; j < outputPorts.Count; j++)
            {
                var outputLoopPort = outputPorts[j];
                if (outputLoopPort.Name == "Loop" + i) //Check if port has correct name
                {
                    for (int f = 0; f < _spellNodesData.Count; f++) //Find port's connected node
                    {
                        var nodeData = _spellNodesData[f];
                        if (outputLoopPort.ConnectedNodeID == nodeData.ID)
                        {
                            loopNodesDatas.Add(nodeData);
                        }
                    }
                }
            }
        }

        //Generate node logic
        List<NodeLogic> loopNodeLogic = new List<NodeLogic>();
        for (int i = 0; i < loopNodesDatas.Count; i++)
        {
            var loopNodeData = loopNodesDatas[i];
            loopNodeLogic.Add(GenerateNodeLogic(loopNodeData));
        }

        //Use nodeLogic
        for (int i = 0; i < LoopAmount; i++)
        {
            for (int j = 0; j < loopNodeLogic.Count; j++)
            {
                var nodeLogic = loopNodeLogic[j];
                nodeLogic.Logic(spell);
            }
        }
    }

    public void SetSpellNodes(SpellNodeData currentLoopNode, List<SpellNodeData> spellNodeDatas)
    {
        _currentLoopNode = currentLoopNode;
        _spellNodesData = spellNodeDatas;
    }

    private NodeLogic GenerateNodeLogic(SpellNodeData spellNodeData)
    {
        Type logicType = System.Type.GetType($"{spellNodeData.Type}NodeLogic");

        NodeLogic logic = (NodeLogic)Activator.CreateInstance(logicType);

        logic.Type = spellNodeData.Type;
        logic.GenerateFields(spellNodeData.Fields);

        return logic;
    }
}
