using System.Collections;

using UnityEngine;


public class PrefabLogic : ISpellLogic
{
    [SerializeField] private GameObject _prefab;

    public LogicType LogicType { get; set; }

    public void Initialize()
    {
        LogicType = LogicType.Immediately;
    }

    public IEnumerator Logic(GameObject spell, ISpell iSpell)
    {
        Debug.Log("PrefabNode Logic");

        iSpell.IsLogicEnded = true;
        yield return null;
    }

    public void CreateSpell(out GameObject spell)
    {
        spell = Object.Instantiate(_prefab);
    }
}
