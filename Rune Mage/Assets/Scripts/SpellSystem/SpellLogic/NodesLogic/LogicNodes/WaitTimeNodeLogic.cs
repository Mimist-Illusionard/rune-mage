using System.Threading.Tasks;

using UnityEngine;


public class WaitTimeNodeLogic : NodeLogic
{
    private float _waitTime;

    public override void GenerateFields(SerilializedDictionary<string, string> fields)
    {
        LogicType = LogicType.Durable;

        var value = "";
        fields.TryGetValue("WaitTime", out value);

        if (!float.TryParse(value, out _waitTime)) 
            Debug.LogError($"Can't parse <b>waitTimeValue</b>:{value} into <b>WaitIime</b> in <b>WaitTimeLogic</b>");
    }

    public async override Task Logic(GameObject spell)
    {
        Debug.Log("WaitTimeNode logic");
        var currentWaitTime = _waitTime;

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
