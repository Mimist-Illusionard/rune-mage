using System.Collections.Generic;

using UnityEngine;


public class RayObject : MonoBehaviour, ISpawnPoint, IDamage, ISpeed, IExecute, IInitialize
{
    [SerializeField] private Collider _collider;
    private Transform _spawnPoint;
    public float Damage { get; set; }
    public float Speed { get; set; }

    public bool NeedToDestroy = true;
    public bool IgnorePlayer;
    
    private List<Collider> _colliders = new List<Collider>();
    private float _currentTime;

    private void Start()
    {
        _currentTime = Speed;
        GameManager.Singleton.AddExecuteObject(this);
    }

    public void Initialize()
    {
        if (NeedToDestroy) Destroy(gameObject);
    }

    public void Execute()
    {
        if (!_spawnPoint && NeedToDestroy) Destroy(gameObject);
        else if(_spawnPoint)
        {
            transform.position = _spawnPoint.position;
            transform.rotation = _spawnPoint.rotation;
        }

        var colliders = Physics.OverlapBox(transform.position, _collider.bounds.size / 2);

        for (int i = 0; i < colliders.Length; i++)
        {
            var collider = colliders[i];
            _colliders.Add(collider);
        }

        DamageLogic();

        _colliders.Clear();
    }

    public void SetSpawnPoint(Transform spawnPoint)
    {
        _spawnPoint = spawnPoint;
    }

    private void DamageLogic()
    {
        _currentTime -= Time.deltaTime;
        if (_currentTime <= 0f)
        {
            for (int i = 0; i < _colliders.Count; i++)
            {
                var collider = _colliders[i];
                if (!collider.TryGetComponentInObject<Health>(out var health)) continue;

                health.RemoveHealth(Damage);
            }

            _currentTime = Speed;
        }
    }

    private void OnDestroy()
    {
        GameManager.Singleton.RemoveExecuteObject(this);
    }
}
