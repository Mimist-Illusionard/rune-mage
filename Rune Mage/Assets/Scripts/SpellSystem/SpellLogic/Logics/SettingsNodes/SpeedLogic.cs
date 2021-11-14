using System.Collections;

using UnityEngine;


public class SpeedLogic : ISpellLogic
{
    [SerializeField] private float _speed;

    public LogicType LogicType { get; set; }

    public void Initialize()
    {
        LogicType = LogicType.Immediately;
    }

    public IEnumerator Logic(GameObject spell, ISpell ISpell)
    {
        Debug.Log("SpeedNode logic");
        var speedComponent = spell.GetComponent<ISpeed>();
        speedComponent.Speed = _speed;

        ISpell.IsLogicEnded = true;
        yield return null;
    }
}
