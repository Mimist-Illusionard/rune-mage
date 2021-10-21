using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public abstract class Ai : MonoBehaviour, IExecute
{
    protected NavMeshAgent _navMeshAgent => GetComponent<NavMeshAgent>();
    protected Vector3 _point;

    protected abstract void OnExecute();
    protected abstract void OnStart();

    private void Start()
    {
        OnStart();

        GameManager.Singleton.AddExecuteObject(this);
    }

    public void Execute()
    {
        OnExecute();
    }

    protected void SetDestination(Vector3 point)
    {
        _point = point;
        _navMeshAgent.SetDestination(_point);
    }

    public void OnDestroy()
    {
        GameManager.Singleton.RemoveExecuteObject(this);
    }
}