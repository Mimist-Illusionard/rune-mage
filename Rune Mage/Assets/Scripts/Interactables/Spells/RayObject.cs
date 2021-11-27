using System.Collections;

using UnityEngine;


public class RayObject : Interactable, ISpawnPoint, IDamage, ISpeed, IExecute, IInitialize
{
    private Transform _spawnPoint;
    public float Damage { get; set; }
    public float Speed { get; set; }

    private void Start()
    {
        GameManager.Singleton.AddExecuteObject(this);
    }

    public void Initialize()
    {
        Destroy(gameObject);
    }

    public void Execute()
    {
        if (!_spawnPoint) Destroy(gameObject);
        else
        {
            transform.position = _spawnPoint.position;
            transform.rotation = _spawnPoint.rotation;
        }
    }

    public void SetSpawnPoint(Transform spawnPoint)
    {
        _spawnPoint = spawnPoint;
    }

    protected override void OnEnter(Collider other)
    {
        if (other.gameObject.GetComponentInObject<Health>())
        {
            StartCoroutine(DamageLogic(other));   
        }
    }

    protected override void OnExit(Collider other)
    {
    }

    private IEnumerator DamageLogic(Collider other)
    {
        var health = other.gameObject.GetComponentInObject<Health>();

        while (other)
        {
            yield return new WaitForSeconds(Speed);
            health.RemoveHealth(Damage);
        }

        yield return null;
    }

    private void OnDestroy()
    {
        GameManager.Singleton.RemoveExecuteObject(this);
    }
}
