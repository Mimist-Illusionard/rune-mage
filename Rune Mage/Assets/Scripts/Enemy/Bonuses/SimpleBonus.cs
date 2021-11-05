using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Buff
{
    Health,
    Speed,
    Damage,
    BulletSpeed,
    AttackRadius
}

public class SimpleBonus : MonoBehaviour, IEnemyAction
{
    public Buff buff;
    public float BuffPW;

    public void ExitToMain()
    {
        gameObject.GetComponentInObject<EnemyMain>().ReturnAction();
    }

    public void PlayAction()
    {
        if (buff == Buff.Health) gameObject.GetComponentInObject<EnemyData>().Health += BuffPW;
        else if (buff == Buff.Speed) gameObject.GetComponentInObject<EnemyData>().Speed += BuffPW;
        else if (buff == Buff.Damage) gameObject.GetComponentInObject<EnemyData>()._bulletDamage += BuffPW;
        else if (buff == Buff.BulletSpeed) gameObject.GetComponentInObject<EnemyData>()._bulletSpeed += BuffPW;
        else if (buff == Buff.AttackRadius) gameObject.GetComponentInObject<EnemyData>().AttackRadius += BuffPW;
        ExitToMain();
    }
}
