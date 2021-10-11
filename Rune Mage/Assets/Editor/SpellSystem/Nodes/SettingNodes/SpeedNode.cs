using UnityEngine;
using UnityEngine.UIElements;


public class SpeedNode : SpellNodeWithPorts
{
    private TextField _titleField;
    public float Speed;

    public override void Initialize(Vector2 position, bool needGenerateGuid = true)
    {
        base.Initialize(position, needGenerateGuid);

        NodeName = "Speed Node";
        SpellNodeType = SpellNodeType.Speed;
    }

    public override void Draw()
    {
        base.Draw();

        Label label = new Label("Speed");
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
        SpellNodeData.Fields.Add("Speed", _titleField.text);

        return base.SaveNode();
    }

    public override void Load(SpellNodeData spellNodeData)
    {
        base.Load(spellNodeData);

        string value = "";
        spellNodeData.Fields.TryGetValue("Speed", out value);

        if (float.TryParse(value, out Speed))
            _titleField.SetValueWithoutNotify(Speed.ToString());
        else
            Debug.LogError($"Can't parse <b>Speed</b>:{value} into <b>Speed</b> in <b>SpeedNode</b>");
    }
    #endregion
}
