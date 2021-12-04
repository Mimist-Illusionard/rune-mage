using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomUse : IEnemyAction
{
    public List<IEnemyAction> actions = new List<IEnemyAction>();

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
        actions[Random.Range(0, actions.Count)].PlayAction(bject, _parent);
        if (_parent != null)
        { _parent.ExitToMain(); }
        else { ExitToMain(); }
        _parent = null;
    }
}
