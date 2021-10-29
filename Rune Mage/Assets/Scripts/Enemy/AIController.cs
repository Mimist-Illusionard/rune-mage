using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public List<IEnemys> enemys = new List<IEnemys>();

    private void Start()
    {
        StartCoroutine(FXUpdate());
    }

    private IEnumerator FXUpdate()
    {
        yield return new WaitForSeconds(0.01f);
        StartCoroutine(FXUpdate());
    }

    private void EnemyActionInfo()
    {
        for (int i = 0; i < enemys.Count;i++)
        {
            enemys[i].GetTargetInfo();
        }
    }
}
