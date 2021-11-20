using System.Collections;

using UnityEngine;

public class ModifyMana : ISpellLogic
{
    [SerializeField] private float _modifier;
    [SerializeField] private ModifierType _type;

    public LogicType LogicType { get; set; }

    public void Initialize()
    {
        LogicType = LogicType.Immediately;
    }

    public IEnumerator Logic(GameObject spell, ISpell iSpell)
    {
        Debug.Log("Modify Mana");

        if (_type == ModifierType.Minus)
        {
            PlayerManager.Singleton.GetMana().ManaChange(-_modifier);
        } else if (_type == ModifierType.Plus)
        {
            PlayerManager.Singleton.GetMana().ManaChange(_modifier);
        }

        yield return null;
    }
}
