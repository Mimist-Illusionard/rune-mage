using UnityEngine;


public class DamageZone : Interactable, IDamage, ILifeTime, IInitialize
{
    public float Damage { get; set; }
    public float LifeTime { get; set; }

    public void Initialize()
    {
        Object.Destroy(this.gameObject, LifeTime);
    }

    protected override void Interact(Collider other)
    {
        if (other.gameObject.GetComponentInObject<Health>())
        {
            other.gameObject.GetComponentInObject<Health>().RemoveHealth(Damage);
        }
    }
}
