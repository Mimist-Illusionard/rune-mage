using UnityEditor;
using UnityEngine;


public class PrefabNodeLogic : NodeLogic
{
    private GameObject _gameObject;
    private string _assetPath;

    public override void GenerateFields(SerilializedDictionary<string, string> fields)
    {
        fields.TryGetValue("AssetPath", out _assetPath);

        _gameObject = AssetDatabase.LoadAssetAtPath<GameObject>(_assetPath);
    }

    public override void Logic(GameObject spell)
    {
        Debug.Log("PrefabNode Logic");
    }
}
