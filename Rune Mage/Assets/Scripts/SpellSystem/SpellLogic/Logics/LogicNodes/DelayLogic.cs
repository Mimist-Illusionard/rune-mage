using System.Collections;

using UnityEngine;


public class DelayLogic : ISpellLogic
{
    [SerializeField] private float _delay;
    public LogicType LogicType { get; set; }

    public void Initialize()
    {
        LogicType = LogicType.Durable;
    }

    public IEnumerator Logic(GameObject spell, ISpell ISpell)
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

            yield return new WaitForEndOfFrame();
        }

        ISpell.IsLogicEnded = true;
    }
}
