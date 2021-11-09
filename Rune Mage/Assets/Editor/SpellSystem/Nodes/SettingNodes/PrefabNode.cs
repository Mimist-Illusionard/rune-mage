using UnityEditor.UIElements;
using UnityEngine.UIElements;

using UnityEngine;
using UnityEditor;


public class PrefabNode : SpellNodeWithPorts
{
    private ObjectField _field;
    public string AssetPath;

    public override void Initialize(Vector2 position, bool needGenerateGuid = true)
    {
        base.Initialize(position, needGenerateGuid);

        NodeName = "Prefab Node";
        SpellNodeType = SpellNodeType.Prefab;
    }

    public override void Draw()
    {
        base.Draw();

        Label label = new Label("Prefab");
        _field = new ObjectField();
        _field.objectType = typeof(GameObject);

        CustomDataContainer.Insert(0, _field);

        _field.AddClasses
        (
            "dg-node__textfield",
            "dg-node__quote-textfield"
        );

        CustomDataContainer.Add(label);
        CustomDataContainer.Add(_field);
    }

    #region Save & Load Methods
    public override SpellNodeData SaveNode()
    {
        SpellNodeData.Fields.Add("AssetPath", AssetDatabase.GetAssetPath(_field.value.GetInstanceID()));

        return base.SaveNode();
    }

    public override void Load(SpellNodeData spellNodeData)
    {
        base.Load(spellNodeData);

        spellNodeData.Fields.TryGetValue("AssetPath", out AssetPath);

        var asset = AssetDatabase.LoadAssetAtPath<GameObject>(AssetPath);
        _field.SetValueWithoutNotify(asset);        
    }
    #endregion
}