using System;
using System.Collections.Generic;

using UnityEngine;


[CreateAssetMenu(fileName = "Spell", menuName = "Data/SpellSystem/Spell")]
[Serializable]
public class Spell : ScriptableObject
{
    public Sprite Sprite;
    public GameObject Prefab;
    public List<Rune> Runes = new List<Rune>();
    public InputModeType InputMode = InputModeType.Down;

    public string Name;
    public float ManaCost;
    public int Length;
    public float Interval;

    public List<SpellNodeData> SpellNodes = new List<SpellNodeData>();
    public List<GroupData> Groups = new List<GroupData>();

    public void SpellLogic()
    {
        var spell = Instantiate(Prefab);

        var spellLogic = new SpellLogic(SpellNodes);
        spellLogic.Logic(spell);       
    }
}
