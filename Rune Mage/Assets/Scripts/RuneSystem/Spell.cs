using System;
using System.Collections.Generic;

using UnityEngine;


[CreateAssetMenu(fileName = "Spell", menuName = "Data/Rune/Spell")]
[Serializable]
public class Spell : ScriptableObject
{
    public string Name;
    public float ManaCost;
    public int Length;
    public List<Rune> Runes = new List<Rune>();
    public List<SpellNodeData> SpellNodes = new List<SpellNodeData>();
    public GameObject Prefab;
    public SpellEnum Type = 0;

    public void SpellLogic()
    {
        var spellLogic = new SpellLogic(SpellNodes);
        spellLogic.Logic();

        //if (Type == SpellEnum.Bullet)
        //{
        //    var spawnPoint = FindObjectOfType<Spawnpoint>().transform;
        //    var bullet = Instantiate(Prefab, spawnPoint.position, spawnPoint.rotation);
        //    bullet.GetComponent<Projectile>().SetSpawnPoint(spawnPoint);
        //}

        //if (Type == SpellEnum.Zone)
        //{
        //    RaycastHit raycastHit = PlayerManager.Singleton.Raycast();
        //    Instantiate(Prefab, raycastHit.point, Quaternion.identity);
        //}
    }
}
