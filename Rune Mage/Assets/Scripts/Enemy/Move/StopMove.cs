using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class StopMove : IEnemyAction
{
    public GameObject bject { get; set; }

    public void ExitToMain()
    {
        bject.GetComponent<EnemyMain>().ReturnAction();
    }

    public void PlayAction(GameObject @object, CancellationToken token)
    {
        bject = @object;
        bject.GetComponent<NavMeshAgent>().isStopped = true;
        ExitToMain();
    }
}
