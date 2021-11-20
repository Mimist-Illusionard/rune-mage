using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Empty : IEnemyAction
{
    public GameObject bject { get; set; }

    public void ExitToMain()
    {
        bject.GetComponent<EnemyMain>().ReturnAction();
    }

    public void PlayAction(GameObject @object, IEnemyAction _Parent = null)
    {
        bject = @object;
        if (_Parent != null)
        { _Parent.ExitToMain(); }
        else { ExitToMain(); }
        _Parent = null;
    }
}
