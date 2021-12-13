using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollInPoint : IEnemyAction
{
    public GameObject bject { get; set; }
    private IEnemyAction _parent;


    public void ExitToMain()
    {
        if (!bject) return;
        bject.GetComponentInObject<EnemyMain>().ReturnAction();
    }

    public void PlayAction(GameObject @object, IEnemyAction _Parent)
    {
        _parent = _Parent;
        bject = @object;

        EnemyData enemyData = bject.GetComponentInObject<EnemyData>();
        var spawnPoint = bject.GetComponentInObject<Spawnpoint>().transform;
        var bullet = Object.Instantiate(enemyData._bulletPrefab, spawnPoint.position, spawnPoint.rotation);
        var bulletScript = bullet.GetComponentInObject<Projectile>();

        bulletScript.Damage = enemyData._bulletDamage;
        bulletScript.LifeTime = 1f;
        bulletScript.Speed = 0;

        bulletScript.SetSpawnPoint(spawnPoint);
        bulletScript.GetComponent<IInitialize>().Initialize();

        if (_parent != null)
        { _parent.ExitToMain(); }
        else { ExitToMain(); }
        _parent = null;
    }
}
