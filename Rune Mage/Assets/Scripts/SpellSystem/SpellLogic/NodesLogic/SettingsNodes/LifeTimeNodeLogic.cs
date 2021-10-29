using System.Threading.Tasks;

using UnityEngine;


public class LifeTimeNodeLogic : NodeLogic
{
    private float _lifeTime;

    public override void GenerateFields(SerilializedDictionary<string, string> fields)
    {
        var value = "";
        fields.TryGetValue("LifeTime", out value);

        if (!float.TryParse(value, out _lifeTime))
            Debug.LogError($"Can't parse <b>LifeTime</b>:{value} into <b>LifeTime</b> in <b>{this}</b>");
    }

    public async override Task Logic(GameObject spell)
    {
        Debug.Log("LifeTimeNode logic");
        spell.GetComponent<ILifeTime>().LifeTime = _lifeTime;

        return;
    }
}
