using UnityEngine;


public class DamageZone : Interactable, IDamage, ILifeTime
{
    public float Damage { get; set; }
    public float LifeTime { get; set; }

    private void Start()
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
