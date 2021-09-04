using System.Collections.Generic;
using UnityEngine;


public class SpellsSystem : MonoBehaviour
{
    [SerializeField] private List<Spell> _spells = new List<Spell>();

    public List<Rune> _currentRunes = new List<Rune>();
    public static SpellsSystem Singleton { get; private set; }

    private void Awake()
    {
        Singleton = this;
    }


    public void AddNewRune(Rune rune)
    {
        _currentRunes.Add(rune);
    }

    public void UseSpell()
    {
        var spellLength = _currentRunes.Count;
        List<Spell> appropriateSpells = new List<Spell>();
        for (int i = 0; i < _spells.Count; i++)
        {
            var spell = _spells[i];
            if (spell.Length == _currentRunes.Count)
            {
                appropriateSpells.Add(spell);
            }           
        }

        int correctRunes = 0;
        for (int i = 0; i < appropriateSpells.Count; i++)
        {
            var spell = appropriateSpells[i];
            for (int j = 0; j < spell.Runes.Count; j++)
            {
                var rune = spell.Runes[j];
                if (_currentRunes[j] == rune)
                {
                    correctRunes++;
                }
            }

            if (correctRunes == spellLength)
            {
                Debug.Log($"Correct spell: {spell} Spell Name: {spell.Name} Spell Length: {spell.Length} Spell Cost: {spell.ManaCost}");
                if (spell.ManaCost <= PlayerManager.Singleton.GiveMana())
                {
                    PlayerManager.Singleton.ManaChange(-spell.ManaCost);
                    spell.SpellLogic();
                } 
                break;
            }
            else
                correctRunes = 0;
        }

        _currentRunes.Clear();
    }
}
