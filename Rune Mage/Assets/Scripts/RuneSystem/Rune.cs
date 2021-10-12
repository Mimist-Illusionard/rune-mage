using UnityEngine;

using System;
using System.Collections.Generic;


[CreateAssetMenu(fileName = "Rune", menuName = "Data/SpellSystem/Rune")]
[Serializable]
public class Rune : ScriptableObject
{
    public Sprite Sprite;
    public string Name;
    public List<SpellNodeData> SpellNodes = new List<SpellNodeData>();
}
