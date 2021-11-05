using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneAttackCycle : MonoBehaviour, IEnemyAction
{
    public int AttackCount;
    public float AttackTime;
    private EnemyData enemyData;

    public void ExitToMain()
    {
        gameObject.GetComponentInObject<EnemyMain>().ReturnAction();
    }

    public void PlayAction()
    {
        ExitToMain();
        StartCoroutine(tt());
    }

    private IEnumerator tt()
    {
        for (int i = 0;i<AttackCount ;i++ )
        {
            yield return new WaitForSeconds(AttackTime);
            Atttack();
        }
        
    }
    private void Atttack()
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
    }
}
