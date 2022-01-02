using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class SpellsSystem : BaseSingleton<SpellsSystem>
{
    [SerializeField] private List<Spell> _spells = new List<Spell>();
    [SerializeField] private int _maxRunesAmount;

    private int _currentRunesInSpell;
    private bool _isSpellCasting;

    public Action OnSpellCasted;

    public List<Rune> _currentRunes = new List<Rune>();

    public bool AddNewRune(Rune rune)
    {
        if (_currentRunesInSpell >= _maxRunesAmount)
        {
            return false;
        } 
        else
        {
            _currentRunes.Add(rune);
            _currentRunesInSpell++;
            return true;
        }
    }

    public void UseSpell()
    {
        var spellLength = _currentRunes.Count;
        List<Spell> appropriateSpells = new List<Spell>();
        for (int i = 0; i < _spells.Count; i++)
        {
            var spell = _spells[i];
            if (spell.Runes.Count == _currentRunes.Count)
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

            if (correctRunes == spellLength && !_isSpellCasting)
            {
                OnSpellCasted?.Invoke();

                Debug.Log($"Correct spell: {spell} Spell Name: {spell.Name} Spell Length: {spell.Runes.Count} Spell Cost: {spell.ManaCost}");
                StartCoroutine(SpellLogic(spell));
                break;
            }
            else
                correctRunes = 0;
        }

        _currentRunesInSpell = 0;
        _currentRunes.Clear();
    }

    private IEnumerator SpellLogic(Spell spell)
    {
        if (IsHasManaToCast(spell))
        {
            spell.SpellLogic();
            PlayerManager.Singleton.GetMana().ManaChange(-spell.ManaCost);
        }

        yield return null;
    }

    private bool IsHasManaToCast(Spell spell)
    {
        return spell.ManaCost <= PlayerManager.Singleton.GetMana().GetCurrentMana();
    }

    public void IsSpellCasting(bool value)
    {
        _isSpellCasting = value;
    }

    public List<Spell> GetSpells()
    {
        return _spells;
    }
}
