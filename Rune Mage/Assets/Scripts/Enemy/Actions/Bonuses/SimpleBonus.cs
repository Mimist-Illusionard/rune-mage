using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public enum Buff
{
    Health,
    Speed,
    Damage,
    BulletSpeed,
    AttackRadius
}

public class SimpleBonus : IEnemyAction
{
    public Buff buff;
    public float BuffPW;

    public GameObject bject { get; set; }
    private IEnemyAction _parent;

    public void ExitToMain()
    {
        bject.GetComponentInObject<EnemyMain>().ReturnAction();
    }

    public void PlayAction(GameObject @object, IEnemyAction _Parent)
    {
        _parent = _Parent;
        bject = @object;
        if (buff == Buff.Health) bject.GetComponentInObject<EnemyData>().Health += BuffPW;
        else if (buff == Buff.Speed) bject.GetComponentInObject<EnemyData>().Speed += BuffPW;
        else if (buff == Buff.Damage) bject.GetComponentInObject<EnemyData>()._bulletDamage += BuffPW;
        else if (buff == Buff.BulletSpeed) bject.GetComponentInObject<EnemyData>()._bulletSpeed += BuffPW;
        else if (buff == Buff.AttackRadius) bject.GetComponentInObject<EnemyData>().AttackRadius += BuffPW;
        if (_parent != null)
        { _parent.ExitToMain(); }
        else { ExitToMain(); }
        _parent = null;
    }
}
