using System.Threading.Tasks;

using UnityEngine;


public class PrefabLogic : ISpellLogic
{
    [SerializeField] private GameObject _prefab;

    public LogicType LogicType { get; set; }

    public void Initialize()
    {
        LogicType = LogicType.Immediately;
    }

    public async Task Logic(GameObject spell)
    {
        Debug.Log("PrefabNode Logic");
        return;
    }

    public void CreateSpell(out GameObject spell)
    {
        spell = Object.Instantiate(_prefab);
    }
}
