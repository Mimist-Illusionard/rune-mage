using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawner : MonoBehaviour
{
    public int EnemyPoints;
    private AIController aIController;

    [Header("EnemysLists")]
    public List<GameObject> PointsEnemys_1 = new List<GameObject>();
    public List<GameObject> PointsEnemys_4 = new List<GameObject>();
    public List<GameObject> PointsEnemys_8 = new List<GameObject>();

    [Header("100% Summon in first wave")]
    public List<GameObject> Summons = new List<GameObject>();

    [Header("SpawnSettings")]
    private List<GameObject> SpawnPoints = new List<GameObject>();
    private int CurrentWave = 0;

    private void Awake()
    {
        aIController = gameObject.GetComponent<AIController>();
    }

    void Start()
    {
        SpawnPoints = AIController.Singleton.MainPoints;
        StartCoroutine(FirstWave());
    }

    private IEnumerator FirstWave()
    {
        for (int i = 0; i < Summons.Count;i++)
        {
            yield return new WaitForSeconds(0.2f);
            var a = Instantiate(Summons[i], null);
            a.transform.position = SpawnPoints[Random.Range(0, SpawnPoints.Count)].transform.position;
        }
        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        for (int i = 0; i < 6; i++)
        {
            yield return new WaitForSeconds(0.1f);
            if (Random.value < 0.33)
            {
                SpawnRandom(PointsEnemys_1, 1);
            }
            else if (Random.value > 0.33 && Random.value < 0.66)
            {
                SpawnRandom(PointsEnemys_4, 4);
            }
            else
            {
                SpawnRandom(PointsEnemys_8, 8);
            }
        }
        while (EnemyPoints > 0)
        {
            yield return new WaitForSeconds(0.2f);
            if (Random.value < 0.33)
            {
                SpawnRandom(PointsEnemys_1, 1);
            }
            else if (Random.value > 0.33 && Random.value < 0.66)
            {
                SpawnRandom(PointsEnemys_4, 4);
            }
            else
            {
                SpawnRandom(PointsEnemys_8, 8);
            }
            if(EnemyPoints == 1) break; 
        }
        CurrentWave++;
    }

    public void AddPoint()
    {
        EnemyPoints += 2;
        if (aIController.enemys.Count <= 1) CheckWave();
    }

    private void CheckWave()
    {
        if (CurrentWave <= 2)
        {
            if (EnemyPoints > 20)
            {
                StartCoroutine(SpawnWave());
            }
        }
        else
        {
            //Exit
            Debug.LogError("Exit");
        }
    }

    private void SpawnRandom(List<GameObject> Summ,int cost)
    {
        if (EnemyPoints > cost)
        {
            if (Summ.Count == 0) return;
            var a = Instantiate(Summ[Random.Range(0, Summ.Count)], null);
            a.transform.position = SpawnPoints[Random.Range(0, SpawnPoints.Count)].transform.position;
            EnemyPoints -= cost;
        }
    }
}
