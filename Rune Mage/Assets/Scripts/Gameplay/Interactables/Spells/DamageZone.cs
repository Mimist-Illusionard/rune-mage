using UnityEngine;


public class DamageZone : Interactable, IDamage, ILifeTime, IInitialize
{
    [SerializeField] private bool _isIgnorePlayer;

    public float Damage { get; set; }
    public float LifeTime { get; set; }

    public void Initialize()
    {
        Object.Destroy(this.gameObject, LifeTime);
    }

    protected override void OnEnter(Collider other)
    {
        if (!other.TryGetComponent<Health>(out var health)) return;
        if (_isIgnorePlayer && other.CompareTag("Player")) return;

        health.RemoveHealth(Damage);
    }

    protected override void OnExit(Collider other)
    {
    }
}
