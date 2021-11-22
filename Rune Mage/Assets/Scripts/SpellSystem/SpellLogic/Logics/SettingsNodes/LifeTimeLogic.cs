using System.Collections;

using UnityEngine;


public class LifeTimeLogic : ISpellLogic
{
    [SerializeField] private float _lifeTime;

    public LogicType LogicType { get; set; }
    public bool IsLogicEnded { get; set; }

    public void Initialize()
    {
        LogicType = LogicType.Immediately;
    }

    public IEnumerator Logic(GameObject spell, ISpell iSpell)
    {
        Debug.Log("LifeTimeNode logic");

        if (spell) spell.GetComponent<ILifeTime>().LifeTime = _lifeTime;

        iSpell.IsLogicEnded = true;
        yield return null;
    }
}
