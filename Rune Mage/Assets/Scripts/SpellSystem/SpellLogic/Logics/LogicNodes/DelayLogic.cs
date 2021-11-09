using System.Threading.Tasks;

using UnityEngine;


public class DelayLogic : ISpellLogic
{
    [SerializeField] private float _delay;
    public LogicType LogicType { get; set; }

    public void Initialize()
    {
        LogicType = LogicType.Durable;
    }

    public async Task Logic(GameObject spell)
    {
        Debug.Log("Delay logic");
        var currentWaitTime = _delay;

        while (true)
        {
            currentWaitTime -= Time.deltaTime;

            if (currentWaitTime <= 0)
            {
                break;
            }

            await Task.Yield();
        }

        return;
    }
}
