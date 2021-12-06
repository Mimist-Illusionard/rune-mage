using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeUseParallel : IEnemyAction
{
    public IEnemyAction MainAction;
    public IEnemyAction SubActtion;

    public float TimeToActive;
    public float Tick;


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
    }

    public IEnumerator Activate()
    {
        MainAction.PlayAction(bject,this);
        for(float i = TimeToActive; i > 0; i -= Tick)
        {
            yield return new WaitForSeconds(Tick);
            if (!bject) yield return null;
            SubActtion.PlayAction(bject, this);
        }
        if (_parent != null)
        { _parent.ExitToMain(); }
        else { ExitToMain(); }
        _parent = null;
    }
}
