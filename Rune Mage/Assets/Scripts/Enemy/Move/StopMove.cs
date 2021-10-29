using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StopMove : MonoBehaviour, IEnemyAction
{
    public void ExitToMain()
    {
        gameObject.GetComponent<EnemyMain>().ReturnAction();
    }

    public void PlayAction()
    {
        gameObject.GetComponent<NavMeshAgent>().isStopped = true;
        ExitToMain();
    }
}
