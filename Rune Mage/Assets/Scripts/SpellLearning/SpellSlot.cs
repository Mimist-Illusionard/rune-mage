using UnityEngine;
using UnityEngine.UI;


public class SpellSlot : MonoBehaviour
{
    [SerializeField] private Image _icon;

    private SpellBook _spellBook;
    private Spell _spell;

    public void SetSpellBook(SpellBook spellBook)
    {
        _spellBook = spellBook;
    }

    public void SetSpell(Spell spell)
    {
        _spell = spell;
        _icon.sprite = _spell.Sprite;
    }

    public void SetSpellInfo()
    {
        _spellBook.SetSpellInfo(_spell);
    }
}
