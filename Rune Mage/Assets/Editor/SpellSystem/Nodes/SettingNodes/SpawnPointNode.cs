using System;

using UnityEditor.UIElements;
using UnityEngine.UIElements;
using UnityEngine;


public class SpawnPointNode : SpellNodeWithPorts
{
    private EnumField _enumField;
    public SpawnPointType SpawnType;

    public override void Initialize(Vector2 position, bool needGenerateGuid = true)
    {
        base.Initialize(position, needGenerateGuid);

        NodeName = "Spawn Point Node";
        SpellNodeType = SpellNodeType.SpawnPoint;
    }

    public override void Draw()
    {
        base.Draw();

        Label label = new Label("Spawn point Type");
        _enumField = NodeElementsUtility.CreateEnum(SpawnType);

        CustomDataContainer.Insert(0, _enumField);

        _enumField.AddClasses
        (
            "dg-node__textfield",
            "dg-node__quote-textfield"
        );

        CustomDataContainer.Add(label);
        CustomDataContainer.Add(_enumField);
    }

    #region Save & Load Methods
    public override SpellNodeData SaveNode()
    {
        SpellNodeData.Fields.Add("SpawnPointType", _enumField.text);

        return base.SaveNode();
    }

    public override void Load(SpellNodeData spellNodeData)
    {
        base.Load(spellNodeData);

        string spawnPointType = "";
        spellNodeData.Fields.TryGetValue("SpawnPointType", out spawnPointType);

        var enumType = SpawnPointType.Parse(SpawnType.GetType(), spawnPointType);

        SpawnType = (SpawnPointType)enumType;
        _enumField.SetValueWithoutNotify(SpawnType);
    }
    #endregion
}
