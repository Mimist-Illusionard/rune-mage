using UnityEngine.UIElements;
using UnityEngine;

public class ChargeNode : SpellNodeWithPorts
{
    private TextField _titleField;
    public float Charge;

    public override void Initialize(Vector2 position, bool needGenerateGuid = true)
    {
        base.Initialize(position, needGenerateGuid);
        NodeName = "Charge Node";
        SpellNodeType = SpellNodeType.Charge;
    }

    public override void Draw()
    {
        base.Draw();

        Label label = new Label("Charge time");
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
        SpellNodeData.Fields.Add("Charge", _titleField.text);

        return base.SaveNode();
    }

    public override void Load(SpellNodeData spellNodeData)
    {
        base.Load(spellNodeData);

        string fieldValue = "";
        spellNodeData.Fields.TryGetValue("Charge", out fieldValue);

        if (float.TryParse(fieldValue, out Charge))
            _titleField.SetValueWithoutNotify(Charge.ToString());
        else
            Debug.LogError($"Can't parse <b>chargeValue</b>:{fieldValue} into <b>Charge</b> in <b>{this}</b>");
    }
    #endregion
}

