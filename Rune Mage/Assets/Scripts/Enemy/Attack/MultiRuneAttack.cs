using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiRuneAttack : MonoBehaviour, IEnemyAction
{
    public int AttackCount;
    public float AttackTime;
    private EnemyData enemyData;

    public void ExitToMain()
    {
        
    }

    public void PlayAction()
    {
        
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
        enemyData = gameObject.GetComponent<EnemyData>();
        var spawnPoint = gameObject.GetComponentInObject<Spawnpoint>().transform;
        var bullet = Instantiate(enemyData._bulletPrefab, spawnPoint.position, spawnPoint.rotation);
        var bulletScript = bullet.GetComponentInObject<Projectile>();

        bulletScript.Damage = enemyData._bulletDamage;
        bulletScript.LifeTime = enemyData._bulletLifeTime;
        bulletScript.Speed = enemyData._bulletSpeed;
        Debug.Log(bulletScript.Speed);

        bulletScript.SetSpawnPoint(spawnPoint);
        bulletScript.GetComponent<IInitialize>().Initialize();
    }
}
