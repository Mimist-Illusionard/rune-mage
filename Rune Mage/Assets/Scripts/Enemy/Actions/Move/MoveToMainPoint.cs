using System.Collections;
using UnityEngine;
using UnityEngine.AI;


public class MoveToMainPoint : IEnemyAction
{
    private GameObject point;
    private IEnemyAction _parent;
    public GameObject bject { get; set; }
    public bool _isParellel { get; set; }

    public void ExitToMain()
    {
        if (!bject) return;
        bject.GetComponent<EnemyMain>().ReturnAction();
    }

    public void PlayAction(GameObject @object, IEnemyAction _Parent)
    {
        _parent = _Parent;
        bject = @object;
        bject.GetComponent<NavMeshAgent>().isStopped = false;
        bject.GetComponent<NavMeshAgent>().destination = AIController.Singleton.GetPointToDistination(bject.GetComponent<EnemyData>().behavior);
        bject.GetComponent<NavMeshAgent>().speed = bject.GetComponent<EnemyData>().Speed;
        CoroutineManager.Singleton.RunCoroutine(tt());
    }

    private IEnumerator tt()
    {
        for (; ; )
        {
            if (!bject) break;
            yield return new WaitForSeconds(0.1f);
            if(!bject) break;
            if (bject.TryGetComponent<NavMeshAgent>(out var navMeshAgent) && navMeshAgent.remainingDistance <= 0.3f + navMeshAgent.stoppingDistance) break;
        }
        if (_parent != null)
        { _parent.ExitToMain(); }
        else { ExitToMain(); }
        _parent = null;
    }
}
