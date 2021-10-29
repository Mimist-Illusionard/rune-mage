using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    public MonoBehaviour target;
    [Header("Stats")]
    public behavior behavior;
    public float Health;
    public float Speed;
    [Header("Distanse Logic")]
    public float AttackRadius;
    public float MeleeRadius;
    [Header("Bullet")]
    public GameObject _bulletPrefab;
    public float _bulletDamage;
    public float _bulletLifeTime;
    public float _bulletSpeed;
}
public enum behavior
{
    none,
    agressive,
    offensive,
    piu_piu
}
