using UnityEngine;


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

    public override void Logic(GameObject spell)
    {
        Debug.Log("SpawnPointNode logic");
        switch (_spawnPointType)
        {
            case SpawnPointType.None:
                break;

            case SpawnPointType.Raycast_Point:
                spell.transform.position = PlayerManager.Singleton.Raycast().point;
                break;

            case SpawnPointType.Bullet_Spawn_Point:
                var spawnPoint = GameObject.FindObjectOfType<Spawnpoint>().transform;

                spell.transform.position = spawnPoint.position;
                spell.GetComponent<Projectile>().SetSpawnPoint(spawnPoint);
                break;

            default:
                break;
        }
    }
}
