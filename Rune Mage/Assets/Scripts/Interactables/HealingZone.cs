using UnityEngine;


public class HealingZone : Interactable, ILifeTime, IDamage
{
    public float LifeTime { get; set; }
    public float Damage { get; set; }

    private void Start()
    {
        Destroy(gameObject, LifeTime);
    }

    protected override void Interact(Collider other)
    {
        if (other.gameObject.GetComponentInObject<Health>())
        {
            var health = other.gameObject.GetComponentInObject<Health>();

            health.StartRegenHealing(0.5f, Damage, 3f);
        }
    }
}
