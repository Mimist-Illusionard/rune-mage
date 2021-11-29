using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeData : ISpecialAction
{
    public Statet statet;
    public Buff buff;
    public float BuffValue;

    private GameObject bject;

    public void StartAction(GameObject @object)
    {
        bject = @object;
        if (statet == Statet.Add)
        { AddStats(); }
        else if (statet == Statet.Change)
        { ChangeStats(); }
    }

    private void AddStats()
    {
        if (buff == Buff.Health) bject.GetComponentInObject<EnemyData>().Health += BuffValue;
        else if (buff == Buff.Speed) bject.GetComponentInObject<EnemyData>().Speed += BuffValue;
        else if (buff == Buff.Damage) bject.GetComponentInObject<EnemyData>()._bulletDamage += BuffValue;
        else if (buff == Buff.BulletSpeed) bject.GetComponentInObject<EnemyData>()._bulletSpeed += BuffValue;
        else if (buff == Buff.AttackRadius) bject.GetComponentInObject<EnemyData>().AttackRadius += BuffValue;
    }

    private void ChangeStats()
    {
        if (buff == Buff.Health) bject.GetComponentInObject<EnemyData>().Health = BuffValue;
        else if (buff == Buff.Speed) bject.GetComponentInObject<EnemyData>().Speed = BuffValue;
        else if (buff == Buff.Damage) bject.GetComponentInObject<EnemyData>()._bulletDamage = BuffValue;
        else if (buff == Buff.BulletSpeed) bject.GetComponentInObject<EnemyData>()._bulletSpeed = BuffValue;
        else if (buff == Buff.AttackRadius) bject.GetComponentInObject<EnemyData>().AttackRadius = BuffValue;
    }
}

public enum Statet
{
    Add,
    Change
}
