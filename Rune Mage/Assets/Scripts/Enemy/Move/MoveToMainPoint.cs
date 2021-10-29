using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToMainPoint : MonoBehaviour, IEnemyAction
{
    private GameObject[] points;
    public void ExitToMain()
    {
        gameObject.GetComponent<EnemyMain>().ReturnAction();
    }

    public void PlayAction()
    {
        gameObject.GetComponent<NavMeshAgent>().isStopped = false;
        points = GameObject.FindGameObjectsWithTag("MainPoint");
        gameObject.GetComponent<NavMeshAgent>().destination = points[Random.Range(0, points.Length)].transform.position;
        gameObject.GetComponent<NavMeshAgent>().speed = gameObject.GetComponent<EnemyData>().Speed;
        StartCoroutine(tt());
    }

    private IEnumerator tt()
    {
        for (; ; )
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
