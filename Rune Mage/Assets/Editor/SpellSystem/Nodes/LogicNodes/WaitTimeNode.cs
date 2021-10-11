using UnityEngine.UIElements;
using UnityEngine;



public class WaitTimeNode : SpellNodeWithPorts
{
    private TextField _titleField;
    public float WaitTime;

    public override void Initialize(Vector2 position, bool needGenerateGuid = true)
    {
        base.Initialize(position, needGenerateGuid);
        NodeName = "Wait Node";
        SpellNodeType = SpellNodeType.WaitTime;
    }

    public override void Draw()
    {
        base.Draw();        

        Label label = new Label("Wait time");
        _titleField = NodeElementsUtility.CreateTextField("0");

        CustomDataContainer.Insert(0, _titleField);

        _titleField.AddClasses
        (
            "dg-node__textfield",
            "dg-node__quote-textfield"
        );

        CustomDataContainer.Add(label);
        CustomDataContainer.Add(_titleField);
    }

    #region Save & Load Methods
    public override SpellNodeData SaveNode()
    {
        SpellNodeData.Fields.Add("WaitTime", _titleField.text);

        return base.SaveNode();
    }

    public override void Load(SpellNodeData spellNodeData)
    {
        base.Load(spellNodeData);

        string waitTimeValue = "";
        spellNodeData.Fields.TryGetValue("WaitTime", out waitTimeValue);

        if (float.TryParse(waitTimeValue, out WaitTime))
            _titleField.SetValueWithoutNotify(WaitTime.ToString());
        else
            Debug.LogError($"Can't parse <b>waitTimeValue</b>:{waitTimeValue} into <b>WaitIime</b> in <b>WaitTimeNode</b>");
    }
    #endregion
}
