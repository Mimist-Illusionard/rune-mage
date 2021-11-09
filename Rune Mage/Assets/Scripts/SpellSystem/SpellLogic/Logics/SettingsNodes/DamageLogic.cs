using System.Threading.Tasks;

using UnityEngine;


public class DamageLogic : ISpellLogic
{
    [SerializeField] private float _damage;
    public LogicType LogicType { get; set; }

    public void Initialize()
    {
        LogicType = LogicType.Immediately;
    }

    public async Task Logic(GameObject spell)
    {
        Debug.Log("DamageNode logic");
        spell.GetComponent<IDamage>().Damage = _damage;

        return;
    }
}
