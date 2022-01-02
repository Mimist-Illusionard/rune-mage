using System.Collections;

using UnityEngine;


public class SpawnPointLogic : ISpellLogic
{
    [SerializeField] private SpawnPointType _spawnPointType;

    public LogicType LogicType { get; set; }

    public void Initialize()
    {
        LogicType = LogicType.Immediately;
    }

    public IEnumerator Logic(GameObject spell, ISpell ISpell)
    {
        Debug.Log("SpawnPointNode logic");

        if (spell)
        {
            switch (_spawnPointType)
            {
                case SpawnPointType.None:
                    break;

                case SpawnPointType.RaycastPoint:
                    var point = PlayerManager.Singleton.Raycast().point;

                    RaycastHit hitInfo;
                    Physics.Raycast(point, Vector3.down, out hitInfo);

                    if (hitInfo.point == new Vector3(0f,0f,0f)) spell.transform.position = point;
                    else spell.transform.position = hitInfo.point;

                    break;

                case SpawnPointType.BulletSpawnPoint:
                    var spawnPoint = GameObject.FindObjectOfType<Player>().gameObject.GetComponentInObject<Spawnpoint>().transform;

                    spell.transform.position = spawnPoint.position;
                    spell.transform.rotation = spawnPoint.rotation;

                    if (spell.TryGetComponent<ISpawnPoint>(out var spawnpoint)) spawnpoint.SetSpawnPoint(spawnPoint);

                    break;

                case SpawnPointType.PlayerPosition:
                    spell.transform.position = PlayerManager.Singleton.GetPlayer().transform.position;
                    break;

                case SpawnPointType.ForwardSpawnPoint:
                    var forwardSpawnPoint = GameObject.FindObjectOfType<Player>().gameObject.GetComponentInObject<ForwardSpawnpoint>().transform;

                    spell.transform.position = forwardSpawnPoint.position;
                    spell.transform.rotation = forwardSpawnPoint.rotation;

                    if (spell.TryGetComponent<ISpawnPoint>(out var forwardspawnPoint)) forwardspawnPoint.SetSpawnPoint(forwardSpawnPoint);
                    break;

                default:
                    break;
            }
        }

        ISpell.IsLogicEnded = true;
        yield return null;
    }
}
