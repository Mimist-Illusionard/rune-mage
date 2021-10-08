using UnityEditor.Experimental.GraphView;


public class SpellNodeWithPorts : SpellNodeBase
{
    public override void Draw()
    {
        base.Draw();

        var inputPort = NodeElementsUtility.CreatePort(this, "Input", Orientation.Horizontal, Direction.Input, Port.Capacity.Multi);
        var outputPort = NodeElementsUtility.CreatePort(this, "Output");

        inputContainer.Add(inputPort);
        outputContainer.Add(outputPort);

        Ports.Add(inputPort);
        Ports.Add(outputPort);
    }
}
