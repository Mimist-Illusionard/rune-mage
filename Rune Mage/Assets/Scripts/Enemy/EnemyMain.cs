using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMain : MonoBehaviour, IEnemys
{
    public EnemyData data;

    [Header("ActionSystem")]
    private List<IEnemyAction> enemyActions = new List<IEnemyAction>();
    public int currentAction;
    
    public float TargetDistance { get; set; }
    public bool TargetVisible { get; set; }
    public Vector3 TargetPos { get; set; }
    public Vector3 CurretPos { get; set; }
    public bool ActionPoint { get; set; }

    private void Start()
    {
        FindObjectOfType<AIController>().enemys.Add(this);
        gameObject.GetComponent<Health>().OnHealthZero += Death;
        enemyActions.AddRange(gameObject.GetComponents<IEnemyAction>());
        ActionPoint = true;
        GetAction();
    }


    public void GetTargetInfo()
    {
        CurretPos = gameObject.transform.position;
        TargetPos = data.target.gameObject.transform.position;
        TargetDistance = Vector3.Distance(CurretPos, TargetPos);
        TargetVisible = Physics.Linecast(CurretPos, TargetPos) ?  false : true;
    }

    public void GetAction()
    {
        if (!ActionPoint) return;
        enemyActions[currentAction].PlayAction();
    }

    public void ReturnAction()
    {
        ActionPoint = true;
        currentAction++;
        if (currentAction == enemyActions.Count) currentAction = 0;
        GetAction();
    }

    public void Death()
    {
        FindObjectOfType<AIController>().enemys.Remove(this);
        Destroy(gameObject);
    }
}
