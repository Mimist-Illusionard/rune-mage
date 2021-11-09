using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Threading;

public class RuneAttackCycle :IEnemyAction
{
    public int AttackCount;
    public float AttackTime;
    private EnemyData enemyData;

    public GameObject bject { get; set; }

    public void ExitToMain()
    {
        bject.GetComponentInObject<EnemyMain>().ReturnAction();
    }

    public void PlayAction(GameObject @object, CancellationToken token)
    {
        bject = @object;
        ExitToMain();
        tt();
    }

    private async void tt()
    {
        for (int i = 0;i<AttackCount ;i++ )
        {
            await Task.Delay(10);
            Atttack();
        }
        
    }
    private void Atttack()
    {
        enemyData = bject.GetComponentInObject<EnemyData>();
        var spawnPoint = bject.GetComponentInObject<Spawnpoint>().transform;
        var bullet = Object.Instantiate(enemyData._bulletPrefab, spawnPoint.position, spawnPoint.rotation);
        var bulletScript = bullet.GetComponentInObject<Projectile>();

        bulletScript.Damage = enemyData._bulletDamage;
        bulletScript.LifeTime = enemyData._bulletLifeTime;
        bulletScript.Speed = enemyData._bulletSpeed;

        bulletScript.SetSpawnPoint(spawnPoint);
        bulletScript.GetComponent<IInitialize>().Initialize();
    }
}
