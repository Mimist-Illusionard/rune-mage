

public class SpawnPointNodeLogic : NodeLogic
{
    private SpawnPointType _spawnPointType;

    public override void GenerateFields(SerilializedDictionary<string, string> fields)
    {
        string spawnPointType = "";
        fields.TryGetValue("SpawnPointType", out spawnPointType);

        var enumType = SpawnPointType.Parse(typeof(SpawnPointType), spawnPointType);

        _spawnPointType = (SpawnPointType)enumType;
    }

    public override void Logic()
    {
        UnityEngine.Debug.Log("SpawnPointNode logic");
    }
}
