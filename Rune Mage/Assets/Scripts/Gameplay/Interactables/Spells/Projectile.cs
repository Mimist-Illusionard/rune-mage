using UnityEngine;


public class Projectile : Interactable, IDamage, ISpeed, ILifeTime, IInitialize, ISpawnPoint
{
    private Rigidbody _rigidbody => GetComponent<Rigidbody>();
    private Transform _spawnPoint;

    public float Damage { get; set; }
    public float Speed { get; set; }
    public float LifeTime { get; set; }

    public void Initialize()
    {
        Object.Destroy(this.gameObject, LifeTime);
        if (_spawnPoint)
        {
            _rigidbody.AddForce(_spawnPoint.forward * Speed);
            transform.rotation = _spawnPoint.rotation;
        }

    }

    protected override void OnEnter(Collider other)
    {
        if (other.gameObject.GetComponentInObject<Health>())
        {
            other.gameObject.GetComponentInObject<Health>().RemoveHealth(Damage);
        }

        Destroy(this.gameObject);
    }

    public void SetSpawnPoint(Transform spawnPoint)
    {
        _spawnPoint = spawnPoint;
    }

    protected override void OnExit(Collider other)
    {
    }
}
