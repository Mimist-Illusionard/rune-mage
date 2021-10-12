using UnityEngine;


public class Projectile : Interactable, IDamage, ISpeed, ILifeTime
{
    private Rigidbody _rigidbody => GetComponent<Rigidbody>();
    private Transform _spawnPoint;

    public float Damage { get; set; }
    public float Speed { get; set; }
    public float LifeTime { get; set; }

    private void Start()
    {
        _rigidbody.AddForce(_spawnPoint.forward * Speed);
        Object.Destroy(this.gameObject, LifeTime);
    }

    protected override void Interact(Collider other)
    {
        if (other.gameObject.GetComponent<Health>())
        {
            other.gameObject.GetComponent<Health>().RemoveHealth(Damage);
        }

        Destroy(this.gameObject);
    }

    public void SetSpawnPoint(Transform spawnPoint)
    {
        _spawnPoint = spawnPoint;
    }
}
