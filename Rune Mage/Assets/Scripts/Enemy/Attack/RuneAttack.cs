using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneAttack : MonoBehaviour,IEnemyAction
{
    private EnemyData enemyData;

    public void ExitToMain()
    {
        gameObject.GetComponentInObject<EnemyMain>().ReturnAction();
    }

    public void PlayAction()
    {
       
        enemyData = gameObject.GetComponentInObject<EnemyData>();
        var spawnPoint = gameObject.GetComponentInObject<Spawnpoint>().transform;
        var bullet = Instantiate(enemyData._bulletPrefab, spawnPoint.position, spawnPoint.rotation);
        var bulletScript = bullet.GetComponentInObject<Projectile>();

        bulletScript.Damage = enemyData._bulletDamage;
        bulletScript.LifeTime = enemyData._bulletLifeTime;
        bulletScript.Speed = enemyData._bulletSpeed;

        bulletScript.SetSpawnPoint(spawnPoint);
        bulletScript.GetComponent<IInitialize>().Initialize();
        ExitToMain();
    }
}
