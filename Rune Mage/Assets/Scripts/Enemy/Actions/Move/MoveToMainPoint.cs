using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Threading.Tasks;
using System.Threading;

public class MoveToMainPoint : IEnemyAction
{
    private GameObject[] points;

    public GameObject bject { get; set; }

    public void ExitToMain()
    {
        bject.GetComponent<EnemyMain>().ReturnAction();
    }

    public void PlayAction(GameObject @object)
    {
        bject = @object;
        bject.GetComponent<NavMeshAgent>().isStopped = false;
        //points = GameObject.FindGameObjectsWithTag("MainPoint");
        bject.GetComponent<NavMeshAgent>().destination = GameObject.FindGameObjectWithTag("MainPoint").transform.parent.GetChild(Random.Range(0, GameObject.FindGameObjectWithTag("MainPoint").transform.childCount)).transform.position;
        //bject.GetComponent<NavMeshAgent>().destination = points[Random.Range(0, points.Length)].transform.position;
        bject.GetComponent<NavMeshAgent>().speed = bject.GetComponent<EnemyData>().Speed;
        CoroutineManager.Singleton.RunCoroutine(tt());
    }

    private IEnumerator tt()
    {
        for (; ; )
        {
            yield return new WaitForSeconds(0.1f);
            if (bject.GetComponent<NavMeshAgent>().remainingDistance <= 0.3f + bject.GetComponent<NavMeshAgent>().stoppingDistance)
            {
                break;
            }
        } 
        ExitToMain();
    }


}
