using UnityEngine.UIElements;
using UnityEngine;


public class DamageNode : SpellNodeWithPorts
{
    private TextField _titleField;
    public float Damage;

    public override void Initialize(Vector2 position, bool needGenerateGuid = true)
    {
        base.Initialize(position, needGenerateGuid);

        NodeName = "Damage Node";
        SpellNodeType = SpellNodeType.Damage;
    }

    public override void Draw()
    {
        base.Draw();

        Label label = new Label("Damage");
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
        SpellNodeData.Fields.Add("Damage", _titleField.text);

        return base.SaveNode();
    }

    public override void Load(SpellNodeData spellNodeData)
    {
        base.Load(spellNodeData);

        string value = "";
        spellNodeData.Fields.TryGetValue("Damage", out value);

        if (float.TryParse(value, out Damage))
            _titleField.SetValueWithoutNotify(Damage.ToString());
        else
            Debug.LogError($"Can't parse <b>Damage</b>:{value} into <b>Damage</b> in <b>DamageNode</b>");
    }
    #endregion
}