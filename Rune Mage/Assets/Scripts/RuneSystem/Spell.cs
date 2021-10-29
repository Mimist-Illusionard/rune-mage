﻿using System;
using System.Collections.Generic;

using UnityEngine;


[CreateAssetMenu(fileName = "Spell", menuName = "Data/SpellSystem/Spell")]
[Serializable]
public class Spell : ScriptableObject
{
    public string Name;
    public float ManaCost;
    public int Length;
    public List<Rune> Runes = new List<Rune>();
    public GameObject Prefab;
    public InputModeType InputMode = InputModeType.Down;
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
