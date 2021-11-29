using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour,IExecute
{
    public List<IEnemys> enemys = new List<IEnemys>();
    public static AIController Singleton { get; private set; }
    private AISpawner aISpawner;
    [HideInInspector] public List<GameObject> MainPoints = new List<GameObject>();
    private GameObject _player;
    [Header("Settings")]
    public float AggresiveDistance;
    public float Y_PointHeight;

    private void Awake()
    {
        Singleton = this;
        MainPoints.AddRange(GameObject.FindGameObjectsWithTag("MainPoint"));
        _player = FindObjectOfType<Player>().gameObject;
        GameManager.Singleton.AddExecuteObject(this);
        aISpawner = gameObject.GetComponent<AISpawner>();
    }

    private void Start()
    {

    }

    public void RemoveEnemy(EnemyMain enemy)
    {
        aISpawner.AddPoint();
        enemys.Remove(enemy);
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

    public Vector3 GetPointToDistination(behavior behavior)
    {
        Vector3 Point = new Vector3();
        if (behavior == behavior.none) { Point = RandomPoint(); }
        else if (behavior == behavior.agressive) { Point = AgressivePoint(); }
        else if (behavior == behavior.defense) { Point = DefensePoint(); }
        else if (behavior == behavior.piu_piu) { Point = PiuPiuPoint(); }
        return Point;
    }

    private Vector3 AgressivePoint()
    {
        List<GameObject> objects = new List<GameObject>();
        for (int i = 0; i < MainPoints.Count; i++)
        {
            if (Vector3.Distance(MainPoints[i].transform.position,_player.transform.position) <= AggresiveDistance)
            {
                objects.Add(MainPoints[i]);
            }
            
        }
        if(objects.Count == 0) { objects.Add(MainPoints[Random.Range(0, MainPoints.Count)]); }
        return objects[Random.Range(0, objects.Count)].transform.position;
    }

    private Vector3 DefensePoint()
    {
        List<GameObject> objects = new List<GameObject>();
        for (int i = 0; i < MainPoints.Count; i++)
        {
            if (Vector3.Distance(MainPoints[i].transform.position, _player.transform.position) > AggresiveDistance)
            {
                objects.Add(MainPoints[i]);
            }
        }
        if (objects.Count == 0) { objects.Add(MainPoints[Random.Range(0, MainPoints.Count)]); }
        return objects[Random.Range(0, objects.Count)].transform.position;
    }

    private Vector3 RandomPoint()
    {
        return MainPoints[Random.Range(0, MainPoints.Count)].transform.position;
    }

    private Vector3 PiuPiuPoint()
    {
        List<GameObject> objects = new List<GameObject>();
        for (int i = 0; i < MainPoints.Count; i++)
        {
            if (MainPoints[i].transform.position.y >= Y_PointHeight)
            {
                objects.Add(MainPoints[i]);
            }
        }
        if (objects.Count == 0) { objects.Add(MainPoints[Random.Range(0, MainPoints.Count)]); }
        return objects[Random.Range(0, objects.Count)].transform.position;
    }
}
