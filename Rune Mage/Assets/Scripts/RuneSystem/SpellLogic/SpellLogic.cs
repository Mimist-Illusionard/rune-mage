using System;
using System.Collections.Generic;

using UnityEngine;


public class SpellLogic
{
    private List<SpellNodeData> _spellNodeDatas;
    private List<NodeLogic> _spellNodeLogics;

    public SpellLogic(List<SpellNodeData> spellNodeDatas)
    {
        _spellNodeDatas = spellNodeDatas;
        _spellNodeLogics = new List<NodeLogic>();

        InitializeLogic();
    }

    private void InitializeLogic()
    {
        SpellNodeData currentNode = null;

        for (int i = 0; i < _spellNodeDatas.Count; i++)
        {
            var spellNodeData = _spellNodeDatas[i];

            if (spellNodeData.Type == SpellNodeType.Start)
            {
                _spellNodeLogics.Add(GenerateNodeLogic(spellNodeData));
                currentNode = spellNodeData;
                break;
            }
        }

        while (currentNode.Type != SpellNodeType.End)
        {
            foreach (var nodeData in _spellNodeDatas)
            {
                if (nodeData.ID == currentNode.GetOutputPort().ConnectedNodeID)
                {
                    _spellNodeLogics.Add(GenerateNodeLogic(nodeData));
                    currentNode = nodeData;

                    if (currentNode.Type == SpellNodeType.End)
                    {
                        return;
                    }
                }
            }
        }
    }

    public void Logic()
    {
        for (int i = 0; i < _spellNodeLogics.Count; i++)
        {
            var spellNodeLogic = _spellNodeLogics[i];
            spellNodeLogic.Logic();
        }
    }

    private NodeLogic GenerateNodeLogic(SpellNodeData spellNodeData)
    {
        Type logicType = Type.GetType($"{spellNodeData.Type}NodeLogic");

        NodeLogic logic = (NodeLogic)Activator.CreateInstance(logicType);

        logic.Type = spellNodeData.Type;
        logic.GenerateFields(spellNodeData.Fields);

        return logic;
    }
}
