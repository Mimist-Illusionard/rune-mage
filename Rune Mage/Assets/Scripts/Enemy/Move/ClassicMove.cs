using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClassicMove : MonoBehaviour, IEnemyAction
{
    public void ExitToMain()
    {
        gameObject.GetComponent<EnemyMain>().ReturnAction();
    }

    public void PlayAction()
    {
        gameObject.GetComponent<NavMeshAgent>().isStopped = false;
        gameObject.GetComponent<NavMeshAgent>().destination = gameObject.GetComponent<EnemyData>().target.transform.position;
        gameObject.GetComponent<NavMeshAgent>().speed = gameObject.GetComponent<EnemyData>().Speed;
        StartCoroutine(tt());
    }
    
    private IEnumerator tt()
    {
        for(; ; )
        {
            yield return new WaitForSeconds(0.1f);
            if (gameObject.GetComponent<NavMeshAgent>().remainingDistance <= 0.3f + gameObject.GetComponent<NavMeshAgent>().stoppingDistance)
            {
                break;
            }
        }
        ExitToMain();
    }
}
