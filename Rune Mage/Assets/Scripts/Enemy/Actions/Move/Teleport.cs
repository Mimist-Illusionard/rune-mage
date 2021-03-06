using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Teleport : IEnemyAction
{
    public float Delay;

    public GameObject bject { get; set; }
    private IEnemyAction _parent;

    public void ExitToMain()
    {
        if (!bject) return;
        bject.GetComponentInObject<EnemyMain>().ReturnAction();
    }

    public void PlayAction(GameObject @object, IEnemyAction _Parent)
    {
        bject = @object;
        _parent = _Parent;
        if (Delay > 0)
        {
            CoroutineManager.Singleton.RunCoroutine(waitDelay());
        }
        else
        {
            TP();
        }
        
    }

    private IEnumerator waitDelay()
    {
        yield return new WaitForSeconds(Delay);
        if (!bject) yield return null;
        TP();
    }

    private void TP()
    {
        if (!bject) return;
        bject.GetComponent<NavMeshAgent>().enabled = false;
        TransformEngine.TeleportObj(bject, AIController.Singleton.GetPointToDistination(bject.GetComponent<EnemyData>().behavior));
        bject.GetComponent<NavMeshAgent>().enabled = true;
        if (_parent != null)
        { _parent.ExitToMain(); }
        else { ExitToMain(); }
        _parent = null;
    }
}
