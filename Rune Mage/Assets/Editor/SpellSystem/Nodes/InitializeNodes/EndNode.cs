using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using UnityEngine;


public class EndNode : SpellNodeBase
{
    public override void Initialize(Vector2 position, bool needGenerateGuid = true)
    {
        base.Initialize(position, needGenerateGuid);
        NodeName = "End Node";
        SpellNodeType = SpellNodeType.End;
    }

    public override void Draw()
    {
        base.Draw();

        capabilities = ~Capabilities.Deletable;
        capabilities &= ~Capabilities.Resizable;

        var inputPort = NodeElementsUtility.CreatePort(this, "Input", Orientation.Horizontal, Direction.Input, Port.Capacity.Multi);
        Ports.Add(inputPort);

        outputContainer.Add(inputPort);

        Label label = new Label("This is End Node \nHere logic ends");

        CustomDataContainer.Add(label);

        RefreshExpandedState();
    }
}
