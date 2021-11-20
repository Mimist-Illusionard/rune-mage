using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallel : IEnemyAction
{
    public GameObject bject { get; set; }
    public bool _isParellel { get; set; }
    private IEnemyAction _parent;
    public IEnemyAction[] actions;
    private int _ActionsNum;

    public void ExitToMain()
    {
        _ActionsNum++;
        if (_ActionsNum == actions.Length) {
            if (_parent != null)
            { _parent.ExitToMain(); }
            else { bject.GetComponent<EnemyMain>().ReturnAction(); }
            _parent = null;

            _ActionsNum = 0;
        }
    }

    public void PlayAction(GameObject @object, IEnemyAction _Parent)
    {
        _parent = _Parent;
        bject = @object;
        for (int i = 0; i < actions.Length; i++)
        {
            actions[i].PlayAction(bject,this);
        }
    }
}
