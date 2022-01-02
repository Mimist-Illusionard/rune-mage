using System.Collections;
using UnityEngine;


public interface ISpellLogic
{
    public LogicType LogicType { get; set; }

    void Initialize();
    IEnumerator Logic(GameObject spell, ISpell iSpell);
}
