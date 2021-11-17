using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallel : IEnemyAction
{
    public GameObject bject { get; set; }
    public bool _isParellel { get; set; }

    public IEnemyAction[] actions;
    private int _ActionsNum;

    public void ExitToMain()
    {
        _ActionsNum++;
        if (_ActionsNum == actions.Length) bject.GetComponentInObject<EnemyMain>().ReturnAction();
        _ActionsNum = 0;
    }

    public void PlayAction(GameObject @object, IEnemyAction _Parent)
    {

        bject = @object;
        for (int i = 0; i < actions.Length; i++)
        {
            actions[i].PlayAction(bject,this);
        }
    }
}
