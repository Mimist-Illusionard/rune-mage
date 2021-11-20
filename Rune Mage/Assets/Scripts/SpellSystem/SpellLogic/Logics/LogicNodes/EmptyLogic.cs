using System.Collections;

using UnityEngine;

public class EmptyLogic : ISpellLogic
{
    public LogicType LogicType { get; set; }

    public void Initialize()
    {        
    }

    public IEnumerator Logic(GameObject spell, ISpell iSpell)
    {
        yield return null;
    }
}