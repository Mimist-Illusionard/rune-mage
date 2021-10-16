using System.Collections.Generic;

using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;


public class LoopNode : SpellNodeWithPorts
{
    public override void Initialize(Vector2 position, bool needGenerateGuid = true)
    {
        base.Initialize(position, needGenerateGuid);

        NodeName = "Loop Node";
        SpellNodeType = SpellNodeType.WaitTime;
    }

    public override void Draw()
    {
        base.Draw();

        Label label = new Label("Loop Node");

        List<string> strings = new List<string>();

    }

    public override void Load(SpellNodeData spellNodeData)
    {
        base.Load(spellNodeData);
    }

    public override SpellNodeData SaveNode()
    {
        return base.SaveNode();
    }
}
