using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeUseParallel : IEnemyAction
{
    public float TimeToActive;
    public float Tick;


    public GameObject bject { get; set; }
    private IEnemyAction _parent;

    public void ExitToMain()
    {
        
    }

    public void PlayAction(GameObject @object, IEnemyAction _Parent)
    {
        bject = @object;
        _parent = _Parent;
    }

    
}
