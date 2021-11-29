using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : IEnemyAction
{
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
        CoroutineManager.Singleton.RunCoroutine(Looking());
    }

    private IEnumerator Looking()
    {
        for(int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.01f);
            if (!bject) yield return null;
            TransformEngine.TransformLookAt(bject, bject.GetComponent<EnemyData>().target.transform.position, 10f);
        }
        if (_parent != null)
        { _parent.ExitToMain(); }
        else { ExitToMain(); }
        _parent = null;
    }
}
