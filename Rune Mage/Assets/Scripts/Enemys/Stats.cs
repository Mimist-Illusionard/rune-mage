using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    /* foreach (var field in typeof(StatsCreature).GetFields())
        {
            field.SetValue(b, field.GetValue(creature));
        } */

    public string Name;
    public GameObject Model;
    public float RotateSpeed;
    public float Cost;
    public float SpawnTime;
    [Header("Stats")]
    public float Health;
    //[Range(0.0001f,0.1f)]
    public float Speed;
    public float Attack;
    public float AttackSped;
    public float AttackRange;
    [Header("ModelSettings")]
    public float Radius;
}
