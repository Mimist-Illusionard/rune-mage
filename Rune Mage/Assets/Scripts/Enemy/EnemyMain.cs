using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMain : MonoBehaviour, IEnemys
{
    public EnemyData data;


    public MonoBehaviour Target;
    public float TargetDistance { get; set; }
    public bool TargetVisible { get; set; }
    public Vector3 TargetPos { get; set; }
    public Vector3 CurretPos { get; set; }
    public bool ActionPoint { get; set; }

    private void Start()
    {
        
    }

    public void GetTargetInfo()
    {
        CurretPos = gameObject.transform.position;
        TargetPos = Target.gameObject.transform.position;
        TargetDistance = Vector3.Distance(CurretPos, TargetPos);
        TargetVisible = Physics.Linecast(CurretPos, TargetPos) ?  false : true;
    }

    public void GetAction()
    {
        if (!ActionPoint) return;
        
    }

    private void StartActon(string status)
    {
        if (status == "Move") MovingToPlayer();
        if (status == "Attack") ClassicAttack();
        if (status == "Melee") MeleeAtack();
        ActionPoint = false;
    }

    private void MovingToPlayer()
    {

    }

    private void ClassicAttack()
    {

    }

    private void MeleeAtack()
    {
        //Use for Ranged units or static enemys
        //if Classic attack is melee - dont use
    }
}
