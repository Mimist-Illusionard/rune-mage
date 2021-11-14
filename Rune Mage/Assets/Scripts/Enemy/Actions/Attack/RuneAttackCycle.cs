using System.Collections;
using UnityEngine;


public class RuneAttackCycle : IEnemyAction
{
    public int AttackCount;
    public float AttackTime;
    private EnemyData enemyData;

    public GameObject bject { get; set; }

    public void ExitToMain()
    {
        bject.GetComponentInObject<EnemyMain>().ReturnAction();
    }

    public void PlayAction(GameObject @object)
    {
        bject = @object;
        ExitToMain();
        CoroutineManager.Singleton.RunCoroutine(tt());
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
