using UnityEngine;

public class HealingZone : Interactable, ILifeTime, IDamage
{
    public float LifeTime { get; set; }
    public float Damage { get; set; }

    private void Start()
    {
        Destroy(this, LifeTime);
    }

    protected override void Interact(Collider other)
    {
        var health = other.GetComponent<Health>();

        health.StartRegenHealing(0.5f, Damage, 3f);
    }
}
