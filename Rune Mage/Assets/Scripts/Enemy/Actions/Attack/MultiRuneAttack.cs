using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MultiRuneAttack :IEnemyAction
{
    public int AttackCount;
    public float AttackTime;
    private EnemyData enemyData;
    private IEnemyAction _parent;
    public GameObject bject { get; set; }
    public bool _isParellel { get; set; }

    public void ExitToMain()
    {
        bject.GetComponent<EnemyMain>().ReturnAction();
    }

    private IEnumerator tt()
    {
        yield return new WaitForEndOfFrame();
        for (int i = 0; i < AttackCount; i++)
        {
            
            Atttack();
        }

    }
    private void Atttack()
    {
        enemyData = bject.GetComponent<EnemyData>();
        var spawnPoint = bject.GetComponentInObject<Spawnpoint>().transform;
        var bullet = Object.Instantiate(enemyData._bulletPrefab, spawnPoint.position, spawnPoint.rotation);
        var bulletScript = bullet.GetComponentInObject<Projectile>();

        bulletScript.Damage = enemyData._bulletDamage;
        bulletScript.LifeTime = enemyData._bulletLifeTime;
        bulletScript.Speed = enemyData._bulletSpeed;

        bulletScript.SetSpawnPoint(spawnPoint);
        bulletScript.GetComponent<IInitialize>().Initialize();
    }

    public void PlayAction(GameObject @object, IEnemyAction _Parent)
    {
        _parent = _Parent;
        throw new System.NotImplementedException();
    }
}
