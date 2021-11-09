using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RuneAttack :IEnemyAction
{
    private EnemyData enemyData;

    public GameObject bject { get; set; }

    public void ExitToMain()
    {
        bject.GetComponentInObject<EnemyMain>().ReturnAction();
    }

    public void PlayAction(GameObject @object, CancellationToken token)
    {
        bject = @object;
        enemyData = bject.GetComponentInObject<EnemyData>();
        var spawnPoint = bject.GetComponentInObject<Spawnpoint>().transform;
        var bullet = Object.Instantiate(enemyData._bulletPrefab, spawnPoint.position, spawnPoint.rotation);
        var bulletScript = bullet.GetComponentInObject<Projectile>();

        bulletScript.Damage = enemyData._bulletDamage;
        bulletScript.LifeTime = enemyData._bulletLifeTime;
        bulletScript.Speed = enemyData._bulletSpeed;

        bulletScript.SetSpawnPoint(spawnPoint);
        bulletScript.GetComponent<IInitialize>().Initialize();
        ExitToMain();
    }
}
