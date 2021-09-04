using UnityEngine;
using System;


[CreateAssetMenu(fileName = "Rune", menuName = "Data/Rune/Rune")]
[Serializable]
public class Rune : ScriptableObject
{
    public Sprite Sprite;
    public string Name;
}
