using System.Threading.Tasks;

using UnityEngine;


public class SpawnPointLogic : ISpellLogic
{
    [SerializeField] private SpawnPointType _spawnPointType;

    public LogicType LogicType { get; set; }

    public void Initialize()
    {
        LogicType = LogicType.Immediately;
    }

    public async Task Logic(GameObject spell)
    {
        Debug.Log("SpawnPointNode logic");
        switch (_spawnPointType)
        {
            case SpawnPointType.None:
                break;

            case SpawnPointType.RaycastPoint:
                spell.transform.position = PlayerManager.Singleton.Raycast().point;
                break;

            case SpawnPointType.BulletSpawnPoint:
                var spawnPoint = GameObject.FindObjectOfType<Player>().gameObject.GetComponentInObject<Spawnpoint>().transform;

                spell.transform.position = spawnPoint.position;
                spell.GetComponent<Projectile>().SetSpawnPoint(spawnPoint);
                break;

            default:
                break;
        }

        return;
    }
}
