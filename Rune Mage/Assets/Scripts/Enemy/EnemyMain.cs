using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class EnemyMain : SerializedMonoBehaviour, IEnemys
{
    public EnemyData data;

    [Header("ActionSystem")]
    public List<IEnemyAction> enemyActions = new List<IEnemyAction>();
    public int currentAction;
    private int _actionsCout;
    
    public float TargetDistance { get; set; }
    public bool TargetVisible { get; set; }
    public Vector3 TargetPos { get; set; }
    public Vector3 CurretPos { get; set; }
    public bool ActionPoint { get; set; }

    private void Start()
    {
        data.target = GameObject.FindGameObjectWithTag("Player").GetComponent<MonoBehaviour>();
        FindObjectOfType<AIController>().enemys.Add(this);
        gameObject.GetComponent<Health>().OnHealthZero += Death;
        ActionPoint = true;
        GetAction();
    }


    public void GetTargetInfo()
    {
        CurretPos = gameObject.transform.position;
        TargetPos = data.target.gameObject.transform.position;
        TargetDistance = Vector3.Distance(CurretPos, TargetPos);
        RaycastHit hit;
        if (Physics.Raycast(new Vector3(CurretPos.x,CurretPos.y,CurretPos.z),TargetPos - CurretPos,out hit))
        {
             TargetVisible = hit.collider.GetComponent<Player>();
        }
        if (TargetVisible) { Debug.DrawRay(new Vector3(CurretPos.x, CurretPos.y, CurretPos.z), TargetPos - CurretPos, Color.green); } else { Debug.DrawRay(new Vector3(CurretPos.x, CurretPos.y, CurretPos.z), TargetPos - CurretPos, Color.red); }
    }

    public void GetAction()
    {
        enemyActions[currentAction].PlayAction(gameObject);
    }

    public void ReturnAction(/*bool isParallel*/)
    {
        currentAction++;
        if (currentAction == enemyActions.Count) currentAction = 0;
        GetAction();
    }

    public void Death()
    {
        FindObjectOfType<AIController>().RemoveEnemy(this);
        Destroy(gameObject);
    }
}
