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
        bject.GetComponent<EnemyMain>().ReturnAction();
    }

    public void PlayAction(GameObject @object, IEnemyAction _Parent)
    {
        _parent = _Parent;
        bject = @object;
        bject.GetComponent<NavMeshAgent>().isStopped = false;
        point = GameObject.FindGameObjectWithTag("MainPoint");
        bject.GetComponent<NavMeshAgent>().destination = point.transform.GetChild(Random.Range(0, point.transform.childCount)).transform.position;
        bject.GetComponent<NavMeshAgent>().speed = bject.GetComponent<EnemyData>().Speed;
        CoroutineManager.Singleton.RunCoroutine(tt());
    }

    private IEnumerator tt()
    {
        for (; ; )
        {
            if (!bject) break;
            yield return new WaitForSeconds(0.1f);
            if (bject.GetComponent<NavMeshAgent>().remainingDistance <= 0.3f + bject.GetComponent<NavMeshAgent>().stoppingDistance)
            {
                break;
            }
        }
        if (_parent != null)
        { _parent.ExitToMain(); }
        else { ExitToMain(); }
    }
}
