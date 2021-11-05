using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardSpawnAttack : MonoBehaviour, IEnemyAction
{
    public float TickTime;

    public void ExitToMain()
    {
        
    }

    public void PlayAction()
    {
        
    }

    IEnumerator tt()
    {
        yield return new WaitForEndOfFrame();
    }
}
