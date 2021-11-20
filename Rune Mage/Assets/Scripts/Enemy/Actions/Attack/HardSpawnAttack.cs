using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class HardSpawnAttack : IEnemyAction
{
    public GameObject HardBulletPref;
    public int AttacksCount;
    public float TickTime;

    private IEnemyAction _parent;
    public GameObject bject { get; set; }
    public bool _isParellel { get; set; }

    public void ExitToMain()
    {
        if (!bject) return;
        bject.GetComponent<EnemyMain>().ReturnAction();
    }

    public void PlayAction(GameObject @object, IEnemyAction _Parent)
    {
        bject = @object;
        _parent = _Parent;
        CoroutineManager.Singleton.RunCoroutine(tt());
    }

    IEnumerator tt()
    {
        for (int i = 0;i<AttacksCount;i++)
        {
            if (!bject) break;
            yield return new WaitForSeconds(TickTime);
            var Bul = Object.Instantiate(HardBulletPref,null);
            Bul.gameObject.transform.position = bject.gameObject.transform.position;
            Bul.transform.Rotate(new Vector3(Random.Range(-135, -45), Random.Range(-60, 60), Random.Range(-60, 60)));
            Bul.GetComponent<SimpleHardBul>().Target = bject.GetComponent<EnemyData>().target.gameObject;
        }
        if (_parent != null)
        { _parent.ExitToMain(); }
        else { ExitToMain(); }
        _parent = null;
    }
}
