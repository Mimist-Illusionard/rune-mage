using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class HardSpawnAttack : IEnemyAction
{
    public float TickTime;

    public GameObject bject { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public bool _isParellel { get; set; }

    public void ExitToMain()
    {
        
    }

    public void PlayAction(GameObject @object, IEnemyAction _Parent)
    {
        throw new System.NotImplementedException();
    }

    IEnumerator tt()
    {
        yield return new WaitForEndOfFrame();
    }
}
