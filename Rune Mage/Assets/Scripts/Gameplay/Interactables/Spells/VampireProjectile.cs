using UnityEngine;


public class VampireProjectile : Projectile
{
    protected override void OnEnter(Collider other)
    {
        base.OnEnter(other); 
        if (other.GetComponent<Health>())
            PlayerManager.Singleton.GetHealth().AddHealth(Damage);
    }
}
