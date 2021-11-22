using System.Collections;

using UnityEngine;


public class DamageLogic : ISpellLogic
{
    [SerializeField] private float _damage;
    public LogicType LogicType { get; set; }

    public void Initialize()
    {
        LogicType = LogicType.Immediately;
    }

    public IEnumerator Logic(GameObject spell, ISpell iSpell)
    {
        Debug.Log("DamageNode logic");
        if (spell) spell.GetComponent<IDamage>().Damage = _damage;

        iSpell.IsLogicEnded = true;
        yield return null;
    }
}
