using System;
using System.Collections.Generic;

using UnityEngine;


[CreateAssetMenu(fileName = "Spell", menuName = "Data/Rune/Spell")]
[Serializable]
public class Spell : ScriptableObject
{
    public string Name;
    public int Length;
    public List<Rune> Runes = new List<Rune>();
    public GameObject Prefab;

    public void SpellLogic()
    {
        var spawnPoint = FindObjectOfType<Spawnpoint>().transform;
        var bullet = Instantiate(Prefab, spawnPoint.position, spawnPoint.rotation);
        bullet.GetComponent<Projectile>().SetSpawnPoint(spawnPoint);
    }
}
