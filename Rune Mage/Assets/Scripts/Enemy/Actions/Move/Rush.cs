using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rush : IEnemyAction
{
    public float NeedToTarget;

    public GameObject bject { get; set; }
    private IEnemyAction _parent;

    public void ExitToMain()
    {
        if (!bject) return;
        bject.GetComponentInObject<EnemyMain>().ReturnAction();
    }

    public void PlayAction(GameObject @object, IEnemyAction _Parent)
    {
        _parent = _Parent;
        bject = @object;
        CoroutineManager.Singleton.RunCoroutine(Push());
    }

    private IEnumerator Push()
    {
        for(int i = 0; i<100;i++)
        {
            yield return new WaitForSeconds(0.01f);
            if (!bject) yield return null;
            if (bject.GetComponent<EnemyMain>().TargetDistance < NeedToTarget) break;
            TransformEngine.TransformPos(bject, bject.transform.forward * 0.1f);
        }
        if (_parent != null)
        { _parent.ExitToMain(); }
        else { ExitToMain(); }
        _parent = null;
    }
}
