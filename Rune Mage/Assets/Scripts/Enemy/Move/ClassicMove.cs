using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClassicMove : MonoBehaviour, IEnemyAction
{
    public void ExitToMain()
    {
        gameObject.GetComponentInObject<EnemyMain>().ReturnAction();
    }

    public void PlayAction()
    {
        gameObject.GetComponentInObject<NavMeshAgent>().isStopped = false;
        gameObject.GetComponentInObject<NavMeshAgent>().destination = gameObject.GetComponentInObject<EnemyData>().target.transform.position;
        gameObject.GetComponentInObject<NavMeshAgent>().speed = gameObject.GetComponentInObject<EnemyData>().Speed;
        StartCoroutine(tt());
    }
    
    private IEnumerator tt()
    {
        for(; ; )
        {
            yield return new WaitForSeconds(0.1f);
            if (gameObject.GetComponentInObject<NavMeshAgent>().remainingDistance <= 0.3f + gameObject.GetComponentInObject<NavMeshAgent>().stoppingDistance)
            {
                break;
            }
        }
        ExitToMain();
    }
}
