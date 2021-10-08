

public class WaitTimeNodeLogic : NodeLogic
{
    private float _waitTime;

    public override void GenerateFields(SerilializedDictionary<string, string> fields)
    {
        var value = "";
        fields.TryGetValue("WaitTime", out value);

        if (!float.TryParse(value, out _waitTime)) 
            UnityEngine.Debug.LogError($"Can't parse <b>waitTimeValue</b>:{value} into <b>WaitIime</b> in <b>WaitTimeLogic</b>");
    }

    public override void Logic()
    {
        UnityEngine.Debug.Log("WaitTimeNode logic");
    }
}
