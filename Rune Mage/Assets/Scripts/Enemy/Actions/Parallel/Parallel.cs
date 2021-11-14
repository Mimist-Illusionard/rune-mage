using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallel : IEnemyAction
{
    public GameObject bject { get; set; }

    public IEnemyAction[] actions;

    public void ExitToMain()
    {
        
    }

    public void PlayAction(GameObject @object)
    {
        bject = @object;
        for (int i = 0; i< actions.Length;i++)
        {
            actions[i].PlayAction(bject);
        }
        ExitToMain();
    }
}
