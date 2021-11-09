using UnityEngine;

using System;

using Sirenix.OdinInspector;


[CreateAssetMenu(fileName = "Rune", menuName = "Data/SpellSystem/Rune")]
[Serializable]
public class Rune : ScriptableObject
{
    [PreviewField(80f, Alignment = ObjectFieldAlignment.Left), HideLabel, HorizontalGroup("Split", 80)]
    public Sprite Sprite;
    [LabelText("Name"), VerticalGroup("Split/Right"), LabelWidth(60)]
    public string Name;
}
