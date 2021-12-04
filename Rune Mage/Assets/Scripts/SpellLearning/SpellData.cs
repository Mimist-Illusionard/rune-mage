using UnityEngine;

using System;

[Serializable]
[CreateAssetMenu(fileName = "SpellData", menuName = "Data/SpellSystem/SpellData")]
public class SpellData : ScriptableObject
{
    public GameObject Prefab;
    public Spell Spell;
    public bool IsKnown;
}
