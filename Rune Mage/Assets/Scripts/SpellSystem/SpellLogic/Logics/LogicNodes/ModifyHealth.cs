using System.Collections;

using UnityEngine;

public class ModifyHealth : ISpellLogic
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
        if (_type == ModifierType.Minus)
        {
            PlayerManager.Singleton.GetHealth().RemoveHealth(_modifier);
        }
        else if (_type == ModifierType.Plus)
        {
            PlayerManager.Singleton.GetHealth().AddHealth(_modifier);
        }

        iSpell.IsLogicEnded = true;
        yield return null;
    }
}
