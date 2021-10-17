using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;


public class LoopNode : SpellNodeWithPorts
{
    private TextField _titleField;
    public float LoopAmount;

    private int LoopPortsAmount = 0;

    public override void Initialize(Vector2 position, bool needGenerateGuid = true)
    {
        base.Initialize(position, needGenerateGuid);

        NodeName = "Loop Node";
        SpellNodeType = SpellNodeType.Loop;
    }

    public override void Draw()
    {
        base.Draw();

        Label label = new Label("Loop Amount");
        _titleField = NodeElementsUtility.CreateTextField("0");

        var button = NodeElementsUtility.CreateButton("Add loop", () => {

            var outputPort = CreateLoop("Loop" + LoopPortsAmount);

            outputContainer.Add(outputPort);
        });

        CustomDataContainer.Add(label);
        CustomDataContainer.Add(_titleField);
        CustomDataContainer.Add(button);
    }

    private Port CreateLoop(string name)
    {
        Port loopPort = this.CreatePort(name);

        Button deleteChoiceButton = NodeElementsUtility.CreateButton("X", () =>
        {
            outputContainer.Remove(loopPort);
            Ports.Remove(loopPort);
            LoopPortsAmount -= 1;
        });

        deleteChoiceButton.AddToClassList("dg-node__button");

        loopPort.Add(deleteChoiceButton);
        LoopPortsAmount += 1;

        Ports.Add(loopPort);

        return loopPort;
    }

    public override SpellNodeData SaveNode()
    {
        SpellNodeData.Fields.Add("LoopAmount", _titleField.text);
        SpellNodeData.Fields.Add("LoopPortsAmount", LoopPortsAmount.ToString());

        return base.SaveNode();
    }

    public override void Load(SpellNodeData spellNodeData)
    {
        base.Load(spellNodeData);

        string fieldResult = "";
        spellNodeData.Fields.TryGetValue("LoopAmount", out fieldResult);

        if (float.TryParse(fieldResult, out LoopAmount))
            _titleField.SetValueWithoutNotify(LoopAmount.ToString());
        else
            Debug.LogError($"Can't parse <b>loopAmount</b>:{fieldResult} into <b>LoopAmount</b> in <b>Loop Node</b>");

        fieldResult = "";
        spellNodeData.Fields.TryGetValue("LoopPortsAmount", out fieldResult);

        int.TryParse(fieldResult, out LoopPortsAmount);

        int loopAmount = LoopPortsAmount;

        for (int i = 0; i < loopAmount; i++)
        {
            var loop = CreateLoop("Loop" + i);
            outputContainer.Add(loop);
        }
    }
}
