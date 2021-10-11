using UnityEngine;


public class SpeedNodeLogic : NodeLogic
{
    private float _speed;

    public override void GenerateFields(SerilializedDictionary<string, string> fields)
    {
        var value = "";
        fields.TryGetValue("Speed", out value);

        if (!float.TryParse(value, out _speed))
            Debug.LogError($"Can't parse <b>Speed</b>:{value} into <b>Speed</b> in <b>SpeedNodeLogic</b>");
    }

    public override void Logic(GameObject spell)
    {
        Debug.Log("SpeedNode logic");
        spell.GetComponent<ISpeed>().Speed = _speed;
    }
}
