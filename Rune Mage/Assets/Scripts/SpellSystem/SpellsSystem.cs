using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpellsSystem : MonoBehaviour
{
    [SerializeField] private List<SpellInfo> _spells = new List<SpellInfo>();
    [SerializeField] private int _maxRunesAmount;

    private int _currentRunesInSpell;
    private bool _isSpellCasting;

    public List<Rune> _currentRunes = new List<Rune>();
    public static SpellsSystem Singleton { get; private set; }

    private void Awake()
    {
        Singleton = this;
    }

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
            if (spell.Spell.Length == _currentRunes.Count)
            {
                appropriateSpells.Add(spell.Spell);
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
                Debug.Log($"Correct spell: {spell} Spell Name: {spell.Name} Spell Length: {spell.Length} Spell Cost: {spell.ManaCost}");
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
        float currentWaitTime = spell.Interval;
        if (spell.InputMode == InputModeType.Hold)
        {
            while (Input.GetKey(KeyCode.Mouse1) && IsHasManaToCast(spell))
            {
                currentWaitTime -= Time.deltaTime;
                if (currentWaitTime <= 0)
                {
                    spell.SpellLogic();
                    PlayerManager.Singleton.GetMana().ManaChange(-spell.ManaCost);

                    currentWaitTime = spell.Interval;
                }

                yield return new WaitForEndOfFrame();
            }
        }
        else if (IsHasManaToCast(spell))
        {
            spell.SpellLogic();
            PlayerManager.Singleton.GetMana().ManaChange(-spell.ManaCost);
        }

        yield return null;
    }

    private bool IsHasManaToCast(Spell spell)
    {
        return spell.ManaCost <= PlayerManager.Singleton.GetMana().GiveMana();
    }

    public void IsSpellCasting(bool value)
    {
        _isSpellCasting = value;
    }

    public List<SpellInfo> GetSpells()
    {
        return _spells;
    }
}
