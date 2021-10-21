using System.Collections;

using UnityEngine;


public class Enemy : Ai
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _shootTime;
    [SerializeField] private float _bulletDamage;
    [SerializeField] private float _bulletLifeTime;
    [SerializeField] private float _bulletSpeed;

    private Transform _spawnpoint;
    private Transform _target;

    private float _currentShootTime;

    private bool _isCorutineStarted;

    protected override void OnStart()
    {
        _target = GameObject.FindObjectOfType<Player>().transform;
        _spawnpoint = gameObject.GetComponentInObject<Spawnpoint>().transform;
        _currentShootTime = _shootTime;

        gameObject.GetComponentInObject<Health>().OnHealthZero += Die;

        SetDestination(_target.position);
    }

    protected override void OnExecute()
    {
        if (Raycast())
        {
            if (!_isCorutineStarted)
            {
                StartCoroutine(RandomizePoint());
                _isCorutineStarted = true;
            }

            Shoot();
        } 
        else
        {
            SetDestination(_target.position);
            StopCoroutine(RandomizePoint());

            _isCorutineStarted = false;
            _navMeshAgent.speed = 6f;
        }
    }

    private void Shoot()
    {
        _currentShootTime -= Time.deltaTime;

        if (_currentShootTime <= 0f)
        {
            var spawnPoint = gameObject.GetComponentInObject<Spawnpoint>().transform;
            var bullet = GameObject.Instantiate(_bulletPrefab, spawnPoint.position, spawnPoint.rotation);
            var bulletScript = bullet.GetComponentInObject<Projectile>();

            bulletScript.Damage = _bulletDamage;
            bulletScript.LifeTime = _bulletLifeTime;
            bulletScript.Speed = _bulletSpeed;

            bulletScript.SetSpawnPoint(spawnPoint);

            _currentShootTime = _shootTime + Random.Range(-0.3f, 0.3f);
        }
    }

    private bool Raycast()
    {
        var hit = new RaycastHit();

        Physics.Raycast(new Ray(_spawnpoint.position, _target.position - _spawnpoint.position), out hit, 30f, LayerMask.GetMask("Player", "Default"));

        if (hit.collider)
        {
            if (hit.collider.gameObject.GetComponentInObject<Player>() != null)
            {
                return true;
            }
        }

        return false;
    }

    private float RandomNumberBetween()
    {
        return Random.Range(-6f, 6f);
    }

    private IEnumerator RandomizePoint()
    {
        var currentTime = 2.5f;
        var point = new Vector3(transform.position.x + RandomNumberBetween(), 0f, transform.position.z + RandomNumberBetween());

        SetDestination(point);

        while (true)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0f)
            {
                point = new Vector3(transform.position.x + RandomNumberBetween(), 0f, transform.position.z + RandomNumberBetween());

                SetDestination(point);

                _navMeshAgent.speed = Random.Range(8f, 12f);

                currentTime = 2.5f + Random.Range(-0.5f, 1f);
            }

            yield return new WaitForEndOfFrame();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        GameManager.Singleton.RemoveExecuteObject(this);
    }
}
