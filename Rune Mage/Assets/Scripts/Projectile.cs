using UnityEngine;


public class Projectile : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody => GetComponent<Rigidbody>();
    private Transform _spawnPoint;

    private void Start()
    {
        _rigidbody.AddForce(_spawnPoint.forward * _speed);
        Object.Destroy(this.gameObject, 10f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Health>())
        {
            collision.gameObject.GetComponent<Health>().DealDamage(_damage);
        }

        Destroy(this.gameObject);
    }

    public void SetSpawnPoint(Transform spawnPoint)
    {
        _spawnPoint = spawnPoint;
    }
}
