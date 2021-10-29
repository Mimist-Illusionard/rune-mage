using UnityEngine;


[CreateAssetMenu(fileName = "SpellInfo", menuName ="Data/SpellSystem/SpellInfo")]
public class SpellInfo : ScriptableObject
{
    public Spell Spell;
    [TextArea] public string Description;
}
