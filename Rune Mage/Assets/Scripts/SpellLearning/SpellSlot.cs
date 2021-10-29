using UnityEngine;
using UnityEngine.UI;


public class SpellSlot : MonoBehaviour
{
    [SerializeField] private Image _icon;

    private SpellBook _spellBook;
    private SpellInfo _spell;

    public void SetSpellBook(SpellBook spellBook)
    {
        _spellBook = spellBook;
    }

    public void SetSpell(SpellInfo spell)
    {
        _spell = spell;
        _icon.sprite = _spell.Spell.Sprite;
    }

    public void SetSpellInfo()
    {
        _spellBook.SetSpellInfo(_spell);
    }
}
