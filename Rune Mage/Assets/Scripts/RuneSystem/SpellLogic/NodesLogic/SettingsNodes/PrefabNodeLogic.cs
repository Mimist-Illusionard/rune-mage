using System.Threading.Tasks;

using UnityEditor;
using UnityEngine;


public class PrefabNodeLogic : NodeLogic
{
    private GameObject _prefab;
    private string _assetPath;

    public override void GenerateFields(SerilializedDictionary<string, string> fields)
    {
        fields.TryGetValue("AssetPath", out _assetPath);

        _prefab = AssetDatabase.LoadAssetAtPath<GameObject>(_assetPath);
    }

    public async override Task Logic(GameObject spell)
    {
        Debug.Log("PrefabNode Logic");
        Debug.LogWarning(spell);
        return;
    }

    public void CreateSpell(out GameObject spell)
    {
        spell = Object.Instantiate(_prefab);
    }
}
