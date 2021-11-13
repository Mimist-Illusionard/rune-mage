using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Threading.Tasks;
using System.Threading;

public class ClassicMove : IEnemyAction
{
    public GameObject bject { get; set; }

    public void ExitToMain()
    {
        bject.GetComponentInObject<EnemyMain>().ReturnAction();
    }

    public void PlayAction(GameObject @object)
    {
        bject = @object;
        @object.GetComponentInObject<NavMeshAgent>().isStopped = false;
        @object.GetComponentInObject<NavMeshAgent>().destination = @object.GetComponentInObject<EnemyData>().target.transform.position;
        @object.GetComponentInObject<NavMeshAgent>().speed = @object.GetComponentInObject<EnemyData>().Speed;
        CoroutineManager.Singleton.RunCoroutine(CorutineWaitForStop());
    }

    private IEnumerator CorutineWaitForStop()
    {
        for (; ; )
        {
            yield return new WaitForSeconds(0.1f);
            if (bject.GetComponentInObject<NavMeshAgent>().remainingDistance <= 0.3f + bject.GetComponentInObject<NavMeshAgent>().stoppingDistance)
            {
                break;
            }
        }
        ExitToMain();
    }

}
