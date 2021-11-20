﻿using System.Collections;

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

            case SpawnPointType.PlayerPosition:
                spell.transform.position = PlayerManager.Singleton.GetPlayer().transform.position;
                break;

            default:
                break;
        }

        ISpell.IsLogicEnded = true;
        yield return null;
    }
}
