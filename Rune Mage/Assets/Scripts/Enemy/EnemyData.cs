using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    public MonoBehaviour target;
    public float Health;
    public float Speed;
    [Header("Distanse Logic")]
    public float AttackRadius;
    public float MeleeRadius;
}
