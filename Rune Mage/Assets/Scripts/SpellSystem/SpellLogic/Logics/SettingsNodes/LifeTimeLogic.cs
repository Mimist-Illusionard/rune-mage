using System.Threading.Tasks;

using UnityEngine;


public class LifeTimeLogic : ISpellLogic
{
    [SerializeField] private float _lifeTime;

    public LogicType LogicType { get; set; }

    public void Initialize()
    {
        LogicType = LogicType.Immediately;
    }

    public async Task Logic(GameObject spell)
    {
        Debug.Log("LifeTimeNode logic");
        spell.GetComponent<ILifeTime>().LifeTime = _lifeTime;

        return;
    }
}
