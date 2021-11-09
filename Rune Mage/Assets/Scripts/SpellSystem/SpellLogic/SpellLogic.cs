using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public class SpellLogic
{
    private List<SpellNodeData> _spellNodeDatas;
    private List<NodeLogic> _spellNodeLogics;

    public SpellLogic(List<SpellNodeData> spellNodeDatas)
    {
        _spellNodeDatas = spellNodeDatas;
        _spellNodeLogics = new List<NodeLogic>();

        //InitializeLogic();
    }

    //private void InitializeLogic()
    //{
    //    SpellNodeData currentNode = null;

    //    //Find start node
    //    for (int i = 0; i < _spellNodeDatas.Count; i++)
    //    {
    //        var spellNodeData = _spellNodeDatas[i];

    //        if (spellNodeData.Type == SpellNodeType.Start)
    //        {
    //            _spellNodeLogics.Add(GenerateNodeLogic(spellNodeData));
    //            currentNode = spellNodeData;
    //            break;
    //        }
    //    }

    //    //Loop for each node and generate node logic
    //    while (currentNode.Type != SpellNodeType.End)
    //    {
    //        foreach (var nodeData in _spellNodeDatas)
    //        {
    //            if (nodeData.ID == currentNode.GetOutputPort().ConnectedNodeID)
    //            {
    //                _spellNodeLogics.Add(GenerateNodeLogic(nodeData));
    //                currentNode = nodeData;

    //                if (currentNode.Type == SpellNodeType.End)
    //                {
    //                    return;
    //                }
    //            }
    //        }
    //    }
    //}

    //public async void Logic(GameObject spell)
    //{
    //    int spellCount = _spellNodeLogics.Count;
    //    int currentSpellCount = 0;

    //    var spellNodeLogic = _spellNodeLogics[currentSpellCount];
    //    var spellLogic = _spellNodeLogics[currentSpellCount].Logic(spell);

    //    while (true)
    //    {
    //        if (spellNodeLogic.LogicType == LogicType.Durable)
    //        {
    //            await Task.Yield();
    //        }

    //        if (spellLogic.IsCompleted)
    //        {
    //            currentSpellCount++;

    //            if (currentSpellCount == spellCount)
    //            {
    //                break;
    //            }

    //            spellNodeLogic = _spellNodeLogics[currentSpellCount];
    //            spellLogic = _spellNodeLogics[currentSpellCount].Logic(spell);
    //        }
    //    }
    //}

    //private NodeLogic GenerateNodeLogic(SpellNodeData spellNodeData)
    //{
    //    Type logicType = Type.GetType($"{spellNodeData.Type}NodeLogic");

    //    NodeLogic logic = (NodeLogic)Activator.CreateInstance(logicType);

    //    logic.Type = spellNodeData.Type;
    //    logic.GenerateFields(spellNodeData.Fields);

    //    if (spellNodeData.Type == SpellNodeType.Loop)
    //    {
    //        var loopNodeLogic = (LoopNodeLogic)logic;
    //        loopNodeLogic.SetSpellNodes(spellNodeData, _spellNodeDatas);
    //    }

    //    return logic;
    //}
}
