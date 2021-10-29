using UnityEngine;

using System;


[CreateAssetMenu(fileName = "Rune", menuName = "Data/SpellSystem/Rune")]
[Serializable]
public class Rune : ScriptableObject
{
    public Sprite Sprite;
    public string Name;
}
