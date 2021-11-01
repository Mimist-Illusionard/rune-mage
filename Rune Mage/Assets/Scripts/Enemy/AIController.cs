using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour,IExecute
{
    public List<IEnemys> enemys = new List<IEnemys>();

    private void Start()
    {
        GameManager.Singleton.AddExecuteObject(this);
    }

    private void EnemyActionInfo()
    {
        for (int i = 0; i < enemys.Count;i++)
        {
            enemys[i].GetTargetInfo();
        }
    }

    public void Execute()
    {
        EnemyActionInfo();
    }
}
