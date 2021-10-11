using UnityEngine.UIElements;
using UnityEngine;

public class LifeTimeNode : SpellNodeWithPorts
{
    private TextField _titleField;
    public float LifeTime;

    public override void Initialize(Vector2 position, bool needGenerateGuid = true)
    {
        base.Initialize(position, needGenerateGuid);

        NodeName = "LifeTime Node";
        SpellNodeType = SpellNodeType.LifeTime;
    }

    public override void Draw()
    {
        base.Draw();

        Label label = new Label("LifeTime");
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
        SpellNodeData.Fields.Add("LifeTime", _titleField.text);

        return base.SaveNode();
    }

    public override void Load(SpellNodeData spellNodeData)
    {
        base.Load(spellNodeData);

        string value = "";
        spellNodeData.Fields.TryGetValue("LifeTime", out value);

        if (float.TryParse(value, out LifeTime))
            _titleField.SetValueWithoutNotify(LifeTime.ToString());
        else
            Debug.LogError($"Can't parse <b>LifeTime</b>:{value} in <b>{this}</b>");
    }
    #endregion
}