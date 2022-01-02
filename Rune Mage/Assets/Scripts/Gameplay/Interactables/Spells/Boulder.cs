using UnityEngine;


public class Boulder : Interactable, ISpeed, ILifeTime, IDamage, IInitialize, ISpawnPoint
{
    private Rigidbody _rigidbody => GetComponent<Rigidbody>();
    private Transform _spawnPoint;

    public float Speed { get; set; }
    public float LifeTime { get; set; }
    public float Damage { get; set; }

    public void Initialize()
    {
        transform.rotation = _spawnPoint.rotation;
    }


    public void SetSpawnPoint(Transform spawnPoint)
    {
        _spawnPoint = spawnPoint;
    }

    public void AddForce()
    {
        _rigidbody.AddForce(_spawnPoint.forward * Speed);
        Destroy(gameObject, LifeTime);
    }

    protected override void OnEnter(Collider other)
    {
        if (other.gameObject.GetComponentInObject<Health>())
        {
            other.gameObject.GetComponentInObject<Health>().RemoveHealth(Damage);
        }

        Destroy(this.gameObject);
    }

    protected override void OnExit(Collider other)
    {      
    }
}
