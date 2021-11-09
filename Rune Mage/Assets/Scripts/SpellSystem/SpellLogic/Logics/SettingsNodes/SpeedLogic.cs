using System.Threading.Tasks;

using UnityEngine;


public class SpeedLogic : ISpellLogic
{
    [SerializeField] private float _speed;

    public LogicType LogicType { get; set; }

    public void Initialize()
    {
        LogicType = LogicType.Immediately;
    }

    public async Task Logic(GameObject spell)
    {
        Debug.Log("SpeedNode logic");
        var speedComponent = spell.GetComponent<ISpeed>();
        speedComponent.Speed = _speed;

        return;
    }
}
