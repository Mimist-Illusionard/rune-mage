using UnityEngine;


public class HealingZone : Interactable, ILifeTime, IDamage, IInitialize
{
    [SerializeField] private bool _isIgnorePlayer;

    public float LifeTime { get; set; }
    public float Damage { get; set; }

    public void Initialize()
    {
        Destroy(gameObject, LifeTime);
    }

    protected override void OnEnter(Collider other)
    {
        if (!other.TryGetComponent<Health>(out var health)) return;
        if (_isIgnorePlayer && other.CompareTag("Player")) return;

        health.StartRegenHealing(0.5f, Damage, 3f);
    }

    protected override void OnExit(Collider other)
    {
    }
}
