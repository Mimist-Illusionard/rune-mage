using System.Threading.Tasks;

using UnityEngine;


public class DamageNodeLogic : NodeLogic
{
    private float _damage;

    public override void GenerateFields(SerilializedDictionary<string, string> fields)
    {
        var value = "";
        fields.TryGetValue("Damage", out value);

        if (!float.TryParse(value, out _damage))
            Debug.LogError($"Can't parse <b>Damage</b>:{value} into <b>Damage</b> in <b>DamageNodeLogic</b>");
    }

    public async override Task Logic(GameObject spell)
    {
        Debug.Log("DamageNode logic");
        spell.GetComponent<IDamage>().Damage = _damage;

        return;
    }
}
